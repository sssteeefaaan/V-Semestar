#include <iostream>
#include <winsock2.h>
#include <string>
#include <sstream>
#include <fstream>
#include <vector>

#pragma comment(lib, "lws2_32.lib")
using namespace std;

#define SERVER_PORT 80
#define PATH "C:\\Users\\stefa\\Desktop\\RM\\HTTPClient\\"

vector<string> splitString(const string &s1, char breakChar)
{
    vector<string> ret;
    string temp = "";
    int i = 0, size = s1.size();
    while (i < size)
    {
        if (s1[i] == breakChar)
        {
            ret.push_back(temp);
            temp = "";
        }
        else
            temp += s1[i];
        i++;
    }
    ret.push_back(temp);
    return ret;
}
int main(int argc, char **argv)
{
    string serverAddress, serverLink;
    cout << "Input server's ip address:" << endl;
    getline(cin, serverAddress);

    cout << "Input the link:" << endl;
    getline(cin, serverLink);

    WSADATA data;
    if (WSAStartup(0x0202, &data) != 0)
        exit(999);

    SOCKET client = socket(AF_INET, SOCK_STREAM, 0);

    sockaddr_in server;
    server.sin_family = AF_INET;
    server.sin_port = htons(SERVER_PORT);
    server.sin_addr.S_un.S_addr = inet_addr(serverAddress.c_str());

    if (connect(client, (sockaddr *)&server, sizeof(server)) == -1)
        exit(998);

    vector<string> link = splitString(serverLink, '/');
    string host = link[0];
    string location = "";
    int linkSize = link.size();
    int i = 1;
    while (i < linkSize)
        location += "/" + link[i++];
    string extension = link[linkSize - 1].substr(link[linkSize - 1].find("."));

    ostringstream ss;
    ss << "GET "
       << location
       << " HTTP/1.1\r\n"
       << "Host: "
       << host
       << "\r\n"
       //"If-Modified-Since: Sat, 10 Nov 2018 00:00:00 GMT\r\n";
       //<< "If-Modified-Since: Thu, 10 Nov 2020 00:00:00 GMT\r\n";
       // << "Connection: close\r\n"
       // << "User-agent: Mozilla/5.0\r\n"
       // << "Accept: application/pdf, text/html, image/gif, image/jpeg\r\n";
       // << "Accept-language: en\r\n";
       << "\r\n";

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
        string infoPath = PATH;
        infoPath += "info.txt";
        int infoEnd = recv.find("\r\n\r\n");

        fstream fInfo(infoPath, ios::trunc | ios::out);
        if (fInfo.good())
        {
            fInfo.write(recvBuffer, infoEnd);
            fInfo.close();
        }
        else
            cout << "Didn't open " << infoPath << endl;

        string status = recv.substr(0, recv.find("\r\n"));
        if (status.compare("HTTP/1.1 200 OK") == 0)
        {
            string dataPath = PATH;
            dataPath += "data" + extension;
            int dataBegin = infoEnd + 4;
            fstream fData(dataPath.c_str(), ios::binary | ios::trunc | ios::out);
            if (fData.good())
            {
                fData.write(recvBuffer + dataBegin, bytesIn - dataBegin);
                fData.close();
            }
            else
                cout << "Didn't open " << dataPath << endl;
        }
        else
            cout << "Error code!" << endl
                 << status << endl;
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