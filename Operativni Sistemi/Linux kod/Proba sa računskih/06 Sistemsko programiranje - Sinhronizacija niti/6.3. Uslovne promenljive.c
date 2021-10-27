// Uslovne promenljive

// Header: <pthread.h>
// Alijas: pthread_cond_t

// Kreiranje uslovne promenljive
#include <pthread.h>
int pthread_cond_init(pthread_cond_t *condition, pthread_attr_t *attr);

/* Semantika
    - Sistemski poziv koji kreira novi objekat tipa uslovna promenljiva.
    - Prvi argument je pokazivač na uslovnu promenljivu koja je prethodno deklarisana.
    - Drugi argument definiše atribute uslovne promenljive koja se kreira. NULL - podrazumevane vrednosti.
*/

// Brisanje uslovne promenljive
#include <pthread.h>
int pthread_cond_destroy(pthread_cond_t *condition);

/* Semantika
    - Sistemski poziv koji se koristi za brisanje uslovne promenljive nakon završetka rada sa njom.
    - Argument je pokazivač na uslovnu promenljivu koju želimo da obrišemo.
*/

// Blokiranje niti
#include <pthread.h>
int pthread_cond_wait(pthread_cond_t *condition, pthread_mutex_t *mutex);

/* Semantika
    - Sistemski poziv blokira izvršavanje niti na određenoj uslovnoj promenljivoj.
    - Nit se blokira na uslovnoj promenljivoj sve dok neka druga nit ne signalizira da je uslov koji se čeka ispunjen.
    - Funkcija se poziva samo ukoliko je objekat tipa mutex zaključan.
    - Mutex se automatski otključava tokom čekanja niti.
*/

// Signalizacija uslovne promenljive
#include <pthread.h>
int pthread_cond_signal(pthread_cond_t *condition);
int pthread_cond_broadcast(pthread_cond_t *condition);

/* Semantika
    - Sistemski poziv signalizira (budi) nit koja čeka na uslovnoj promenljivoj.
    - Funckija se poziva u okviru kritične sekcije, odnosno mutex mora biti zaključan.
    - Ukoliko više niti čeka na istu uslovnu promenljivu onda se koristi broadcast funckija.
*/