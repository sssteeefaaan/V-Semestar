#include <dirent.h>
#include <stdio.h>
#include <stdlib.h>
#include <memory.h>
#include <string.h>
#include <sys/stat.h>

// struct dirent
// {
//     ino_t d_ino;
//     char d_name[NAME_MAX + 1];
// };

void processDir(char *path, char *name)
{
    char filePath[100];

    memset(filePath, '\0', 100);
    strcat(filePath, path);
    strcat(filePath, "/");
    strcat(filePath, name);
    getchar();

    DIR *direktorijum;

    direktorijum = opendir(filePath);
    if (direktorijum == NULL)
    {
        printf("Nije otvoreno ništa!\n");
        exit(998);
    }
    struct dirent *info;
    struct stat dsc;

    char fileChild[100];
    memset(fileChild, '\0', 100);
    strcat(fileChild, filePath);
    strcat(fileChild, "/");
    int size = strlen(fileChild);

    while ((info = readdir(direktorijum)) != NULL)
    {
        memset(fileChild + size, '\0', 100 - size);
        strcat(fileChild, info->d_name);
        if (stat(fileChild, &dsc) == -1)
        {
            printf("Greška pri pribavljanju podataka o direktorijumu %s\n", info->d_name);
        }
        else
        {
            if (S_ISREG(dsc.st_mode))
            {
                printf("Datoteka: %s\n", info->d_name);
            }
            else
            {
                if (S_ISDIR(dsc.st_mode) && strcmp(info->d_name, "..") != 0 && strcmp(info->d_name, ".") != 0)
                {
                    processDir(filePath, info->d_name);
                }
            }
        }
    }
}
int main(int argc, char *argv[])
{
    if (argc < 3)
    {
        printf("Nedovoljno argumenata!\n");
        exit(999);
    }
    processDir(argv[1], argv[2]);
}
