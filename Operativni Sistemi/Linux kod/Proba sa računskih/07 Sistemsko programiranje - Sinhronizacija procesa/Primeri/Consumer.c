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
    int mutexid, emptyid, fullid, i;

    struct sembuf sem_lock = {0, -1, 0};
    struct sembuf sem_unlock = {0, 1, 0};

    // Pribavljanje reference semafora
    mutexid = semget((key_t)MUTEX_KEY, 1, 0666);
    emptyid = semget((key_t)EMPTY_KEY, 1, 0666);
    fullid = semget((key_t)FULL_KEY, 1, 0666);

    for (i = 0; i < N; i++)
    {
        semop(fullid, &sem_lock, 1);
        semop(mutexid, &sem_lock, 1);
        printf("Čitanje iz bafera.\n");
        semop(mutexid, &sem_unlock, 1);
        semop(emptyid, &sem_unlock, 1);
    }
    return 0;
}