#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <sys/wait.h>

int main() {
    int returnValue = 0;

    int i;
    for (i = 0; i < 3; i++) {
        returnValue = fork();
        if (returnValue == -1) {
            exit(0);
        }
        else if (returnValue != 0) {
            wait(NULL);
        }

        printf("Current process id: %d\n",  getpid());
    }

    return 0;
}