#define _CRT_SECURE_NO_WARNINGS

#include <iostream>
#include <vector>
#include <sstream>
#include <string>
#include <map>
using namespace std;

unsigned char from_hex(unsigned char ch)
{
    if (ch <= '9' && ch >= '0')
        ch -= '0';
    else if (ch <= 'f' && ch >= 'a')
        ch -= 'a' - 10;
    else if (ch <= 'F' && ch >= 'A')
        ch -= 'A' - 10;
    else
        ch = 0;
    return ch;
}
const std::string urldecode(const std::string &str)
{
    using namespace std;
    string result;
    string::size_type i;
    for (i = 0; i < str.size(); ++i)
    {
        if (str[i] == '+')
        {
            result += ' ';
        }
        else if (str[i] == '%' && str.size() > i + 2)
        {
            const unsigned char ch1 = from_hex(str[i + 1]);
            const unsigned char ch2 = from_hex(str[i + 2]);
            const unsigned char ch = (ch1 << 4) | ch2;
            result += ch;
            i += 2;
        }
        else
        {
            result += str[i];
        }
    }
    return result;
}
vector<string> split(const string &str, char breakChar)
{
    vector<string> ret;
    string temp = "";
    int size = str.size(), i = 0;

    do
    {
        if (str[i] == breakChar)
        {
            ret.push_back(temp);
            temp = "";
        }
        else
            temp += str[i];
        i++;
    } while (i < size);

    ret.push_back(temp);

    return ret;
}
map<string, string> parse(string str)
{
    map<string, string> ret;
    vector<string> keysAndValues = split(str, '&');
    vector<string> keyAndValue;

    string key;
    int size = keysAndValues.size();
    for (int i = 0; i < size; i++)
    {
        keyAndValue = split(keysAndValues[i], '=');
        key = keyAndValue[0];
        ret[key] = keyAndValue[1];
    }
    return ret;
}
void output(const string &msg, const string &title)
{
    ostringstream ss;
    ss << "<html>\n"
       << "<head>\n"
       << "<meta charset='utf8'>\n"
       << "<title>"
       << title
       << "</title>\n"
       << "</head>\n"
       << "<body>\n"
       << msg
       << "</body>\n"
       << "</html>";

    cout << "Content-Type: text/html\r\n"
         << "Content-Length: " << ss.str().size() << "\r\n"
         << "\r\n"
         << ss.str();
}
void processRequest(const string &request)
{
    map<string, string> req = parse(urldecode(request));
    if (req["broj1"].empty())
    {
        output("<h1>Unesite prvi broj!</h1>", "Greska");
        return;
    }
    if (req["broj2"].empty())
    {
        output("<h1>Unesite drugi broj!</h1>", "Greska");
        return;
    }
    if (req["operacija"].empty())
    {
        output("<h1>Unesite operaciju!</h1>", "Greska");
        return;
    }
    int a = stoi(req["broj1"]);
    int b = stoi(req["broj2"]);
    switch (req["operacija"][0])
    {
    case ('+'):
        output("<h1>" + to_string(a) + " + " + to_string(b) + " = " + to_string(a + b) + "</h1>", "Rezultat");
        break;
    case ('-'):
        output("<h1>" + to_string(a) + " + " + to_string(b) + " = " + to_string(a - b) + "</h1>", "Rezultat");
        break;
    case ('*'):
        output("<h1>" + to_string(a) + " + " + to_string(b) + " = " + to_string(a * b) + "</h1>", "Rezultat");
        break;
    case ('/'):
        if (b != 0)
            output("<h1>" + to_string(a) + " + " + to_string(b) + " = " + to_string(a / b) + "</h1>", "Rezultat");
        else
            output("<h1>Drugi broj ne sme biti nula!</h1>", "Greska");
        break;
    default:
        output("<h1>Nedozvoljena operacija!</h1>", "Greska");
        break;
    }
}
int main(int argc, char **argv)
{
    string method = getenv("REQUEST_METHOD");
    string query = getenv("QUERY_STRING");

    if (method == "POST" && !query.empty())
    {
        int length = atoi(getenv("CONTENT_LENGTH"));
        string request;

        getline(cin, request);
        processRequest(request);
    }
    else
        output("<h1>Nastala je greska</h1>\n", "Error");
}