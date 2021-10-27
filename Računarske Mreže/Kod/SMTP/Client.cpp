#define _WINSOCK_DEPRECATED_NO_WARNINGS
#include <iostream>
#include <winsock2.h>
#include <string>
#include <sstream>
#include <fstream>

#pragma comment(lib, "ws2_32.lib")
using namespace std;

#define SERVER_PORT 25 // TPC
#define SERVER_ADDR "127.0.0.1"
#define PATH "C:\\Users\\stefa\\Desktop\\RM\\SMTP\\"

int main(int arc, char **argv)
{
    WSADATA data;
    if (WSAStartup(0x0202, &data) != 0)
        exit(999);
    else
        cout << "Startup successful!" << endl;

    SOCKET clientSocket = socket(AF_INET, SOCK_STREAM, 0);
    if (clientSocket == -1)
        exit(998);
    else
        cout << "Socket successful!" << endl;

    sockaddr_in server;
    server.sin_family = AF_INET;
    server.sin_port = htons(SERVER_PORT);
    server.sin_addr.S_un.S_addr = inet_addr(SERVER_ADDR);

    connect(clientSocket, (sockaddr *)&server, sizeof(server));
    if (clientSocket == -1)
        exit(997);
    else
        cout << "Connect successful!" << endl;

    string sendMessage;
    char *recvBuffer = new char[INT16_MAX];
    ZeroMemory(recvBuffer, INT16_MAX);
    int bytesIn;

    bytesIn = recv(clientSocket, recvBuffer, INT16_MAX, 0);
    if (bytesIn <= 0)
        cout << "Couldn't recieve the welcome message!" << endl;
    else
    {
        cout << recvBuffer << endl;
        while (true)
        {
            getline(cin, sendMessage);
            if (send(clientSocket, sendMessage.c_str(), sendMessage.size(), 0) < sendMessage.size())
            {
                cout << "Message: " << sendMessage << " couldn't be sent!" << endl;
                break;
            }
            ZeroMemory(recvBuffer, INT16_MAX);
            bytesIn = recv(clientSocket, recvBuffer, INT16_MAX, 0);

            cout << recvBuffer << endl;

            if (sendMessage == "QUIT")
            {
                cout << "Disconnecting" << endl;
                break;
            }
            if (sendMessage == "DATA")
            {
                do
                {
                    getline(cin, sendMessage);
                    if (send(clientSocket, sendMessage.c_str(), sendMessage.size(), 0) < sendMessage.size())
                    {
                        cout << "Message: " << sendMessage << " couldn't be sent!" << endl;
                        break;
                    }
                } while (sendMessage != ".");
                ZeroMemory(recvBuffer, INT16_MAX);
                bytesIn = recv(clientSocket, recvBuffer, INT16_MAX, 0);

                cout << recvBuffer << endl;
            }
        }
    }
    if (recvBuffer)
    {
        delete[] recvBuffer;
        recvBuffer = nullptr;
    }

    closesocket(clientSocket);
    WSACleanup();

    system("pause");
    return 0;
}