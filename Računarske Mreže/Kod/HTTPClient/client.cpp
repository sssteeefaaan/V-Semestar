#include <iostream>
#include <winsock2.h>
#include <string>
#include <sstream>
#include <fstream>

#pragma comment(lib, "lws2_32.lib")
using namespace std;

#define SERVER_PORT 80
#define SERVER_ADDR "147.91.185.67"
#define PATH "C:\\Users\\stefa\\Desktop\\RM\\HTTPClient\\"

int main(int argc, char **argv)
{
    WSADATA data;
    if (WSAStartup(0x0202, &data) != 0)
        exit(999);

    SOCKET client = socket(AF_INET, SOCK_STREAM, 0);

    sockaddr_in server;
    server.sin_family = AF_INET;
    server.sin_port = htons(SERVER_PORT);
    server.sin_addr.S_un.S_addr = inet_addr(SERVER_ADDR);

    if (connect(client, (sockaddr *)&server, sizeof(server)) == -1)
        exit(998);

    ostringstream ss;
    ss << "GET /wp-content/uploads/2019/08/javni-konkurs.docx HTTP/1.1\r\n"
       << "Host: www.mpn.gov.rs\r\n\r\n";
    // << "Connection: close\r\n"
    // << "User-agent: Mozilla/5.0\r\n"
    // << "Accept: application/pdf, text/html, image/gif, image/jpeg\r\n";
    // << "Accept-language: en\r\n\r\n";

    int bytesOut,
        bytesIn;
    if (send(client, ss.str().c_str(), ss.str().size(), 0) < ss.str().size())
        cout << "Failed to send!" << endl;

    char *recvBuffer = new char[INT32_MAX];
    memset(recvBuffer, '\0', INT32_MAX);
    bytesIn = recv(client, recvBuffer, INT32_MAX, 0);
    if (bytesIn <= 0)
        cout << "Recv failed!" << endl;
    else
    {
        string recv(recvBuffer, bytesIn);
        string infoPath = PATH, dataPath = PATH;
        infoPath += "info.txt";
        dataPath += "data.docx";
        int infoEnd = recv.find("\r\n\r\n");
        int dataBegin = infoEnd + 4;

        fstream fInfo(infoPath, ios::trunc | ios::out);
        if (fInfo.good())
        {
            fInfo.write(recvBuffer, infoEnd);
            fInfo.close();
        }
        else
            cout << "Didn't open " << infoPath << endl;

        fstream fData(dataPath.c_str(), ios::binary | ios::trunc | ios::out);
        if (fData.good())
        {
            fData.write(recvBuffer + dataBegin, bytesIn - dataBegin);
            fData.close();
        }
        else
            cout << "Didn't open " << dataPath << endl;
    }
    if (recvBuffer)
    {
        delete recvBuffer;
        recvBuffer = nullptr;
    }

    closesocket(client);
    WSACleanup();
    system("pause");
    return 0;
}