// child
#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <string.h>
#include <sys/wait.h>

int main(int argc, char *argv[])
{
    int descriptor;
    char buffer[255];
    if (argc < 2)
        exit(1);

    descriptor = atoi(argv[1]);

    read(descriptor, buffer, 255);
    printf("%s", buffer);

    close(descriptor);

    printf("Child process ended!\n");
}