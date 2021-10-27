#define _CRT_SECURE_NO_WARNINGS
#define _WINSOCK_DEPRECATED_NO_WARNINGS
#include <iostream>
#include <fstream>
#include <sstream>
#include <string>
#include <vector>
#include <winsock2.h>
#pragma comment(lib, "Ws2_32.lib")
using namespace std;

#define SERVER_PORT 80
#define SERVER_ADDRESS "127.0.0.1"
#define MAX_CONN 5
#define BUFF_SIZE 4096

void processData(char *data, int dataSize, char *output, int &outputSize)
{
    string incoming(data, dataSize);
    string first = incoming.substr(0, incoming.find("\n"));
    char size[100];
    ZeroMemory(size, 100);
    if (first.find("GET") < 0)
    {
        cout << "Method not defined" << endl;
        string msg = "Error 405 Method not defined";
        _itoa(msg.size(), size, 10);
        strcat(output, "HTTP/1.1 405 Method not defined\r\n");
        strcat(output, "Content-Length: ");
        strcat(output, size);
        strcat(output, "\r\nContent-Type: text/plain\r\n\r\n");
        strcat(output, msg.c_str());
        outputSize = strlen(output);
    }
    if (first.find("HTTP/1.1") < 0)
    {
        cout << "Wrong http version" << endl;
        string msg = "Error 505 Wrong http version";
        _itoa(msg.size(), size, 10);
        strcat(output, "HTTP/1.1 505 Wrong http version\r\n");
        strcat(output, "Content-Length: ");
        strcat(output, size);
        strcat(output, "\r\nContent-Type: text/plain\r\n\r\n");
        strcat(output, msg.c_str());
        outputSize = strlen(output);
    }
    string name = first.substr(first.find("/") + 1, first.find("HTTP/1.1") - first.find("/") - 2);

    char path[100];
    ZeroMemory(path, 100);
    strcat(path, "C:\\Users\\stefa\\Desktop\\RM\\HTTPServer\\");
    strcat(path, name.c_str());
    cout << "File requested: " << path << endl;
    FILE *f = fopen(path, "rb"); // fstream neće... nzm zašto

    if (f)
    {
        fseek(f, 0, SEEK_END);
        int fSize = ftell(f);
        _itoa(fSize, size, 10);
        rewind(f);

        strcat(output, "HTTP/1.0 200 OK\r\n");
        strcat(output, "Connection: close\r\n");
        strcat(output, "Content-Length: ");
        strcat(output, size);
        cout << "Content-Length: " << size << endl;
        strcat(output, "\r\nContent-Type: image/jpg\r\n\r\n");
        cout << "Header size: " << strlen(output) << endl;
        outputSize = strlen(output) + fSize;
        fread(output, fSize, 1, f);
        fclose(f);
    }
    else
    {
        cout << "File not found" << endl;
        string msg = "Error 404 File not found";
        _itoa(msg.size(), size, 10);
        strcat(output, "HTTP/1.1 404 File not found\r\n");
        strcat(output, "Content-Length: ");
        strcat(output, size);
        strcat(output, "\r\nContent-Type: text/plain\r\n\r\n");
        strcat(output, msg.c_str());
        outputSize = strlen(output);
    }
}
int main(int argc, char **argv)
{
    WSADATA data;
    if (WSAStartup(0x0202, &data) != 0)
        exit(990);
    SOCKET listening = socket(AF_INET, SOCK_STREAM, 0);
    if (listening == -1)
        exit(991);

    sockaddr_in server;
    server.sin_family = AF_INET;
    server.sin_port = htons(SERVER_PORT);
    server.sin_addr.S_un.S_addr = inet_addr(SERVER_ADDRESS);
    //inet_pton(AF_INET, SERVER_ADDRESS, &server.sin_addr);

    if (bind(listening, (sockaddr *)&server, sizeof(server)) == -1)
        exit(992);

    if (listen(listening, MAX_CONN) == -1)
        exit(993);

    SOCKET client;
    sockaddr_in clientInfo;
    int size = sizeof(clientInfo);
    int bytesIn, bytesOut, bytesForSend;

    char recvBuffer[BUFF_SIZE];
    char *sendBuffer;

    while (true)
    {
        cout << "Accepting connection on " << SERVER_ADDRESS << ":" << SERVER_PORT << endl;
        client = accept(listening, (sockaddr *)&clientInfo, &size);
        if (client == -1)
            break;

        while (true)
        {
            ZeroMemory(recvBuffer, BUFF_SIZE);
            bytesIn = recv(client, recvBuffer, BUFF_SIZE, 0);
            if (bytesIn <= 0)
                break;

            cout << "NEW REQUEST\n"
                 << recvBuffer << endl;
            sendBuffer = new char[INT32_MAX]; // Moralo je ovako jer bytes u string-u ne funkcionišu?....
            ZeroMemory(sendBuffer, INT32_MAX);
            processData(recvBuffer, bytesIn, sendBuffer, bytesForSend);

            cout << "Bytes to send: " << bytesForSend << endl;
            bytesOut = send(client, sendBuffer, bytesForSend, 0);
            if (bytesOut < 0)
                break;

            if (sendBuffer)
            {
                delete sendBuffer;
                sendBuffer = nullptr;
            }
        }
        cout << "Broken communication!" << endl;
    }
    cout << "Broken connection" << endl;
    closesocket(listening);
    WSACleanup();

    return 0;
}
