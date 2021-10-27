#include <stdio.h>
#include <stdlib.h>
#include <sys/types.h>
#include <unistd.h>
#include <pthread.h>

int global_data = 5;

void *child_function(void *p);

int main()
{
    pthread_t child;
    pthread_create(&child, NULL, child_function, NULL);

    printf("Osnovna nit. Globalni prodatak je: %d.\n", global_data);
    printf("Osnovna nit. ID procesa je: %d.\n", getpid());

    global_data = 10;
    pthread_join(child, NULL); // Ovde pokrećemo kreiranu nit.

    printf("Kraj programa. Globalni podatak je: %d\n", global_data);

    return 0;
}

void *child_function(void *p)
{
    printf("Nova nit. Globalni podatak je: %d.\n", global_data);
    printf("Nova nit. ID procesa je: %d.\n", getpid());

    global_data = 15;
    printf("Ponovo nova nit. Globalni podatak je: %d.\n", global_data);
}