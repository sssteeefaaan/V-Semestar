#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <pthread.h>

pthread_mutex_t lock;
void *prva_nit(void *args);
void *druga_nit(void *args);

int main()
{
    pthread_t t1, t2;

    pthread_mutex_init(&lock, NULL);

    pthread_create(&t1, NULL, (void *)&prva_nit, NULL);
    //sleep(3);
    pthread_create(&t2, NULL, (void *)&druga_nit, NULL);

    pthread_join(t1, NULL);
    pthread_join(t2, NULL);

    pthread_mutex_destroy(&lock);

    return 0;
}

void *prva_nit(void *args)
{
    pthread_mutex_lock(&lock);
    printf("PrvaNit!\n");
    pthread_mutex_unlock(&lock);
}

void *druga_nit(void *args)
{
    pthread_mutex_lock(&lock);
    printf("DrugaNit!\n");
    pthread_mutex_unlock(&lock);
}
