#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <sys/types.h>
#include <sys/file.h>
#include <sys/wait.h>
#include <string.h>

#define MAX_SIZE 512

int main(int argc, char* argv[])
{
    if(argc < 3)
        return -1;
    
    int datavod[2], pid;
    
    pipe(datavod);
    pid = fork();
    
    if(!pid)
    {
        // Dete
        close(datavod[0]);
        dup2(datavod[1], 1);
        execlp(argv[1], argv[1], NULL);
        return -1;
    }
    
    // Roditelj
    close(datavod[1]);
    
    int fileDescriptor = open(argv[2], O_CREAT | O_TRUNC | O_RDWR, 0666);
    
    dup2(datavod[0], fileDescriptor);
    waitpid(pid, NULL, 0);
    return 0;
}
