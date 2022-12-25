/*
 * ASSIGNMENT - 1
 * QUESTION 2 SOURCE CODE
 *
 * Student Name: ARAL SEN
 * ITU Number : 150170217
 *
 *
 * The following commands can be used to compile and run the program:
 * $ gcc hw1.c -o hw1 -pthread -w
 * $ time ./hw1
 */

#include <pthread.h>
#include <stdio.h>
#include <stdlib.h>


// size of integer array 1000000
#define SIZE 1000000

/* change number of threads 1, 10, 100, 1000, 100000, and 200000 */
#define N 1000
 	
// unsorted array
long int array[SIZE];

void *worker_thread(void *arg)		
{
	int id = (int)arg;		
	//printf("This is worker_thread #%d\n", id); // this line can be uncommented to see the id of the thread

	/* find index_of_interval_start */
    long int index_of_interval_start = id * (SIZE / N);


	/* find index_of_interval_finish */
    long int index_of_interval_finish = (id + 1) * (SIZE / N);


	/* find the maximal element in the interval */
    long int max = array[0];

    for (long int i = index_of_interval_start; i < index_of_interval_finish; i++) {
        if (array[i] > max)
            max = array[i];
    }

    pthread_exit((void *) max);
}

int main()
{
	/* define an array with type pthread_t, and size N */
    pthread_t threads[N];

	/* define an array to store all maximal elements obtained from each threads */
    long int maxElementsArray[N];

	// this creates an unsorted array with random elements
	// do not change
	int i;
	srand(time(NULL));
	for(i = 0; i < SIZE; i++){
		array[i] = rand() % 10000;
	}

	/* create N threads */
    long int j = 0;
    for (j = 0; j < N; j++) {
        //printf("main() : creating thread, %d\n", i);
        pthread_create(&threads[j], NULL, worker_thread, (void *) j);
    }

	/* join threads and return value of each thread assigned to maxElementsArray[] with corresponding id of the thread */
    long int* ret;

    for (j = 0; j < N; j++ ) {
        //printf("main() : joining thread, %d\n", i);
        pthread_join(threads[j], (void**)&ret);
        maxElementsArray[j] = (long) ret;
    }

	/* find the maximum from maxElementsArray[] */
    long int max = maxElementsArray[0];

    for (j = 0; j < N; j++) {
        if (maxElementsArray[j] > max)
            max = maxElementsArray[j];
    }

    printf("After threads joined, the found max value by parent is %ld\n", max);

	return 0;
}