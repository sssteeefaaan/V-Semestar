#define _WINSOCK_DEPRECATED_NO_WARNINGS
#define _CRT_SECURE_NO_WARNINGS

#include <winsock2.h>
#include <iostream>
#include <string>
#include <sstream>
#include <vector>
#include <fstream>
#include <ws2tcpip.h>
#include <thread>

#pragma comment(lib, "ws2_32.lib")
using namespace std;

#define SERVER_PORT 80
#define SERVER_ADDRESS "127.0.0.1"
#define MAX_N0_CONNECTIONS 5
#define PATH (string) "C:\\Users\\stefa\\Desktop\\RM\\HTTPServer\\"

void fulfillRequest(SOCKET *client, char *request, int size);
void badRequest(SOCKET *client, const string &msg);
void sendContent(SOCKET *client, char *data, int size, const string &type);
void handleComms(SOCKET *client, sockaddr_in *clientInfo, int *clientSize);
void exitWithError(const string &error, SOCKET *listen = nullptr);

int main()
{
    WSADATA data;
    WORD version = MAKEWORD(2, 2);

    if (WSAStartup(version, &data) != 0)
        exitWithError("Coudln't specify the window socket!");
    cout << "[SERVER] Successfully specified window socket to version 0x0202" << endl;

    SOCKET listening = socket(AF_INET, SOCK_STREAM, 0);
    if (listening == -1)
        exitWithError("Coudln't create the listening socket!");
    cout << "[SERVER] Successfully created server's listening socket!" << endl;

    sockaddr_in server;
    server.sin_family = AF_INET;
    server.sin_port = htons(SERVER_PORT);
    server.sin_addr.S_un.S_addr = inet_addr(SERVER_ADDRESS);

    if (bind(listening, (sockaddr *)&server, sizeof(server)) == -1)
        exitWithError("Coudln't bind the listening socket!", &listening);
    cout << "[SERVER] Successfully bound the server's listening socket to address " << SERVER_ADDRESS << ":" << SERVER_PORT << endl;

    if (listen(listening, MAX_N0_CONNECTIONS) == -1)
        exitWithError("Coudln't initialize the listening!", &listening);
    cout << "[SERVER] Listening on " << SERVER_ADDRESS << ":" << std::to_string(SERVER_PORT) << endl;

    SOCKET *client;
    sockaddr_in *clientInfo;
    int *clientSize;

    vector<thread *> coms;
    string esc;

    while (true)
    {
        clientInfo = new sockaddr_in();
        clientSize = new int(sizeof(sockaddr_in));
        client = new SOCKET(accept(listening, (sockaddr *)clientInfo, clientSize));

        if (*client == -1)
        {
            cout << "Client socket error!" << endl;
            //continue;

            cout << "Do you want to shut down the server?\n"
                 << endl;
            getline(cin, esc);
            if (esc.find("y") >= 0 || esc.find("Y") >= 0)
            {
                cout << "Server is shutting down..." << endl;
                break;
            }
        }

        coms.push_back(new thread(handleComms, client, clientInfo, clientSize));
    }

    if (client)
    {
        delete client;
        client = nullptr;
    }
    if (clientSize)
    {
        delete clientSize;
        clientSize = nullptr;
    }
    if (clientInfo)
    {
        delete clientInfo;
        clientInfo = nullptr;
    }

    int size = coms.size();
    for (int i = 0; i < size; i++)
    {
        if (coms[i])
        {
            coms[i]->join();
            delete coms[i];
            coms[i] = nullptr;
        }
    }
    coms.clear();

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

    FILE *f = nullptr;
    f = fopen((PATH + path).c_str(), "rb");

    if (f)
    {
        fseek(f, 0, ios::end);
        int contentSize = ftell(f);
        rewind(f);

        char *data = new char[contentSize];
        memset(data, 0, contentSize);
        fread(data, 1, contentSize, f);

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
    ss << "HTTP/1.0 200 OK\r\n"
       << "Connection: close\r\n"
       //<< "Accept-Ranges: bytes\r\n"
       << "Content-Length: " << std::to_string(sizeof(char) * size) << "\r\n"
       //<< "Connection: Keep-Alive\n"
       << "Content-Type: image/jpeg\r\n" //, image/gif, image/png\r\n"// << type << "\r\n"
       << "\r\n";

    // cout << ss.str() << endl;

    int bytesOut = send(*client, ss.str().c_str(), ss.str().size(), 0);
    if (bytesOut < ss.str().size())
        cout << "Didn't send all of data!" << endl;
    else
    {
        bytesOut = send(*client, data, size, 0);
        if (bytesOut < size)
            cout << "Didn't send all of data!" << endl;
    }
}

void badRequest(SOCKET *client, const string &msg)
{
    ostringstream ss;
    ss << "HTTP/1.0 " << msg << "\r\n"
       << "Content-Type: text/plain\r\n"
       << "Content-Length: " << msg.size() << "\r\n"
       << "\r\n"
       << msg;

    string message = ss.str();
    if (message.size() < send(*client, message.c_str(), message.size(), 0))
        cout << "BadRequest: sending failed!" << endl;
}

void handleComms(SOCKET *client, sockaddr_in *clientInfo, int *clientSize)
{
    int bytesIn, bytesOut;

    char host[20], port[20];
    memset(host, 0, 20);
    memset(port, 0, 20);
    string sendBuffer;

    getnameinfo((sockaddr *)clientInfo, *clientSize, host, 20, port, 20, 0);
    cout << "[SERVER] " << host << ":" << port << " connected." << endl;

    char *recvBuffer = new char[INT16_MAX];
    while (true)
    {

        memset(recvBuffer, 0, INT16_MAX);
        bytesIn = recv(*client, recvBuffer, INT16_MAX, 0);

        if (bytesIn <= 0)
        {
            cout << "[SERVER] " << host << ":" << port << " has disconnected!" << endl;
            break;
        }
        fulfillRequest(client, recvBuffer, bytesIn);
    }
    if (recvBuffer)
    {
        delete[] recvBuffer;
        recvBuffer = nullptr;
    }
    if (client)
    {
        delete client;
        client = nullptr;
    }
    if (clientSize)
    {
        delete clientSize;
        clientSize = nullptr;
    }
    if (clientInfo)
    {
        delete clientInfo;
        clientInfo = nullptr;
    }
}

void exitWithError(const string &error, SOCKET *listen)
{
    if (listen)
    {
        closesocket(*listen);
    }
    cout << "[ERROR OCCURRED] " << error << endl
         << "[WS ERROR] " << WSAGetLastError() << endl;
    WSACleanup();
    exit(999);
}