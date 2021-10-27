#include <stdio.h>
#include <stdlib.h>
#include <sys/sem.h>

int main()
{
    int sid;
    struct sembuf sem_lock = {0, -1, NULL};

    sid = semget((key_t)333, 1, 0666 | IPC_CREAT);

    if (sid < 0)
    {
        perror("Greška prilikom kreiranja semafora 333.\n");
        exit(1);
    }

    //...

    if (semop(sid, &sem_lock, 1) == -1)
    {
        perror("Greška prilikom P operacije.\n");
        exit(1);
    }
    return 0;
}