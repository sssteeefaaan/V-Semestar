#include <iostream>
#include <WS2tcpip.h>
#pragma comment(lib, "ws2_32.lib")
#include <string>
#include <vector>
#include <thread>
#include <mutex>
#include "MailBox.h"

#define MAX_CONNECTIONS 10
#define BUFF_SIZE 4096

std::vector<MailBox *> DATABASE;
std::mutex m;

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
std::vector<std::string> split(const std::string &str, char p)
{
	std::vector<std::string> ret;
	int size = str.length(), j;
	std::string temp;
	for (int i = 0; i < size; i++)
	{
		temp = str[i];
		j = i + 1;
		while (str[j] != p && j < size)
			temp += str[j++];
		ret.push_back(temp);
		i = j;
	}
	return ret;
}
int interpretCommand(const std::string &cmd, std::string &sendBuffer, int &ID, std::string &previousCommand)
{
	std::vector<std::string> cmdARGS = split(cmd, ' ');
	if (cmdARGS[0].compare("\\new") == 0)
	{
		if (previousCommand.compare("\\null") == 0)
		{
			m.lock();
			DATABASE[ID]->setUser(cmdARGS[1]);
			DATABASE[ID]->setPass(cmdARGS[2]);
			m.unlock();
			sendBuffer = "+OK Successfully created new user{ " + cmdARGS[1] + ", " + cmdARGS[2] + " }";
			previousCommand = "\\new";
			return 1;
		}
		else
			sendBuffer = "Error: Can't create another account!";
		return -1;
	}
	if (cmdARGS[0].compare("\\user") == 0)
	{
		m.lock();
		int size = DATABASE.size();
		for (int i = 0; i < size; i++)
		{
			if (DATABASE[i]->getUser().compare(cmdARGS[1]) == 0)
			{
				sendBuffer = "+OK Enter password for user{ " + cmdARGS[1] + " }";
				if (DATABASE[ID])
				{
					delete DATABASE[ID];
					DATABASE[ID] = nullptr;
				}
				m.unlock();
				ID = i;
				previousCommand = "\\user";
				return 1;
			}
		}
		m.unlock();
		sendBuffer = "Error: No user under the username{ " + cmdARGS[1] + " } found!";
		return -1;
	}
	if (cmdARGS[0].compare("\\pass") == 0)
	{
		if (previousCommand.compare("\\user") == 0)
		{
			m.lock();
			if (DATABASE[ID]->getPassword().compare(cmdARGS[1]) == 0)
			{
				sendBuffer = "+OK Successfully loged in as user{ " + DATABASE[ID]->getUser() + ", " + cmdARGS[1] + " }";
				m.unlock();
				previousCommand = "\\pass";
				return 1;
			}
			m.unlock();
			sendBuffer = "Error: Wrong password for username{ " + cmdARGS[1] + " } !";
		}
		else
			sendBuffer = "Error: You need to input password first!";
		return -1;
	}
	if (cmdARGS[0].compare("\\list") == 0)
	{
		if (previousCommand.compare("\\pass") == 0 || previousCommand.compare("\\new") == 0)
		{
			m.lock();
			int size = DATABASE[ID]->getNumberOfMessages();
			std::vector<std::string *> msgs = DATABASE[ID]->getAllMessages();
			m.unlock();
			if (size > 0)
			{
				sendBuffer = "+OK " + std::to_string(size) + " Messages:";
				for (int i = 0; i < size; i++)
					sendBuffer += "\n" + std::to_string(i + 1) + " " + msgs[i][0];
			}
			else
				sendBuffer = "+OK Mailbox is empty";
			return 1;
		}
		else
			sendBuffer = "Error: Log in first!";
		return -1;
	}
	if (cmdARGS[0].compare("\\send") == 0)
	{
		if (previousCommand.compare("\\pass") == 0 || previousCommand.compare("\\new") == 0)
		{
			std::string data;
			for (unsigned int i = 2; i < cmdARGS.size() - 1; i++)
				data += cmdARGS[i] + ' ';
			data += cmdARGS.back();
			m.lock();
			std::string from = DATABASE[ID]->getUser();
			for (unsigned int i = 0; i < DATABASE.size(); i++)
			{
				if (DATABASE[i]->getUser().compare(cmdARGS[1]) == 0)
				{
					DATABASE[i]->addNewMessage(from, data);
					sendBuffer = "+OK Successfully sent message to user{" + cmdARGS[1] + "}";
					m.unlock();
					return 1;
				}
			}
			m.unlock();
			sendBuffer = "Error: User under username{ " + cmdARGS[1] + " } not in database!";
		}
		else
			sendBuffer = "Error: Log in first!";
		return -1;
	}
	if (cmdARGS[0].compare("\\retr") == 0)
	{
		if (previousCommand.compare("\\pass") == 0 || previousCommand.compare("\\new") == 0)
		{
			int at = std::stoi(cmdARGS[1]) - 1;
			sendBuffer = "+OK Message from ";
			std::string *msg;
			m.lock();
			msg = DATABASE[ID]->getFromAllMessagesAt(at);
			m.unlock();
			sendBuffer += msg[0] + ":\n" + msg[1];
			return 1;
		}
		else
			sendBuffer = "Error: Log in first!";
		return -1;
	}
	if (cmdARGS[0].compare("\\dele") == 0)
	{
		if (previousCommand.compare("\\pass") == 0 || previousCommand.compare("\\new") == 0)
		{
			int at = std::stoi(cmdARGS[1]);
			sendBuffer = "+OK Deleted message " + std::to_string(at);
			m.lock();
			DATABASE[ID]->delFromAllMessagesAt(at - 1);
			m.unlock();
			return 1;
		}
		else
			sendBuffer = "Error: Log in first!";
		return -1;
	}
	if (cmdARGS[0].compare("\\quit") == 0)
	{
		sendBuffer = "+OK Successfully disconnected.";
		return 0;
	}
	if (cmdARGS[0].compare("\\help") == 0)
	{
		sendBuffer = "+OK\nMoguce komande:\nPomoc ............................... \\help\n";
		if (previousCommand.compare("\\null") == 0)
		{
			sendBuffer += "Kreiranje novog naloga .............. \\new \t \"Vas username\" \t \"Vas password\"\n";
			sendBuffer += "Unos korisnickog imena .............. \\user \t \"Vas username\"";
		}
		if (previousCommand.compare("\\user") == 0)
			sendBuffer += "Unos lozinke ........................ \\pass \t \"Vas password\"";
		if (previousCommand.compare("\\pass") == 0 || previousCommand.compare("\\new") == 0)
		{
			sendBuffer += "Slanje poruke ....................... \\send \t \"Username primaoca\" \t \"Sadrzaj poruke\"\n";
			sendBuffer += "Izlistavanje svih poruka ............ \\list\n";
			sendBuffer += "Dobijanje sadrzaja poruke ........... \\retr \t \"Identifikacioni broj poruke\"\n";
			sendBuffer += "Brisanje poruke iz liste ............ \\dele \t \"Identifikacioni broj poruke\"\n";
			sendBuffer += "Prekid komunikacije ................. \\quit\n";
		}
		return 1;
	}
	sendBuffer = "Error: Unrecognized command!";
	return -1;
}
void handleComms(SOCKET *client, bool *running)
{
	int ID;

	m.lock();
	DATABASE.push_back(new MailBox(client));
	ID = DATABASE.size() - 1;
	m.unlock();

	int bytesIn, bytesOut, cmdExe;
	std::string sendBuffer, previousCommand = "\\null";
	char recvBuffer[BUFF_SIZE];
	bool sockRunning = true;
	while (sockRunning && *running)
	{
		ZeroMemory(recvBuffer, BUFF_SIZE);
		bytesIn = recv(*client, recvBuffer, BUFF_SIZE, 0);
		if (bytesIn < 0)
		{
			std::cout << "[ERROR] Couldn't receive message from client." << std::endl;
			sockRunning = false;
			continue;
		}

		cmdExe = interpretCommand(std::string(recvBuffer), sendBuffer, ID, previousCommand);
		sendBuffer += "\n.";
		std::vector<std::string> forSending = split(sendBuffer, '\n');
		int size = forSending.size();
		for (int i = 0; i < size; i++)
		{
			std::cout << forSending[i] << std::endl;
			bytesOut = send(*client, forSending[i].c_str(), forSending[i].length(), 0);
			if (bytesOut != sendBuffer.length())
			{
				std::cout << "[ERROR] Message to the client wasn't sent correctly.\nWanna drop connection?\n";
				std::string input;
				std::getline(std::cin, input);
				if (input.compare("Yes") == 0)
				{
					sockRunning = false;
					continue;
				}
				else
					std::cout << "[Server] You decided to continue with the connection." << std::endl;
			}
		}
		if (cmdExe == -1)
		{
			std::cout << "[ERROR] Couldn't execute the command client provided correctly.\nWanna drop connection?\n";
			std::string input;
			std::getline(std::cin, input);
			if (input.compare("Yes") == 0)
			{
				sockRunning = false;
				continue;
			}
			else
				std::cout << "[Server] You decided to continue with the connection." << std::endl;
		}
		if (cmdExe == 0)
			sockRunning = false;
	}
	if (client)
	{
		closesocket(*client);
		delete client;
		client = nullptr;
	}
}
void handleInput(bool *running)
{
	std::string inpt = "";
	while (*running = inpt.compare("\\quit") != 0)
		std::getline(std::cin, inpt);
}

int main(int argumentcCount, char *argumentVector[])
{
	// _CrtSetDbgFlag(_CRTDBG_ALLOC_MEM_DF | _CRTDBG_LEAK_CHECK_DF); s ovim proveravam memory leaks

	std::string serverAddress, serverPort;
	std::cout << "Unesite adresu servera:" << std::endl;
	std::getline(std::cin, serverAddress);

	std::cout << "Unesite port servera:" << std::endl;
	std::getline(std::cin, serverPort);

	WSAData data;
	WORD version = MAKEWORD(2, 2); // 0x0202

	if (WSAStartup(version, &data) != 0)
		errorOccurred("Startup failed!");
	else
		std::cout << "[SERVER] Startup successful!" << std::endl;

	SOCKET listening = socket(AF_INET /* IPV4*/, SOCK_STREAM, 0);
	if (listening == INVALID_SOCKET)
		errorOccurred("Creation of server's listening socket failed!");
	else
		std::cout << "[SERVER] Successfully created server's listening socket!" << std::endl;

	sockaddr_in server;
	server.sin_family = AF_INET;
	server.sin_port = htons(std::stoi(serverPort));
	server.sin_addr.S_un.S_addr = INADDR_ANY;

	if ((bind(listening, (sockaddr *)&server, sizeof(server))) == SOCKET_ERROR)
		errorOccurred("Binding socket to the port failed!");
	else
		std::cout << "[SERVER] Successfully bound port to the listening socket!" << std::endl;

	if (listen(listening, MAX_CONNECTIONS) == SOCKET_ERROR /*-1*/)
		errorOccurred("Listeing unsuccessful!");
	else
		std::cout << "[SERVER] Listening on " << serverAddress << ":" << serverPort << "...\n";

	std::vector<std::thread *> threadComms;
	sockaddr_in client;
	int cLen = sizeof(client);
	SOCKET *clientSocket;
	bool running = true;
	//std::thread consoleInput(handleInput, &running);

	while (running)
	{
		clientSocket = new SOCKET(accept(listening, (sockaddr *)&client, &cLen));
		if (*clientSocket == INVALID_SOCKET)
		{
			delete clientSocket;

			std::cout << "[ERROR] Client socket was corrupted.\nDo you want to close the server?\n";
			std::string input;
			std::getline(std::cin, input);
			if (input.compare("Yes") == 0)
				running = false;
			else
				std::cout << "[Server] You decided to continue with the connection." << std::endl;
		}
		else
			threadComms.push_back(new std::thread(handleComms, clientSocket, &running));
	}
	std::cout << "[SERVER] Shutting down..." << std::endl;

	//Cleaning
	{
		for (std::thread *x : threadComms)
		{
			if (x)
			{
				x->join();
				delete x;
				x = nullptr;
			}
		}
		threadComms.clear();

		//consoleInput.join();

		for (MailBox *x : DATABASE)
		{
			if (x)
			{
				delete x;
				x = nullptr;
			}
		}
		DATABASE.clear();

		closesocket(listening);
		WSACleanup();
	}
}