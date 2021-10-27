#include <stdio.h>
#include <stdlib.h>
#include <sys/types.h>
#include <semaphore.h>
#include <pthread.h>
#include <unistd.h>

#define BUFF_SIZE 100

char b[BUFF_SIZE];
int in, out, i = 1;
sem_t s, delay;
void *producer(void *args);
void *consumer(void *args);

void *producer(void *args)
{
    while (in < BUFF_SIZE)
    {
        sem_wait(&s);
        b[in] = 'L';
        in++;
        if (in - out == 1)
            sem_post(&delay);
        sem_post(&s);
    }
}

void *consumer(void *args)
{
    sem_wait(&delay);
    char temp;
    int m;
    while (out < BUFF_SIZE)
    {
        sem_wait(&s);
        temp = b[out];
        out++;
        //m = in - out;
        sem_post(&s);
        printf("%d. %c\n", i, temp);
        i = i + 1;
        if (/*m*/ in - out == 0 && out < BUFF_SIZE)
            sem_wait(&delay);
    }
}

int main()
{
    pthread_t proc, cons;
    in = out = 0;

    sem_init(&s, 0, 1);
    sem_init(&delay, 0, 0);

    pthread_create(&proc, NULL, (void *)&producer, NULL);
    pthread_create(&cons, NULL, (void *)&consumer, NULL);

    pthread_join(proc, NULL);
    pthread_join(cons, NULL);

    sem_destroy(&s);
    sem_destroy(&delay);

    return 0;
}