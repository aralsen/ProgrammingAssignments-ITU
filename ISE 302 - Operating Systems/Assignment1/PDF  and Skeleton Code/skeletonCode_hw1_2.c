#include <pthread.h>
#include <stdio.h>
#include <stdlib.h>

// size of integer array
#define SIZE 1000000 	

/* change number of threads 1, 10, 100, 1000, 100000, and 20000 */
#define N 20000 
 	
// unsorted array 
int array[SIZE];	

void *worker_thread(void *arg)		
{
	int id = (int)arg;		
	//printf("This is worker_thread #%d\n", id); // this line can be uncommented to see the id of the thread
	

	/* find index_of_interval_start */


	/* find index_of_interval_finish */



	/* find the maximal element in the interval */
	

	

	
	/* return with maximal element */
	
}

int main()
{
	/* define an array with type pthread_t, and size N */
	
	
	/* define an array to store all maximal elements obtained from each threads */
	

	// this creates an unsorted array with random elements 
	// do not change
	int i;
	srand(time(NULL));
	for(i = 0; i < SIZE; i++){
		array[i] = rand() % 10000;
	}

	/* create N threads */


	
	/* join threads and return value of each thread assigned to maxElementsArray[] with corresponding id of the thread */



	
	/* find the maximum from maxElementsArray[] */


	
	int max;
	
    	printf("After threads joined, the found max value by parent is %d\n", max);

	return 0;
}
