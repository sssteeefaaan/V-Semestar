#include <sys/types.h>
#include <sys/ipc.h>
#include <sys/sem.h>
#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>

union semun
{
    int val;
    struct semid_ds *buf;
    ushort *array;
    struct seminfo *_buf;
    void *_pad;
};

#define MUTEX_KEY 10101
#define EMPTY_KEY 10102
#define FULL_KEY 10103
#define N 10

int main()
{
    int mutexid, emptyid, fullid;
    union semun semopts;

    // Kreiranje semafora
    mutexid = semget((key_t)MUTEX_KEY, 1, 0666 | IPC_CREAT);
    emptyid = semget((key_t)EMPTY_KEY, 1, 0666 | IPC_CREAT);
    fullid = semget((key_t)FULL_KEY, 1, 0666 | IPC_CREAT);

    // Incijalizacija semafora
    semopts.val = 1;
    semctl(mutexid, 0, SETVAL, semopts);
    semopts.val = N;
    semctl(emptyid, 0, SETVAL, semopts);
    semopts.val = 0;
    semctl(fullid, 0, SETVAL, semopts);

    // Pokretanje proizvođača
    if (fork() == 0)
        execl("Producer", "Producer", NULL);

    // Pokretanje konzumera
    if (fork() == 0)
        execl("Consumer", "Consumer", NULL);

    wait(NULL);
    wait(NULL);

    // Brisanje semafora
    semctl(mutexid, 0, IPC_RMID, 0);
    semctl(emptyid, 0, IPC_RMID, 0);
    semctl(fullid, 0, IPC_RMID, 0);

    return 0;
}