//Sistemski pozivi

// Dupliranje procesa
//Required headers
#include <sys/types.h>
#include <unistd.h>

pid_t fork(); // pid_t je int

/*Description
Nakon kreiranja proces dete je identičan roditeljskom procesu
 osim u pogledu: 
    - Različiti PID i PPID (PID roditeljskog procesa),
    - Različit adresni prostor,
    - Proces dete poseduje kopije svih resursa koje je
      proces roditelj koristio (copy – on – write).
U slučaju uspeha u roditeljskom procesu vrada PID deteta,
a u procesu detete vrada 0. 
Time se na jednostavan način može odrediti da li 
kod izvršavaju proces dete ili proces roditelj.
U slučaju greške vrada -1.
*/

// Vraća id procesa
#include <sys/types.h>
#include <unistd.h>

pid_t getpid();

// Vraća parent id procesa
#include <sys/types.h>
#include <unistd.h>

pid_t getppid();

// Suspendovanje izvršavanja procesa
#include <sys/types.h>
#include <unistd.h>

unsigned int sleep(unsigned int seconds);

/* Izvršavanje procesa se suspenduje zadati broj sekundi.
Nakon isteka specificiranog vremena proces normalno
nastavlja svoje izvršenje od prve naredne linije koda. */

// Završetak procesa
#include <stdlib.h>

void exit(int status);

/* Završava se izvršavanje procesa koji je pozvao funkciju:
  - Zatvaraju se sve otvorene datoteke
  - Oslobađa se zauzeta memorija
  - Obaveštava se roditeljski proces i prosleđuje mu se exit kod
  - Procesi deca za roditeljski proces dobijaju proces init (PID = 1)
Nikad ne dolazi do greške prilikom poziva funkcije exit i funkcija ne vrada vrednost.
Argument status definiše exit kod procesa (status kojim se završio).
Uobičajeno je da 0 označava da se proces normalno završio, 
a negativna vrednost da je došlo do greške.
Ne postoji standardna lista statusa koji se mogu primenjivati.
Status procesa se može dobiti korišdenjem wait funkcije. */

// Status procesa
#include <sys/types.h>
#include <unistd.h>

pid_t wait(int *status - ptr);               // zaustavlja proces dok se ne završi bilo koji proces dete
pid_t waitpid(pid_t pid, int *status - ptr); // zaustavlja proces dok se ne završi proces dete sa pidom

/* Proces koji je pozvao funkciju se zaustavlja dok se ne završi proces dete.
Promenljiva status-ptr prihvata exit kod sa koji se završio proces dete. */

// Izvršavanje programa
#include <sys/types.h>
#include <unistd.h>

// prvi argument, ili argv[0] je ime programa koji se poziva
int execl(const char *path, const char *arg, ...);                      // lista argumenata koja se završava sa NULL
int execv(const char *path, char *const argv[]);                        // očekuje niz argumenata
int execlp(const char *file, const char *arg, ...);                     // Pretraživanje izvršnih datoteka u PATH, u suprotnom kao execl
int execvp(const char *file, char *const argv[]);                       // Pretraživanje izvršnih datoteka u PATH, u suprotnom kao execv
int execle(const char *path, const char *arg, ..., char *const envp[]); // Specijalne vrednosti environment promenljivih, ne koristimo
int execve(const char *filename, char *const argv[], char *const envp[]);

/* Argumenti: putanja do izvršne datoteke, argumenti poziva programa i vrednosti
environment promenljivih (SHELL sistemske promenljive).
U slučaju uspeha funkcija se ne vrada u proces koji ju je pozvao (započinje izvršavanje novog programa):
  - Menja se kod procesa koji je pozvao funkciju kodom iz izvšne datoteke koja se učitava,
  - Zadržavaju se vrednosti PID i PPID,
  - Zadržavaju se sve otvorene datoteke.
U slučaju greške funkcija vrada -1. */