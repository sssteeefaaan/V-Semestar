// Imeplementacija ls | more

#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>

int main(int argc, char *argv[])
{
    int descriptor[2];
    int pid;

    if (pipe(descriptor) < 0)
        exit(1);

    pid = fork();

    if (!pid)
    {
        close(1);
        dup(descriptor[1]);
        execlp("ls", "ls", NULL);
    }
    else
    {
        close(0);
        dup(descriptor[0]);
        execlp("more", "more", NULL);
    }
}