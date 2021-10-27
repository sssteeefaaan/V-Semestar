#include <stdio.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/msg.h>
#include <unistd.h>
#include <sys/wait.h>

#define MSG_KEY 12345

int main(int argc, char* argv[])
{
    int messageID, pid1, pid2;
    
    messageID = msgget(MSG_KEY, IPC_CREAT | 0666);
    
    pid1 = fork();
    
    if(!pid1)
    {
        execlp(argv[1], argv[1], "unos", NULL);
        printf("Doslo je do greske!\n");
        return -1;
    }
    
    pid2 = fork();
    
    if(!pid2)
    {
        execlp(argv[1], argv[1], "izlaz", NULL);
        printf("Doslo je do greske!\n");
        return -1;
    }
    
    waitpid(pid1, NULL, 0);
    waitpid(pid2, NULL, 0);
    
    return 0;
}
