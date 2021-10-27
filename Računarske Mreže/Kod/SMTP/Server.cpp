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

    SOCKET listening = socket(AF_INET, SOCK_STREAM, 0);
    if (listening == -1)
        exit(998);
    else
        cout << "Listening socket successful!" << endl;

    sockaddr_in server;
    server.sin_family = AF_INET;
    server.sin_port = htons(SERVER_PORT);
    server.sin_addr.S_un.S_addr = INADDR_ANY;
    //server.sin_addr.S_un.S_addr = inet_addr(SERVER_ADDR);

    if (bind(listening, (sockaddr *)&server, sizeof(server)) == -1)
        exit(997);
    else
        cout << "Bind successful!" << endl;

    if (listen(listening, 5) == -1)
        exit(996);
    else
        cout << "Listen successful!" << endl;

    SOCKET client;
    sockaddr_in clientInfo;
    int sizeOfClientInfo = sizeof(clientInfo);

    string sendMessage;
    char *recvBuffer = new char[INT16_MAX];
    int bytesIn;

    string clientADDR, sender, recipient, msgData;
    int messageNumber;
    while (true)
    {
        client = accept(listening, (sockaddr *)&clientInfo, &sizeOfClientInfo);
        if (client == -1)
        {
            cout << "Client socket corrupted!" << endl;
            break;
        }
        else
            cout << "Accept successful!" << endl;

        sendMessage = "220 Welcome to the server";
        if (send(client, sendMessage.c_str(), sendMessage.size(), 0) < sendMessage.size())
        {
            cout << "Message to client: '" << sendMessage << "' couldn't be sent!" << endl;
            break;
        }

        messageNumber = 0;
        clientADDR = sender = recipient = msgData = "";
        do
        {
            ZeroMemory(recvBuffer, INT16_MAX);
            bytesIn = recv(client, recvBuffer, INT16_MAX, 0);
            if (bytesIn <= 0)
            {
                cout << "Couldn't recieve message from the server!" << endl;
                break;
            }
            string recvMessage(recvBuffer, bytesIn);
            if (recvMessage.find("HELO") == 0)
            {
                // HELO "host"
                clientADDR = recvMessage.substr(strlen("HELO "));
                sendMessage = "250 Hello," + clientADDR + " pleased to meet you";
                if (send(client, sendMessage.c_str(), sendMessage.size(), 0) < sendMessage.size())
                {
                    cout << "Message to client: '" << sendMessage << "' couldn't be sent!" << endl;
                    break;
                }
            }
            else
            {
                if (recvMessage.find("MAIL FROM:") == 0)
                {
                    // MAIL FROM: "sender"
                    if (clientADDR.empty())
                    {
                        sendMessage = "404 ERROR: No clientADDR";
                        if (send(client, sendMessage.c_str(), sendMessage.size(), 0) < sendMessage.size())
                        {
                            cout << "Message to client: '" << sendMessage << "' couldn't be sent!" << endl;
                            break;
                        }
                    }
                    sender = recvMessage.substr(strlen("MAIL FROM: "));
                    sendMessage = "250 " + sender + " ... Sender OK";
                    if (send(client, sendMessage.c_str(), sendMessage.size(), 0) < sendMessage.size())
                    {
                        cout << "Message to client: '" << sendMessage << "' couldn't be sent!" << endl;
                        break;
                    }
                }
                else
                {
                    if (recvMessage.find("RCPT TO:") == 0)
                    {
                        if (sender.empty())
                        {
                            sendMessage = "404 ERROR: No sender address";
                            if (send(client, sendMessage.c_str(), sendMessage.size(), 0) < sendMessage.size())
                            {
                                cout << "Message to client: '" << sendMessage << "' couldn't be sent!" << endl;
                                break;
                            }
                        }
                        // RCPT TO: "recipient"
                        recipient = recvMessage.substr(strlen("RCPT TO: "));
                        sendMessage = "250 " + recipient + " ... Recipient OK";
                        if (send(client, sendMessage.c_str(), sendMessage.size(), 0) < sendMessage.size())
                        {
                            cout << "Message to client: '" << sendMessage << "' couldn't be sent!" << endl;
                            break;
                        }
                    }
                    else
                    {
                        if (recvMessage.find("DATA") == 0)
                        {
                            if (recipient.empty())
                            {
                                sendMessage = "404 ERROR: No recipient address";
                                if (send(client, sendMessage.c_str(), sendMessage.size(), 0) < sendMessage.size())
                                {
                                    cout << "Message to client: '" << sendMessage << "' couldn't be sent!" << endl;
                                    break;
                                }
                            }
                            // DATA
                            sendMessage = "354 Enter mail, end with \".\" on a line by itself";
                            if (send(client, sendMessage.c_str(), sendMessage.size(), 0) < sendMessage.size())
                            {
                                cout << "Message to client: '" << sendMessage << "' couldn't be sent!" << endl;
                                break;
                            }

                            msgData = "";
                            do
                            {
                                ZeroMemory(recvBuffer, INT16_MAX);
                                bytesIn = recv(client, recvBuffer, INT16_MAX, 0);
                                if (bytesIn <= 0)
                                    break;
                                string recvData(recvBuffer, bytesIn);
                                if (recvData != "\r\n.\r\n")
                                    msgData += recvData;
                                else
                                    break;

                            } while (true /*recvData != "."*/);
                            sendMessage = "250 Message accepted for delivery";
                            if (send(client, sendMessage.c_str(), sendMessage.size(), 0) < sendMessage.size())
                            {
                                cout << "Message to client: '" << sendMessage << "' couldn't be sent!" << endl;
                                break;
                            }

                            string fileName(PATH);

                            fileName += sender + "_" + recipient + "_" + to_string(messageNumber++) + ".txt ";
                            fstream file(fileName, ios::trunc | ios::out);
                            if (file.good())
                            {
                                file.write(sender.c_str(), sender.size());
                                file.write("\n", 1);
                                file.write(recipient.c_str(), recipient.size());
                                file.write("\n", 1);
                                file.write(msgData.c_str(), msgData.size());
                                file.close();
                            }
                            else
                            {
                                cout << "Couldn't open the file " << fileName << endl;
                                break;
                            }
                        }
                        else
                        {
                            if (recvMessage.find("QUIT") == 0)
                            {
                                // QUIT
                                sendMessage = "221 " + clientADDR + " closing the connection!";
                                if (send(client, sendMessage.c_str(), sendMessage.size(), 0) < sendMessage.size())
                                {
                                    cout << "Message to client: '" << sendMessage << "' couldn't be sent!" << endl;
                                    break;
                                }
                                cout << "Disconnecting from the client " << clientADDR << endl;
                                break;
                            }
                        }
                    }
                }
            }

        } while (true /*recvMessage != "QUIT"*/);

        if (recvBuffer != nullptr)
        {
            delete[] recvBuffer;
            recvBuffer = nullptr;
        }

        closesocket(listening);
        WSACleanup();

        system("pause");
        return 0;
    }
}