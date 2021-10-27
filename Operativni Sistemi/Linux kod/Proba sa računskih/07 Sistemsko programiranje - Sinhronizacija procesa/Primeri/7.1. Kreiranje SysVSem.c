#include <stdio.h>
#include <stdlib.h>
#include <sys/sem.h>

int main()
{
    int sid;

    sid = semget((key_t)333, 1, 0666 | IPC_CREAT);
    if (sid < 0)
    {
        perror("Greškaprilikom kreiranja semafora 333.\n");
        exit(1);
    }
    return 0;
}