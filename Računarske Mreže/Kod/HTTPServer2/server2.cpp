#define _WINSOCK_DEPRECATED_NO_WARNINGS
#define _CRT_SECURE_NO_WARNINGS

#include <winsock2.h>
#include <iostream>
#include <string>
#include <sstream>
#include <vector>
#include <fstream>

#pragma comment(lib, "ws2_32.lib")
using namespace std;

#define SERVER_PORT 80
#define SERVER_ADDRESS "127.0.0.1"
#define MAX_N0_CONNECTIONS 5
#define PATH (string) "C:\\Users\\stefa\\Desktop\\RM\\HTTPServer2\\"

void fulfillRequest(SOCKET *client, char *request, int size);
void badRequest(SOCKET *client, const string &msg);
void sendContent(SOCKET *client, char *data, int size, const string &type);

int main()
{
    WSADATA data;
    WORD version = MAKEWORD(2, 2);

    if (WSAStartup(version, &data) != 0)
        exit(99);

    SOCKET listening = socket(AF_INET, SOCK_STREAM, 0);
    if (listening == -1)
        exit(98);

    sockaddr_in server;
    server.sin_family = AF_INET;
    server.sin_port = htons(SERVER_PORT);
    server.sin_addr.S_un.S_addr = inet_addr(SERVER_ADDRESS);

    if (bind(listening, (sockaddr *)&server, sizeof(server)) == -1)
        exit(97);

    if (listen(listening, MAX_N0_CONNECTIONS) == -1)
        exit(96);

    cout << "SERVER is listening on: " << SERVER_ADDRESS << ":" << std::to_string(SERVER_PORT) << endl;

    SOCKET client;
    sockaddr_in clientInfo;
    int clientSize = sizeof(clientInfo);
    int bytesIn, bytesOut, sendSize;

    char *recvBuffer = new char[INT16_MAX];
    string sendBuffer;

    while (true)
    {
        client = accept(listening, (sockaddr *)&clientInfo, &clientSize);

        if (client == -1)
        {
            cout << "Client socket error!" << endl;
            continue;
        }

        bytesIn = recv(client, recvBuffer, INT16_MAX, 0);
        if (bytesIn < 0)
        {
            cout << "Nothing's recieved!" << endl;
            continue;
        }

        cout << recvBuffer << endl;

        char *sendBuffer = (char *)malloc(sizeof(char) * INT32_MAX);
        ZeroMemory(sendBuffer, INT32_MAX);

        FILE *f = fopen((PATH + "Nadoknada.pdf").c_str(), "rb");
        if (f)
        {
            fseek(f, 0, ios::ate);
            int size = ftell(f);
            char *data = new char[size];
            ZeroMemory(data, size);
            fseek(f, 0, ios::beg);

            fread(data, size, 1, f);
            fclose(f);

            strcat(sendBuffer, "HTTP/1.1 200 OK\r\n");
            strcat(sendBuffer, "Content-Length: ");
            strcat(sendBuffer, std::to_string(size).c_str());
            strcat(sendBuffer, "\r\n");
            strcat(sendBuffer, "Content-Type: application/pdf\r\n\r\n");
            cout << "START\n"
                 << sendBuffer << endl;
            sendSize = strlen(sendBuffer) + size;
            strcat(sendBuffer, data);

            if (data)
            {
                delete[] data;
                data = nullptr;
            }
        }
        else
        {
            strcat(sendBuffer, "HTTP/1.1 404 Bad Request\r\nContent-Type: text/plain\r\n\r\n404 File not found!");
            cout << sendBuffer << endl;
            sendSize = strlen(sendBuffer);
        }

        bytesOut = send(client, sendBuffer, sendSize, 0);
        if (bytesOut < sendSize)
            break;

        if (sendBuffer)
        {
            delete[] sendBuffer;
            sendBuffer = nullptr;
        }

        //fulfillRequest(&client, recvBuffer, bytesIn);
    }

    closesocket(listening);
    WSACleanup();
    return 0;
}

void fulfillRequest(SOCKET *client, char *request, int size)
{
    string req(request, size);
    req = req.substr(0, req.find("\n"));
    if (req.find("HTTP/1.1") < 0)
        badRequest(client, "505 Wrong http version");

    string path = req.substr(req.find("/") + 1, req.find("HTTP") - req.find("/") - 2);

    FILE *f;
    f = fopen((PATH + path).c_str(), "rb");

    if (f)
    {
        fseek(f, 0, ios::end);
        int contentSize = ftell(f);
        fseek(f, 0, ios::beg);

        char *data = new char[contentSize];
        memset(data, '\0', contentSize);
        fread(data, 1, contentSize, f);

        FILE *fcopy = fopen((PATH + "copy.jpg").c_str(), "wb");
        if (fcopy)
        {
            fwrite(data, 1, contentSize, fcopy);
            fclose(fcopy);
        }

        sendContent(client, data, contentSize, path.substr(path.find(".") + 1));

        if (data != 0)
        {
            delete[] data;
            data = nullptr;
        }

        fclose(f);
    }
    else
        badRequest(client, "404 File not found");
}

void sendContent(SOCKET *client, char *data, int size, const string &type)
{
    ostringstream ss;
    ss << "HTTP/1.1 200 OK\r\n"
       << "Access-Control-Allow-Origin: *"
       << "Content-Type: image/" << type << "\r\n"
       << "Content-Length: " << size << "\r\n"
       << "\r\n";

    int sendBufferSize = ss.str().size() + size;
    char *sendBuffer = new char[sendBufferSize];
    memset(sendBuffer, '\0', sendBufferSize);
    strcpy(sendBuffer, ss.str().c_str());
    strcat(sendBuffer + ss.str().size(), data);

    int bytesOut = send(*client, sendBuffer, sendBufferSize, 0);
    if (bytesOut < sendBufferSize)
    {
        cout << "Didn't send all data!" << endl;
    }

    if (sendBuffer != 0)
    {
        delete[] sendBuffer;
        sendBuffer = nullptr;
    }
}

void badRequest(SOCKET *client, const string &msg)
{
    ostringstream ss;
    ss << "HTTP/1.1 " << msg << "\r\n"
       << "Content-Type: text/html\r\n"
       << "Content-Length: " << msg.size() << "\r\n"
       << "\r\n"
       << "<html>\n"
       << "<head>\n"
       << "<meta charset='utf-8'>\n"
       << "<title>Message</title>\n"
       << "</head>\n"
       << "<body>\n"
       << "<h1>" << msg << "</h1>\n"
       << "</body>\n"
       << "</html>\n";

    string message = ss.str();
    if (message.size() < send(*client, message.c_str(), message.size(), 0))
        cout << "BadRequest sending failed!" << endl;
}