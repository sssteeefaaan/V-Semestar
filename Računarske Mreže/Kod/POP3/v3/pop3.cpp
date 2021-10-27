#include <iostream>
#include <sstream>
#include <vector>
#include <map>
#include <string>

#pragma comment(lib, "ws2_32.lib")
using namespace std;

// POP3{
//      port: 110,
//      protocol: TCP
//}
#define SERVER_PORT 110
#define SERVER_ADDR "127.0.0.1"

void exitWithMessage(const string &msg);
void communication(SOCKET client);

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

    while (true)
    {
        client = accept(listening, (sockaddr *)&clientInfo, &sizeOfClientInfo);
        if (client == -1)
        {
            cout << "[SERVER] Client socket error. Quit? Y/N" << endl;
            getline(cin, temp);
            if (temp == "Y")
                break;
            cout << "[SERVER] Continuing..." << endl;
            continue;
        }

        communication(client);
    }

    cout << "[SERVER] Shutting down..." << endl;
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

void communication(SOCKET client)
{
    int bytesIn, bytesOut;
    string sendBuffer = "+OK POP3 Server ready", recvBuffer;
    char *buffer = new char[INT16_MAX];

    bytesOut = send(client, sendBuffer.c_str(), sendBuffer.size(), 0);
    if (bytesOut < sendBuffer.size())
        cout << "[SERVER] Didn't send all bytes" << endl;

    while (true)
    {
        memset(buffer, '\0', INT16_MAX);
        bytesIn = recv(client, buffer, INT16_MAX);
        if (bytesIn < 1)
        {
            cout << "[SERVER] Broken communication!" << endl;
            sendBuffer = "-ERR Broken communication!" << endl;
            bytesOut = send(client, sendBuffer.c_str(), sendBuffer.size(), 0);
            if (bytesOut < sendBuffer.size())
                cout << "[SERVER] Didn't send all bytes" << endl;
            break;
        }
    }
}