#include <winsock2.h>
#include <iostream>
#include <string>
#include <sstream>
#include <fstream>

#pragma comment("lib", "ws2_32.lib")
using namespace std;

#define SERVER_PORT 80
#define SERVER_ADDRESS "127.0.0.1"
#define MAX_CON 5

void exitWithMessage(const string &msg);
void processData(SOCKET &client, char *data, int size);
void sendError(SOCKET &client, const string &msg);

int main()
{
	WSADATA data;
	WORD version = MAKEWORD(2, 2);
	if (WSAStartup(version, &data) != 0)
		exitWithMessage("Couldn't start window sock version 0x0202!");
	else
		cout << "[SERVER] Started winsock 0x0202 successfully!" << endl;

	SOCKET listening = socket(AF_INET, SOCK_STREAM, 0);
	if (listening == -1)
		exitWithMessage("Listening socket Error!");
	else
		cout << "[SERVER] Created listening socket successfully!" << endl;

	sockaddr_in server;
	server.sin_family = AF_INET;
	server.sin_port = htons(SERVER_PORT);
	server.sin_addr.S_un.S_addr = inet_addr(SERVER_ADDRESS);

	if (bind(listening, (sockaddr *)&server, sizeof(server)) == -1)
		exitWithMessage((string) "Couldn't bind server's listening socket to " + SERVER_ADDRESS + ":" + to_string(SERVER_PORT));
	else
		cout << "[SERVER] Successfully bound server's listening socket to " << SERVER_ADDRESS << ":" << SERVER_PORT << endl;

	if (listen(listening, MAX_CON) == -1)
		exitWithMessage("Listening failed!");
	else
		cout << "[SERVER] Server is listening on " << SERVER_ADDRESS << ":" << SERVER_PORT << endl;

	SOCKET client;
	sockaddr_in clientInfo;
	int sizeOfClientInfo = sizeof(clientInfo);

	string temp;
	char *buffer = new char[INT16_MAX];
	int bytesIn;

	while (true)
	{
		client = accept(listening, (sockaddr *)&clientInfo, &sizeOfClientInfo);
		if (client == -1)
		{
			cout << "Client socket error!" << endl
				 << "Wanna abort the server?" << endl;
			getline(cin, temp);
			if (temp == "Yes")
				break;
			cout << "[SERVER] Continuing..." << endl;
		}

		memset(buffer, '\0', INT16_MAX);
		bytesIn = recv(client, buffer, INT16_MAX, 0);
		if (bytesIn < 1)
		{
			cout << "[SERVER] Client disconnected!" << endl;
			continue;
		}

		processData(client, buffer, bytesIn);
	}

	if (buffer)
	{
		delete[] buffer;
		buffer = nullptr;
	}

	closesocket(listening);
	WSACleanup();
	return 0;
}

void exitWithMessage(const string &msg)
{
	cout << "[ERROR] " << msg << endl
		 << "[WSAERROR] " << WSAGetLastError() << endl;
	WSACleanup();
	exit(999);
}
void processData(SOCKET &client, char *data, int size)
{
	// Konvertujem ceo request u string
	string request(data, size);
	// Prva linija request-a
	string firstLine = request.substr(0, request.find("\n"));
	if (firstLine.find("GET") < 0)
	{
		// Nije get
		sendError(client, "405 Method Not Allowed");
		return;
	}
	if (firstLine.find("HTTP/1.1") < 0)
	{
		// Nije http version 1.1
		sendError(client, "505 HTTP Version Not Supported");
		return;
	}

	// Odvajam path, sve između "GET /" i " HTTP/1.1"
	string filePath = firstLine.substr(firstLine.find("/") + 1, firstLine.find_last_of(" ") - firstLine.find("/"));

	ifstream file(filePath, ios::binary | ios::ate);
	if (file.good())
	{
		long size = file.tellg();
		char *buffer = new char[size];
		memset(buffer, '\0', size);
		file.seekg(0, ios::beg);
		file.read(buffer, size);
		file.close();

		ostringstream ss;
		ss << "HTTP/1.0 200 OK\r\n" // da bi se završila konekcija
		   << "Content-Type: image/jpg\r\n"
		   << "Content-Length: " << size << "\r\n"
		   << "\r\n";

		long bytesIn = send(client, ss.str().c_str(), ss.str().size(), 0);
		if (bytesIn == ss.str().size())
		{
			bytesIn = send(client, buffer, size, 0);
			if (bytesIn == size)
			{
				if (buffer)
				{
					delete[] buffer;
					buffer = nullptr;
				}
				return;
			}
		}

		cout << "[SERVER] Error: failed to send all bites" << endl;
		if (buffer)
		{
			delete[] buffer;
			buffer = nullptr;
		}
		return;
	}
	else
	{
		sendError(client, (string) "404 Not Found " + filePath);
		return;
	}
}

void sendError(SOCKET &client, const string &msg)
{
	ostringstream ss;
	ss << "HTTP/1.0 " << msg << "\r\n"
	   << "Content-Type: text/plain\r\n"
	   << "Content-Length: " << msg.size() << "\r\n"
	   << "\r\n"
	   << msg;

	int bytesOut = send(client, ss.str().c_str(), ss.str().size(), 0);
	if (bytesOut < ss.str().size())
	{
		cout << "[SERVER] Error: failed to send all bites" << endl;
		return;
	}
}