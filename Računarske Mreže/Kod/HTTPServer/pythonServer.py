import socket as sock
import os as os

SERVER_ADDR = "127.0.0.1"
SERVER_PORT = 80
MAX_CONN = 5
PATH = os.path.dirname(os.path.abspath(__file__))

listening = sock.socket(sock.AF_INET, sock.SOCK_STREAM)
listening.bind((SERVER_ADDR, SERVER_PORT))
listening.listen(MAX_CONN)

while True:
    (clientSocket, address) = listening.accept()
    request = str(clientSocket.recv(2056), 'utf-8')
    print(request)
    line = request.split("\n")
    imp = line[0].split(" ")
    if imp[0] != "GET":
        clientSocket.send(bytes("405 Wrong method ${imp[0]}", 'utf-8'))
    elif not imp[2].__contains__("HTTP/1.1"):
        clientSocket.send(bytes("505 Bad HTTP version ${imp[2]}", 'utf-8'))
    elif imp[1]=="/QUIT":
        clientSocket.send(bytes("Congrats! You've disconnected!",'utf-8'))
        break
    else:
        try:
            f = open(os.path.join(PATH,imp[1].removeprefix("/")), "rb")
            content = f.read()
            clientSocket.send(content)
        except:
            clientSocket.send(bytes("404 Bad Request", 'utf-8'))


listening.close()