/*
 * ASSIGNMENT - 2
 * SOURCE CODE
 *
 * Student Name: ARAL SEN
 * ITU Number : 150170217
 *
 *
 * The following commands can be used to compile and run the program:
 * $ gcc assignment2.c -o assignment2 -pthread -w
 * $ ./assignment2 5 6
 */

#include <unistd.h>
#include <pthread.h>
#include <stdio.h>
#include <stdlib.h>

typedef pthread_mutex_t Mutex;
typedef pthread_cond_t Condition;

int oxygen = 0;
int hydrogen = 0;

typedef struct {
    int value;
    int get_up;
    Mutex *mutex;
    Condition *condition;
} Semaphore;

Semaphore *mutex, *hydroBonded, *oxyQueue, *hydroQueue;

Mutex* create_mutex(void)
{
    Mutex* m_mutex = (Mutex*)malloc(sizeof(Mutex));
    int err = pthread_mutex_init(m_mutex, NULL);

    if (err != 0) {
        perror("init error");
    }

    return m_mutex;
}

void lock_mutex(Mutex *pMutex)
{
    int err = pthread_mutex_lock(pMutex);

    if (err != 0) {
        perror("lock_mutex error");
    }
}

void unlock_mutex(Mutex *pMutex)
{
    int err = pthread_mutex_unlock(pMutex);

    if (err != 0) {
        perror("unlock_mutex error");
    }
}

Condition* create_condition(void)
{
    Condition* condition = (Condition*)malloc(sizeof(Condition));
    int err = pthread_cond_init(condition, NULL);

    if (err != 0) {
        perror("create_condition error");
    }

    return condition;
}

void signal_condition(Condition* cond)
{
    int err = pthread_cond_signal(cond);

    if (err != 0) {
        perror("signal_condition error");
    }
}

void wait_condition(Condition* cond, Mutex* pMutex)
{
    int err = pthread_cond_wait(cond, pMutex);

    if (err != 0) {
        perror("wait_condition error");
    }
}

Semaphore* create_semaphore(int val)
{
    Semaphore *sem = (Semaphore*)malloc(sizeof(Semaphore));
    sem -> value = val;
    sem -> get_up = 0;
    sem -> mutex = create_mutex();
    sem -> condition = create_condition();
    return sem;
}

void signal_semaphore(Semaphore *sem)
{
    lock_mutex(sem->mutex);
    sem -> value++;
    if (sem -> value <= 0)
    {
        sem -> get_up++;
        signal_condition(sem->condition);
    }
    unlock_mutex(sem->mutex);
}

void wait_semaphore(Semaphore *sem)
{
    lock_mutex(sem->mutex);
    sem -> value--;
    if (sem -> value < 0) {
        do {
            wait_condition(sem->condition, sem->mutex);
        } while (sem -> get_up < 1);
        sem -> get_up--;
    }
    unlock_mutex(sem->mutex);
}

int bond(void)
{
    usleep(500000);
    return 0;
}

_Noreturn void* oxygen_function(void* arg)
{
    int num = (rand() % (1000000 - 250000 + 1)) + 250000;  // random number between [250000, 1000000]
    usleep(num);

    wait_semaphore(mutex);
    oxygen+=1;
    if (hydrogen >= 2)
    {
        printf("Oxygen = %d: %d oxygen atoms and %d hydrogen atoms are waiting, so I signal the next oxygen and hydrogen atoms in the queue.\n", pthread_self(), oxygen, hydrogen);
        signal_semaphore(hydroQueue);
        signal_semaphore(hydroQueue);
        hydrogen-=2;
        signal_semaphore(oxyQueue);
        oxygen-=1;
    }
    else {
        printf("Oxygen = %d: No available hydrogen atoms, so I wait. There are other %d oxygen atoms and %d hydrogen atoms waiting.\n", pthread_self(), oxygen, hydrogen);
        signal_semaphore(mutex);
    }
    wait_semaphore(oxyQueue);
    printf("Oxygen %d: We are bonding together now.\n", pthread_self());
    bond();  // usleep(500000)
    wait_semaphore(hydroBonded);
    wait_semaphore(hydroBonded);
    printf("Oxygen %d: I have bounded with two hydrogen atoms, and become a water molecule.\n\n", pthread_self());
    signal_semaphore(mutex);
}

_Noreturn void* hydrogen_function(void* arg)
{
    int num = (rand() % (1000000 - 250000 + 1)) + 250000; // // random number between [250000, 1000000]
    usleep(num);

    wait_semaphore(mutex);
    hydrogen +=1;
    if (hydrogen >= 2 && oxygen >= 1)
    {
        printf("Hydrogen = %d: %d oxygen atoms and %d hydrogen atoms are waiting, so I signal the next oxygen and hydrogen atoms in the queue.\n", pthread_self(), oxygen, hydrogen);
        signal_semaphore(hydroQueue);
        signal_semaphore(hydroQueue);
        hydrogen-=2;
        signal_semaphore(oxyQueue);
        oxygen-=1;
    }
    else {
        printf("Hydrogen = %d: No available hydrogen or oxygen atoms, so I wait. There are other %d oxygen atoms and %d hydrogen atoms waiting.\n", pthread_self(), oxygen, hydrogen);
        signal_semaphore(mutex);
    }
    wait_semaphore(hydroQueue);
    printf("Hydrogen %d: We are bonding together now.\n", pthread_self());
    bond(); // usleep(500000)
    signal_semaphore(hydroBonded);
}

int main(__attribute__((unused)) int argc,char* argv[])
{
    int n = atoi(argv[1]); // number of oxygen atoms
    int m = atoi(argv[2]); // number of hydrogen atoms

    int thread_count = n + m;
    pthread_t threads[thread_count]; // creating n+m threads

    int i;
    int randomValue;
    void *tmp = NULL;

    mutex = create_semaphore(1);
    hydroBonded = create_semaphore(0);
    oxyQueue = create_semaphore(0);
    hydroQueue = create_semaphore(0);

    // create n+m threads random order
    for (i = 0; i < thread_count; i++) {
        randomValue = rand() % 2; // this gives us 0 or 1
        if (n > 0 && m > 0) {
            if (randomValue) {  // if 1 -> create oxygen
                n--;
                pthread_create(&threads[i], NULL, oxygen_function, tmp);
            }
            else {
                m--;
                pthread_create(&threads[i], NULL, hydrogen_function, tmp); // create hydrogen
            }
        }
        else if (n > 0 && m == 0) {
            n--;
            pthread_create(&threads[i], 0, oxygen_function, tmp);
        }
        else if (m > 0 && n == 0) {
            m--;
            pthread_create(&threads[i], 0, hydrogen_function, tmp);
        }
        else {
            printf("error\n");
            exit(-1);
        }
    }

    for(;;); // endless loop, "ctrl + c" to Interrupt (kill) the current foreground process running in the terminal
}