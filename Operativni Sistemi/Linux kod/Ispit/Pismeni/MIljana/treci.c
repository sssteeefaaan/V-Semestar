#include <stdio.h>
#include <unistd.h>
#include <sys/types.h>
#include <unistd.h>
#include <stdlib.h>
#include <signal.h>
#include <string.h>
// NE VALJA!

void handle1()
{
    int j, number;
    FILE* f;
    f = fopen("fajl.dat", "r");
    if(f){
        for(j = 0; j < 20; j++){
            fscanf(f, "%d", &number);
            printf("%d\n", number);
            fflush(stdout);
        }
        printf("\n");
        fclose(f);
        return;
    }
    printf("Greska prilikom otvaranja %s!\n", "fajl.dat");
    exit(-1);
}

void handle2()
{
    int j;
    FILE* f;
    f = fopen("fajl.dat", "w");
    if(f){
        for(j = 0; j < 20; j++)
            fprintf(f, "%d\n", rand()%100);
        fclose(f);
        return;
    }
    
    printf("Greska prilikom otvaranja %s!\n", "fajl.dat");
    exit(-1);
}

int main(int argc, char* argv[])
{
    int pid, ppid;
    int i, j;
    FILE* f;
    char buffer[100];
    signal(SIGUSR1, handle1);
    signal(SIGUSR2, handle2);
    
    pid = fork();
    
    if(pid == 0)
    {
        // pause();
        ppid = getppid();
        for(i = 0; i < 10; i++)
        {
            if(kill(ppid, SIGUSR1) == -1)
                exit(-1);
            pause();
        }
        return 0;
    }
    
    for(i = 0; i < 10; i++)
    {
        if(kill(pid, SIGUSR2) == -1)
            exit(-1);
        
        pause();
    }
    
    return 0;
}
