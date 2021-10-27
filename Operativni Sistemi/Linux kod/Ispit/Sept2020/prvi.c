#include <stdio.h>
#include <stdlib.h>
#include <sys/wait.h>
#include <sys/types.h>
#include <unistd.h>
#include <pthread.h>

#define N 2
#define broj_prolaza 15

int buffer[N];
pthread_mutex_t m;
pthread_cond_t prazan_buffer;
pthread_cond_t pun_buffer;
int pun = 0;

void proizvodjac(void)
{
    int i, j, bp = broj_prolaza;
    while(1)
    {
        pthread_mutex_lock(&m);
        
        while(pun != 0)
            pthread_cond_wait(&prazan_buffer, &m);
        
        for(j = 0; j < N ; j++)
            buffer[j] = rand() % 100 + 100;
        
        pun = 1;
        
        pthread_cond_signal(&pun_buffer);
        pthread_mutex_unlock(&m);
        
        // sleep(1);
        if(bp == 0)
            break;
        bp--;
    }
}

void potrosac(void)
{
    int i, j, test, bp = broj_prolaza;
    while(bp)
    {
        pthread_mutex_lock(&m);
        
        while(pun != 1)
            pthread_cond_wait(&pun_buffer, &m);
        
        test = 1;
        for(i = 0; i < N ; i++)
        {
            printf("buffer[%d] = %d\n", i, buffer[i]);
            if(i < N - 1)
                test &= buffer[i] == buffer[i + 1];
        }
        if(test)
            printf("Vrednosti su iste!\n");
        else
            printf("Vrednosti su razlicite!\n");
        
        pun = 0;
        
        pthread_cond_signal(&prazan_buffer);
        pthread_mutex_unlock(&m);
        
        // sleep(2);
        if(bp == 0)
            break;
        bp--;
    }
    
    return;
}
int main(int argc, char* argv[])
{
    pthread_mutex_init(&m, NULL);
    pthread_cond_init(&prazan_buffer, NULL);
    pthread_cond_init(&pun_buffer, NULL);
    
    pthread_t niti[2];
    
    pthread_create(&niti[0], NULL, (void*)proizvodjac,(void*)NULL);
    pthread_create(&niti[1], NULL, (void*)potrosac, (void*)NULL);
    
    pthread_join(niti[0], NULL);
    pthread_join(niti[1], NULL);
    
    pthread_cond_destroy(&pun_buffer);
    pthread_cond_destroy(&prazan_buffer);
    pthread_mutex_destroy(&m);
    
    return 0;
}
