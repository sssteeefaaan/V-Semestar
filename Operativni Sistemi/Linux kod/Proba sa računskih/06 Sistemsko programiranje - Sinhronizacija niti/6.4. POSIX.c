// POSIX Semafori

// Header: <semaphore>
// Alijas: sem_t

// Kreiranje Semafora
#include <semaphore.h>
int sem_init(sem_t *sem, int pshared, unsigned int value);

/* Semantika
    - Sistemski poziv koji kreira novi POSIX semafor.
    - Prvi argument je pokazivač na promenljivu tipa POSIX semafor, koja je prethodno deklarisana.
    - Drugi argument je uvek 0 (Koristimo samo za sinhronizaciju niti, može i za procese, ali nije u ovom kursu)
    - Treći argument predstavlja vrednost na koju se kreirani semafor inicijalizuje.
*/

// Brisanje Semafora
#include <semaphore.h>
int sem_destroy(sem_t *sem);

// P i V funkcije Semafora
#include <semaphore.h>
int sem_wait(sem_t *sem);
int sem_post(sem_t *sem);