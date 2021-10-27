#include <stdio.h>
#include <stdlib.h>
#include <pthread.h>
#include <sys/types.h>
#include <unistd.h>

pthread_mutex_t lock;
pthread_cond_t cond;
int x = 0;
void *prva_nit(void *args);
void *druga_nit(void *args);

int main()
{
    pthread_t t1, t2;

    pthread_mutex_init(&lock, NULL);
    pthread_cond_init(&cond, NULL);

    pthread_create(&t1, NULL, (void *)&prva_nit, NULL);
    sleep(3);
    pthread_create(&t2, NULL, (void *)&druga_nit, NULL);

    pthread_join(t1, NULL);
    pthread_join(t2, NULL);

    pthread_mutex_destroy(&lock);
    pthread_cond_destroy(&cond);

    return 0;
}

void *prva_nit(void *args)
{
    pthread_mutex_lock(&lock);
    printf("Prva nit: zaključavam!\n");
    while (x < 100)
        pthread_cond_wait(&cond, &lock);
    printf("Prva nit: otključavam!\n");
    pthread_mutex_unlock(&lock);
}

void *druga_nit(void *args)
{
    pthread_mutex_lock(&lock);
    printf("Druga nit: zaključavam!\n");
    while (x < 200)
    {
        x++;
        if (x == 100)
        {
            printf("Druga nit: signališem da je x == 100!\n");
            pthread_cond_signal(&cond);
        }
    }
    printf("Druga nit: otključavam!\n");
    pthread_mutex_unlock(&lock);
}