// Niti

#include <pthread.h>
// gcc fajl.c -o fajl -lpthread

// Kreiranje niti
#include <pthread.h>

int pthread_create(pthread_t *threadhandle, pthread_attr_t *attribute, void *(*start_routine)(void *), void *arg);

/* Semantika
- Funkcija započinje izvršavanje nove niti.
- Argumenti:
    - handle novokreirane niti, ukoliko se funkcija uspešno izvrši
    - argumenti za kreiranje niti ( mogu imati NULL vrednost )
    - pokazivač na funckiju koja sadrži programski kod koji će nit izvršavati.
      Funkcija mora da vraća void* i da ima jedan ulazni argument koji je void*.
    - pokazivač na ulazni argument niti
*/

#include <pthread.h>
int pthread_join(pthread_t threadhandle, void **returnvalue);

/* Semantika
- Nit koja je pozvala funkciju pthread_join se zausavlja i čeka da se završi nit koja je završena svojim handle-om.
*/
