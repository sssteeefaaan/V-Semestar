// Mutex

// Header: <pthread.h>
// Alijas: pthread_mutex_t

// Kreiranje Mutex-a
#include <pthread.h>

int pthread_mutex_init(pthread_mutex_t *mutex, pthread_mutexattr_t *attr);

/* Semantika
    - Sistemski poziv koji kreira novi objekat tipa mutex.
    - Prvi argument je pokazivač na promenljivu tipa mutex, koja je prethodno deklarisana.
    - Drugi argument definiše atribute mutex-a, koji je kreiran. NULL vrednost - podrazumevane vrednosti
*/

// Brisanje Mutex-a
#include <pthread.h>
int pthread_mutex_destroy(pthread_mutex_t *mutex);

/* Semantika
    - Sistemski poziv koji se koristi za brisanje objekta tipa mutex nakon završetka rada sa njim.
    - Argument je pokazivač na objekat tipa mutex koji želimo da brišemo.
*/

// Zaključavanje Mutex-a
#include <pthread.h>
int pthread_mutex_lock(pthread_mutex_t *mutex);

/* Semantika
    - Nit koja je zaključala mutex postaje njenog vlasnik i samo ga ona može otključavati.
    - U jednom trenutku samo jedna nit može biti vlasnik mutex-a ( može zaključati mutex )
    - Niti koje pokušavaju da preuzmu vlasništvo nad zaključanim mutex-om se blokiraju sve dok se mutex ne otključa.
    - Otključavanjem mutex-a jedna od niti koje čekaju postaje vlasnik tog mutex-a, a ostale niti nastavljaju da čekaju.
*/

// Otključavanje Mutex-a
#include <pthread.h>
int pthread_mutex_unlock(pthread_mutex_t *mutex);

/* Semantika
    - Nit koja je vlasnik mutex-a je jedina nit koja može otključati taj mutex.
    - Funkcija vraća grešku, ukoliko se pokušava otključavanje mutex-a koji nije zaključan, ili ga je zaključala neka druga nit.
*/