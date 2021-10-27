#include <stdio.h>
#include <stdlib.h>
#include <sys/types.h>
#include <unistd.h>
#include <pthread.h>
#include <semaphore.h>

#define N 10

sem_t mux;
sem_t full;
sem_t empty;
int buffer[N];
void *producer(void *args);
void *consumer(void *args);

int main()
{
    pthread_t prod, cons;

    sem_init(&mux, 0, 1);
    sem_init(&full, 0, 0);
    sem_init(&empty, 0, N);

    pthread_create(&prod, NULL, (void *)&producer, NULL);
    pthread_create(&cons, NULL, (void *)&consumer, NULL);

    pthread_join(prod, NULL);
    pthread_join(cons, NULL);

    sem_destroy(&mux);
    sem_destroy(&full);
    sem_destroy(&empty);

    return 0;
}

void *producer(void *args)
{
    int i;
    for (i = 0; i < 10; i++)
    {
        sem_wait(&empty);
        sem_wait(&mux);
        buffer[i] = (i + 5) * 5;
        printf("Produced: %d\n", buffer[i]);
        sem_post(&mux);
        sem_post(&full);
    }
}

void *consumer(void *args)
{
    int i;
    for (i = 0; i < 10; i++)
    {
        sem_wait(&full);
        sem_wait(&mux);
        printf("Consumed: %d\n", buffer[i]);
        buffer[i] = 0;
        sem_post(&mux);
        sem_post(&empty);
    }
}