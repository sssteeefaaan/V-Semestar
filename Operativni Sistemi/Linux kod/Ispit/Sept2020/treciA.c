#include <stdio.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/msg.h>
#include <unistd.h>
#include <string.h>
#include <sys/wait.h>

#define MSG_KEY 12345
#define MAX_SIZE 1024

struct data
{
    long help;
    char content[MAX_SIZE];
};

int main(int argc, char* argv[])
{
    if(argc < 2)
        return -1;
    
    int messageID = msgget(MSG_KEY, 0666);
    struct data msg;
    
    if(strcmp(argv[1], "unos") == 0)
    {
        // Input process
        while(1)
        {
            memset(msg.content, '\0', MAX_SIZE);
            scanf("%s", msg.content);   // string
            // fgets(buffer, MAX_SIZE, stdin);  // line
            // fread(buffer, sizeof(char), MAX_SIZE, stdin);    // everything, which is a line at max
            msgsnd(messageID, &msg, strlen(msg.content) + 1, 0);
            
            if(strcmp(msg.content, "KRAJ") == 0)
                break;
        }
        return 0;
    }
    else if(strcmp(argv[1], "izlaz") == 0)
    {
        // Output process
        
        while(1)
        {
            memset(msg.content, '\0', MAX_SIZE);
            msgrcv(messageID, &msg, MAX_SIZE, 0, 0);
            
            if(strcmp(msg.content, "KRAJ") == 0)
                break;
            
            printf("Drugi proces: %s\n", msg.content);
        }
        
        return 0;
    }
    
    printf("Greska! Nije prepoznat tip funkcionalnosti!\n");
    return -2;
}
