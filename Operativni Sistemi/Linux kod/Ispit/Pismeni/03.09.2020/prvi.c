#include <unistd.h>
#include <stdio.h>
#include <stdlib.h>
#include <pthread.h>
#include <time.h>
#include <semaphore.h>
#include <sys/types.h>
#include <unistd.h>

#define N 10
#define BUFF_SIZE 2

sem_t empty;
sem_t full;
int buffer[BUFF_SIZE];

void *produce(void *args)
{
	int i, j;
	for (i = 0; i < N; i++)
	{
		j = -1;
		sem_wait(&empty);
		printf("Novi elementi: ");
		while (++j < BUFF_SIZE)
		{
			buffer[j] = rand() % 100 + 100;
			printf(" %d", buffer[j]);
		}
		printf("\n");
		sem_post(&full);
	}
}

int main(int argc, char *argv[])
{
	srand(time(0));
	pthread_t producer;

	sem_init(&full, 0, 0);
	sem_init(&empty, 0, 1);

	pthread_create(&producer, NULL, produce, NULL);

	int i = -1, j, same;
	while (++i < N)
	{
		same = 0;
		j = -1;

		sem_wait(&full);
		while (++j < BUFF_SIZE - 1 && same == 0)
			same = buffer[j] - buffer[j + 1];
		sem_post(&empty);

		if (same == 0)
			printf("Elementi su isti!\n");
		else
			printf("Elementi nisu isti!\n");
	}

	pthread_join(producer, NULL);

	sem_destroy(&full);
	sem_destroy(&empty);

	return 0;
}
