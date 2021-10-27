#include <WS2tcpip.h>
#include <stdio.h>
#include <string.h>
#include <fstream>
#pragma comment(lib, "ws2_32.lib")
#pragma warning(disable : 4996)

using namespace std;

#define SERVER_ADDR "127.0.0.1"

void exitWithError(const string &msg, SOCKET *listening = nullptr, SOCKET *client = nullptr)
{
	if (listening)
		closesocket(*listening);
	if (client)
		closesocket(*client);

	printf("[ERROR] %s\n", msg.c_str());
	printf("[ERROR CODE] %d\n", WSAGetLastError());
	WSACleanup();
	exit(-100);
}
int main()
{
	WSAData wsa;
	if (WSAStartup(0x0202, &wsa) != 0)
		exitWithError("Startup failed!");

	SOCKET listening;
	sockaddr_in server;

	if ((listening = socket(AF_INET, SOCK_STREAM, 0)) == SOCKET_ERROR)
		exitWithError("Creating listening socket failed!");

	server.sin_family = AF_INET;
	server.sin_port = htons(80);
	server.sin_addr.S_un.S_addr = inet_addr(SERVER_ADDR);
	//inet_pton(AF_INET, "127.0.0.1", &server.sin_addr);

	if (bind(listening, (sockaddr *)&server, sizeof(sockaddr)) == SOCKET_ERROR)
		exitWithError("Bind failed!", &listening);

	if (listen(listening, 100) == SOCKET_ERROR)
		exitWithError("Listen failed!", &listening);

	while (true)
	{
		SOCKET clientSock;
		sockaddr_in client;

		int addr_len = sizeof(sockaddr);
		if ((clientSock = accept(listening, (sockaddr *)&client, &addr_len)) == SOCKET_ERROR)
			exitWithError("Accept failed!", &listening);

		char sendBuf[200000];
		char recvBuf[1024];

		ZeroMemory(sendBuf, 200000);
		ZeroMemory(recvBuf, 1024);

		int bytes_send;
		int bytes_recv;

		bytes_recv = recv(clientSock, recvBuf, 1024, 0);
		if (bytes_recv < 0)
			exitWithError("Recieve failed!", &listening);

		printf("%s\n", recvBuf);
		//	GET /download.png HTTP / 1.1
		//	Connection: close
		//	User-agent : Mozilla / 4.0
		//	Accept : text / html, image / gif, image / jpeg
		//	Accept-language : fr

		char fileName[25];
		char version[20];
		int j = 0;
		char *t = strstr(recvBuf, "/");
		t++;
		while (*t != ' ')
			fileName[j++] = *t++;
		fileName[j] = '\0';

		j = 0;
		while (*t != '\r')
			version[j++] = *t++;
		version[j] = '\0';

		char path[100];
		ZeroMemory(path, 100);
		strcat(path, "C:\\Users\\stefa\\Desktop\\RM\\HTTPServer\\");
		strcat(path, fileName);

		printf("%s\n%s\n", path, version);
		if (std::string(version).compare("HTTP/1.1") == 0)
		{
			std::string sendStr = "HTTP/1.1 505 Bad HTTP version\r\nContent-Length: 28\r\nContent-Type: text/plain\r\n\r\n505 Error: Bad HTTP version!";
			if ((send(clientSock, sendStr.data(), sendStr.length(), 0)) < sendStr.length())
				exitWithError("Send failed!", &listening, &clientSock);
		}
		else
		{
			char temp[10000];
			char body[65536];
			char body_len[100];
			ZeroMemory(temp, 10000);
			ZeroMemory(body, 65536);

			ifstream myFile(path, ios::binary | ios::in);

			long len;
			char *buf = NULL;
			FILE *fp = NULL;
			fp = fopen(path, "rb");

			if (myFile)
			{
				if (fseek(fp, 0, SEEK_END) != 0)
				{
					fclose(fp);
				}
				// Velićina fajla
				len = ftell(fp);
				rewind(fp);
				buf = (char *)malloc(sizeof(char) * len);
				if (!buf)
				{
					fclose(fp);
				}
				else
					printf("Content-Length: %d\n", strlen(buf));

				strcat(sendBuf, "HTTP/1.1 200 OK\r\n");
				itoa(len, body_len, 10);
				//strcat(sendBuf, "Content-Type: image/jpg\r\n");
				strcat(sendBuf, "Content-Length: ");
				strcat(sendBuf, body_len);
				strcat(sendBuf, "\r\n");
				strcat(sendBuf, "Content-Type: image/jpg, image/gif, image/png\r\n\r\n");
				printf("Header-Length: %d\n", strlen(sendBuf));
				if (!fread(sendBuf, len, 1, fp))
				{
					fclose(fp);
				}
				fclose(fp);
				//	strcat(sendBuf, body);

				// strlen(buf) je samo veličina fajla????
				bytes_send = send(clientSock, sendBuf, strlen(buf), 0);
				if (bytes_send < 0)
					exitWithError("Send failed!", &listening, &clientSock);
			}
			else
			{
				if (strstr(fileName, ".jpg") != NULL || strstr(fileName, ".gif") != NULL || strstr(fileName, ".png") != NULL) //proverava ekstenziju zahtevanog fajla...
				{

					strcat(sendBuf, "HTTP/1.1 404 Not Found\nContent-Length: 26\nContent-Type: text/plain\n\n404 Error: File not Found!");
					bytes_send = send(clientSock, sendBuf, strlen(sendBuf), 0);
					if (bytes_send < 0)
						exitWithError("Send failed!", &listening, &clientSock);
				}
				else
				{
					strcat(sendBuf, "HTTP/1.1 400 Bad Request\nContent-Length: 23\nContent-Type: text/plain\n\n400 Error: Bad request!");
					bytes_send = send(clientSock, sendBuf, strlen(sendBuf), 0);
					if (bytes_send < 0)
						exitWithError("Send failed!", &listening, &clientSock);
				}
			}
		}
		closesocket(clientSock);
	}

	closesocket(listening);
	WSACleanup();

	return 0;
}