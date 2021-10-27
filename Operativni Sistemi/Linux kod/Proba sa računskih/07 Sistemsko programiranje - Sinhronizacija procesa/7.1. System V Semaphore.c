// System V Semaphore

// Kreiranje Semafora
#include <sys/sem.h>
int segment(key_t key, int nsems, int flag);

/* Semantika
    - Sstesmski poziv koji kreira novi System V Semaphore,
    - Prvi argument key predstavlja jedinstveni identifikator System V semaphore-a na nivou čitavog sistema.
        Mora biti poznat svim procesima koji žele da koriste određeni procesor.
    - Drugi argument nsems specificira broj celobrojnih vrednosti koje semafor sadrži.
    - Vrednost trećeg argumenta flag se definiše kao rezultat OR operacije nad različitim vrednostima i određuje:
        - Prava pristupa semaforu ( koristićemo vrednost 0666 koja svim korisnicima dodeljuje sve privilegije nad semaforom )
        - Mod kreiranja semafora. Neke od mogućih vrednosti:
            - IPC_CREAT - sistemski poziv kreira semafor ukoliko on već ne postoji u sistemu.
            - IPC_EXCL - koristi se u kombinaciji sa IPC_CREAT i zahteva da semafor sa zadatim identifikatorom ne postoji u sistemu.
        - Sistemski poziv vraća celobrojni identifikator (referencu) semafora, a u slučaju greške vraća (-1).
            Dobijeni identifikator (referenca) je važeći samo kod procesa koji je izvršio sistemski poziv i kod njegove dece.
        - Ukoliko u sistemu ne postoj semafor sa zadatim identifikatorom, a specificiran je flag IPC_CREAT kreira se novi System V Semaphore.
        - Ukoliko u sistemu već postoji semafor sa zadatim identifikatorom ( a nije specificiran flag IPC_CREAT | IPC_EXCL ) ne kreira se novi semafor, već se samo vraća referenca na postojeći System V Semaphore.
*/

// Operacije nad semaforom
#include <sys/sem.h>
int semop(int semid, struct sembuf *sempos, int nsops);

/* Semantika
    - Prvi argument semid predstavlja identifikator (referencu) System V Semaphore-a koji je dobijen pozivom funkcije semget.
    - Drugi argument semops predstavlja niz operacija koje treba izvršiti nad celobrojnim vrednostima System V semaphore-a. Svaka operacija je zadata kao sembuf struktura.
    - Treći argument nsops predstavlja broj elemenata niza sa operacijama.
*/

// Struktura SEMBUF
#include <sys/sem.h>
struct sembuf
{
    ushort sem_num;
    short sem_op;
    short sem_flag;
};

/* Semantika
    - Polje sem_num specificira indeks celobrojne vrednosti na koju se operacija odnosi.
    - Polje sem_op definiše operaciju koja se obavlja. Moguće vrednosti su:
        - >0 - Pozitivne vrednosti se dodaju odgovarajućoj celobrojnoj vrednosti semaphora odnosno ekvivalent je V operacija.
        - <0 - Negativne vrednosti se oduzimaju odgovarajućoj celobrojnoj vrednosti semafora odnosno ekvivalent je P operacija. Nijedna celobrojna vrednost ne može biti negativna.
        - ==0 - Proces koji je izvršio sistemski poziv se blokira dok odgovarajuća celobrojna vrednost ne dobije vrendost 0.
    - Polje sem_flag definiše način na koji se operacija obavlja. Najčešće ima vrednost NULL (kada se prihvata podrazumevani način izvršavanja operacije). Vrednost IPC_NOWAIT sprečava blokiranje procesa koji je izvršio sistemski poziv.
    - Sistemski poziv vraća 0, ukoliko su sve operacije uspešno izvršene, odnosno -1 ako je došlo do greške prilikom izvršavanja neke od operacija.
*/

// Kontrola semafora
#include <sys/sem.h>
int semctl(int semid, int semnum, int cmd, union semun arg);

/* Semantika
    - Prvi argument semid predstavlja identifikator (referencu) System V Sempahore-a, koji je dobijen pozivom funkcije semget.
    - Drugi argument semnum predstavlja indeks celobrojne vrednosti na koju se operacija odnosi.
    - Treći argument cmd definiše operaciju koju treba izvršiti nad semaforom.
        - Predstavlja broj elemenata niza sa operacijama.
        - Neke od mogućih operacija koje se mogu izvršiti nad System V Semaphore-om:
            - SETVAL - definiše vrednost odgovarajuće celobrojne vrednosti System V Semaphore-a
            - IPC_RMID - brisanje System V Sempahore-a iz sistema.
    - Ćetvrti argument arg omogućava definisanje parametara neophodnih za operaciju i definiše se kao unija semun.
*/

// Unija SEMUN
#include <sys/sem.h>
union semun
{
    int val; // Koristi se za zadavanje vrednosti prilikom inicijalizacije celobrojne vrednosti semafora.
    struct semid_ds *buf;
    ushort *array;
    struct seinfo *_buf;
    void *_pad;
};
