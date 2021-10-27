// Datavodi
#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <string.h>
#include <sys/wait.h>

int main()
{
    int descriptor[2];
    int pid;
    char buffer[255];

    if (pipe(descriptor) < 0)
        exit(1);

    pid = fork();

    if (!pid)
    {
        close(descriptor[1]);
        printf("Child process here:\n");
        sprintf(buffer, "%d", descriptor[0]);
        execl("child", "child", buffer, NULL);
    }
    else
    {
        printf("Roditelj ovde: Unesite tekst koji želite proslediti mom detetu:\n");
        close(descriptor[0]); // ZATVORI ČITANJE
        fgets(buffer, 255, stdin);
        write(descriptor[1], buffer, strlen(buffer) + 1);
        wait(NULL);
        close(descriptor[1]);
        printf("Roditelj je gotov!\n");
    }
}