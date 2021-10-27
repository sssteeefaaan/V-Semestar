/*  Datavod (pipe) je mehanizam za komunikaciju između procesa koji omogućava jednosmernu komunikaciju,
    između dva istovremeno aktivna procesa korišćenjem toka (stream) podataka.
    Osnovne karakteristike:
        - Datavod funckioniše kao FIFO red
        - Operacije čitanja i pisanja su blokirajuće
        - Nije dozvoljeno upisivanje, ako ne postoji proces koji čita
        - Ukoliko ne postoji proces koji upisuje podatke u datavod, datavod simulira EOF (end of file)
*/

// Kreiranje datavoda
#include <unistd.h>
int pipe(int p[2]);

/*  Semantika:
        - Sistemski poziv koji kreira novi datavod i smešta par deskriptora koji ukazuju na krajeve datavoda u niz p:
            - p[0] - kraj dataovda koji se koristi za ČITANJE
            - p[1] - kraj datavoda koji se koristi za PISANJE
        - Funckija vraća 0 u slučaju uspešnog izvršenja odnosno -1 ukoliko je došlo do greške.
*/

// Zatvaranje datavoda
#include <unistd.h>
int close(int fd);

/*  Semantika:
        - Sistemski poziv koji zahteva deskriptor kojim se pristupa jednom od krajeva datavoda.
        - Kada se u svim procesima zatvore svi deskriptori koji ukazuju na datavod, datavod se automatski uništava.
*/

// Čitanje i pisanje iz datavoda
#include <unistd.h>
ssize_t read(int fd, void *buff, size_t count);
ssize_t write(int fd, void *buff, size_t count);

/*  Semantika
        - Sistemski poziv koji se koristi za čitanje odnosno pisanje podataka iz datavoda.
        - Prvi argument predstavlja deskriptor odgovarajućeg kraja datavoda.
        - Drugi argument predstavlja pokazivač na bafer iz koga se podaci upisuju u datavod, ili u koji se podaci iz datavoda.
        - Treći argument predstavlja veličinu bafera u BAJTOVIMA.
        - Povratna vrednost funkcija predstavlja broj pročitanih bajtova odnosno broj upisanih bajtova u datavod.
*/

// Preusmeravanje U/I operacija
#include <unistd.h>
int dup(int oldfd);
int dup2(int oldfd, int newfd);

/*  Semantika
        - Sistemski poziv dup nalazi najmanji slobodan deskriptor datoteke i postavlja ga da ukazuje na istu
        datoteku na koju ukazuje i deskriptor oldfd
        - Sistemski poziv dup2 zatvara deskriptor newfd, ukoliko je otvoren, i modifikuje ga da ukazuje
        na istu datoteku na koju ukazuje i deskriptor oldfd.
        - Oba sistemska poziva u slučaju uspeha vraćaju kopiju deskriptora oldfd, a u slučaju greške -1.
*/

// Imenovani datavod

// Kreiranje
#include <unistd.h>
int mkfifo(const char *pathname, mode_t mode);

/*  Semantika
        - Imenovani datavodi se mogu koristit za komunikaciju bilo koja dva procesa u sistemu ( ne moraju biti u srodstvu )
        - Imenovani datavodi su sastavni deo datotečnog sistema.
        - Za rad sa imenovanim datavodima mogu se koristiti sve funkcije koje se koriste za rad sa standardnim datotekama
*/