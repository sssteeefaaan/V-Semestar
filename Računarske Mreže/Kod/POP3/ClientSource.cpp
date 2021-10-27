#include <iostream>
#include <WS2tcpip.h>
#pragma comment(lib, "ws2_32.lib")
#include <string>

#define BUFF_SIZE 4096 // Može i to da se unese na početku, idk

void errorOccurred(std::string str)
{
	std::cout << "[ERROR] " << str << std::endl
			  << "[ERROR CODE] " << WSAGetLastError() << std::endl;
	WSACleanup();
	exit(-8888);
}
bool startsWith(const std::string &str1, const std::string &str2)
{
	int l1 = str1.length(), l2 = str2.length();
	if (l1 < l2)
		return false;
	for (int i = 0; i < l2; i++)
		if (str1[i] != str2[i])
			return false;
	return true;
}
void receivedMessage(char *str, int length)
{
	std::cout << "[SERVER] ";
	for (int i = 0; i < length; std::cout << str[i++])
		;
	std::cout << std::endl;
}
int main(int count, char *vec[])
{
	std::string serverAddress, serverPort;
	std::cout << "Unesite adresu servera:" << std::endl;
	std::getline(std::cin, serverAddress);

	std::cout << "Unesite port servera:" << std::endl;
	std::getline(std::cin, serverPort);

	WSADATA data;
	WORD version = MAKEWORD(2, 2);

	if (WSAStartup(version, &data) != 0)
		errorOccurred("Startup failed!");
	else
		std::cout << "[CLIENT] Startup successful!" << std::endl;

	SOCKET client = socket(AF_INET, SOCK_STREAM, 0);
	if (client == INVALID_SOCKET)
		errorOccurred("Failed creating a client's socket!");
	else
		std::cout << "[CLIENT] Client socket successfully created!" << std::endl;

	sockaddr_in server;
	server.sin_family = AF_INET;
	server.sin_port = htons(std::stoi(serverPort));
	server.sin_addr.S_un.S_addr = inet_addr(serverAddress.c_str());
	//inet_pton(AF_INET, serverAddress.c_str(), &server.sin_addr);

	if ((connect(client, (sockaddr *)&server, sizeof(server))) == SOCKET_ERROR)
		errorOccurred("Connecting failed!");
	else
		std::cout << "[CLIENT] Veza sa serverom " << serverAddress << ":" << serverPort << " uspostavljena." << std::endl;

	std::string sendBuffer;
	char recvBuffer[BUFF_SIZE];
	int bytesIn, bytesOut;
	bool running = true;

	while (running)
	{
		std::getline(std::cin, sendBuffer);

		bytesOut = send(client, sendBuffer.c_str(), sendBuffer.length(), 0);
		if (bytesOut < sendBuffer.length())
		{
			std::cout << "[ERROR] Message to the server wasn't sent correctly.\nWanna drop connection?\n";
			std::string input;
			std::getline(std::cin, input);
			if (input.compare("Yes") == 0)
			{
				running = false;
				continue;
			}
			else
				std::cout << "[CLIENT] You decided to continue with the connection." << std::endl;
		}

		ZeroMemory(recvBuffer, BUFF_SIZE);
		bytesIn = recv(client, recvBuffer, BUFF_SIZE, 0);
		if (bytesIn < 0)
		{
			std::cout << "[ERROR] Message from the server wasn't received correctly.\nWanna drop connection?\n";
			std::string input;
			std::getline(std::cin, input);
			if (input.compare("Yes") == 0)
			{
				running = false;
				continue;
			}
			else
				std::cout << "[CLIENT] You decided to continue with the connection." << std::endl;
		}
		if (!startsWith(std::string(recvBuffer), "+OK"))
		{
			std::cout << "[CLIENT] Server didn't give OK." << std::endl;
			// DROP?
		}
		if (sendBuffer.compare("\\quit") == 0)
			running = false;

		receivedMessage(recvBuffer, bytesIn);
	}

	closesocket(client);
	WSACleanup();
}