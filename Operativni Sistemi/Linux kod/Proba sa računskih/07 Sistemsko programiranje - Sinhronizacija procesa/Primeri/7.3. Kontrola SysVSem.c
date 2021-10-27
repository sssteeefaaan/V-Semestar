#include <stdio.h>
#include <stdlib.h>
#include <sys/sem.h>
#include <sys/types.h>
#include <sys/ipc.h>

union semun
{
    int val;
    struct semid_ds *buf;
    ushort *array;
    struct seminfo *_buf;
    void *_pad;
};

int main()
{
    int sid;
    union semun semopts;
    semopts.val = 1;

    sid = semget((key_t)333, 1, 0666 | IPC_CREAT);

    if (sid < 0)
    {
        perror("Greška prilikom kreiranja semafora 333.\n");
        exit(1);
    }

    //...

    if (semctl(sid, 0, SETVAL, semopts) == -1)
    {
        perror("Greška prilikom postavljanja vrednosti semafora.\n");
        exit(1);
    }

    //...

    semctl(sid, 0, IPC_RMID, 0);
}