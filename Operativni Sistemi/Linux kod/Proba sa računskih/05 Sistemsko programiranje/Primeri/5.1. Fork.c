#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>

int main()
{
    int pid;

    printf("Ja sam originalni proces sa PID %d i PPID %d.\n", getpid(), getppid());

    pid = fork();

    if (pid)
    {
        printf("Ja sam roditeljski proces sa PID: %d i PPID: %d .\n", getpid(), getppid());
        printf("Pid procesa koji je moje dete je: %d .\n", pid);
    }
    else
    {
        sleep(5);
        printf("Ja sam proces dete sa PID: %d i PPID: %d .\n", getpid(), getppid());
    }

    printf("PID: %d izlazi.\n", getpid());

    return 0;
}