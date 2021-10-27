#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <sys/types.h>
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
    
    int i, count;
    char * buffer = (char*) malloc(sizeof(char) * MAX_SIZE);
    FILE *f = fopen(argv[2], "w");
    if(!f)
        exit(-1);
    
    while(1)
    {
        memset(buffer, '\0', MAX_SIZE);
        count = read(datavod[0], buffer, MAX_SIZE);
        if(count == 0)
            break;
        for(i = 0; i < count ; i++)
            if(buffer[i] == 'b')
                buffer[i] = 'B';
        buffer[count] = '\0';
        
        fprintf(f, "%s", buffer);
    }
    
    free(buffer);
    waitpid(pid, NULL, 0);
    close(datavod[0]);
    return 0;
}
