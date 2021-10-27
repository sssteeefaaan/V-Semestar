#pragma once
#include <WS2tcpip.h>
#pragma comment(lib, "ws2_32.lib")

#include <vector>
#include <string>
#include <iostream>

class MailBox
{
private:
	SOCKET* client; // Prosleđujem pointer
	std::string username;
	std::string password;
	std::vector<std::string*> messages; //string[0] from, string[1] data

public:
	MailBox(SOCKET* client = nullptr)
		:client(client) {}
	virtual ~MailBox() {
		for (std::string* msg : messages)
		{
			if (msg)
			{
				delete[] msg;
				msg = nullptr;
			}
		}
		messages.clear();
	}

	void setClient(SOCKET* client) { this->client = client; }
	void setUser(std::string username) { this->username = username; }
	void setPass(std::string pass) { this->password = pass; }
	void addNewMessage(std::string from, std::string data)
	{
		std::string* message = new std::string[2];
		message[0] = from; message[1] = data;
		this->messages.push_back(message);
	}
	std::vector<std::string*> getMessagesFrom(std::string user)
	{
		std::vector<std::string*> ret;
		for (std::string* msg : messages)
			if (msg[0].compare(user) == 0)
				ret.push_back(msg);
		return ret;
	}
	std::string* getFromAllMessagesAt(int i) const { return messages[i]; }
	void delFromAllMessagesAt(int i) { messages.erase(messages.begin() + i); }
	SOCKET* getClient() const { return this->client; }
	std::string getUser()const { return this->username; }
	std::string getPassword() const { return this->password; }
	std::vector<std::string*> getAllMessages() const { return this->messages; }
	long getNumberOfMessages() const { return this->messages.size(); }
};

