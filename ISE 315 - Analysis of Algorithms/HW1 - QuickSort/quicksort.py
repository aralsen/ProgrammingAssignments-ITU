import time
import sys
from dataclasses import dataclass


@dataclass
class Sales:
    country: str
    item_type: str
    order_id: str
    units_sold: int
    total_profit: float

    # overload the "Less-Than or Equal To (<=)" operation for comparison between two Sales class item.
    def __le__(self, other):
        # check orders that have the different country name
        if self.country != other.country:
            # compare the orders in alphabetical order in terms of the name of country
            return self.country < other.country
        else:  # orders that have the same country name
            # sorted in "descending" order of total profits.
            return self.total_profit > other.total_profit

    # Formatted print
    def __repr__(self):
        return (self.country + '\t'
                + self.item_type + '\t'
                + self.order_id + '\t'
                + str(self.units_sold) + '\t'
                + str(self.total_profit))


def partition(arr, p, r):
    pivot = arr[r]  # pivot
    i = (p - 1)  # index of smaller element

    for j in range(p, r):
        # If current element is smaller than or equal to pivot
        if arr[j] <= pivot:
            # increase index of smaller element
            i = i + 1
            # swap values
            arr[i], arr[j] = arr[j], arr[i]

    arr[i + 1], arr[r] = arr[r], arr[i + 1]
    return i + 1


def quick_sort(arr, p, r):
    if len(arr) == 1:
        return arr

    if p < r:
        # identifies the pivot and move items to correct positions
        q = partition(arr, p, r)

        # call quick_sort method recursively
        quick_sort(arr, p, q - 1)  # elements to the left of the pivot
        quick_sort(arr, q + 1, r)  # elements to the right of the pivot
        return arr


# Reads lines from the file and returns them into the form of a Sales class, and put all data into list.
def init_data(file_name, n):
    operation_count = n
    sales_list = list()
    file = open(file_name)

    # Skip the first line of the file
    next(file)

    for line in file:
        data = line.split('\t')

        # add data to the sales_list
        sales_list.append(Sales(data[0], data[1], data[2], int(data[3]), float(data[4])))

        # decrease operation count for eliminate unwanted operations.
        operation_count -= 1
        if operation_count <= 0:
            break

    # return the sales_list with n length
    return sales_list


def writer(arr):
    with open('sorted.txt', 'w') as f:
        # writing the header
        f.write('Country	Item Type	Order ID	Units Sold	Total Profit\n')
        for line in arr:
            # formatted writing calling __repr__ function in Sales data class
            f.write(line.__repr__())
            f.write('\n')


def main():
    # value of N read from the command line
    n = int(sys.argv[1])

    # get first n data's from sales.txt to list
    data_list = init_data("sales.txt", n)

    # measure the time passed in quicksort with built-in time function (in terms of seconds)
    tic = time.perf_counter()  # start the counter
    sorted_arr = quick_sort(data_list, 0, len(data_list) - 1)
    toc = time.perf_counter()  # stop the counter

    # write the sorted array
    writer(sorted_arr)

    print(f"Elapsed time for sorting {n} elements is {toc - tic:0.6f} seconds")


if __name__ == "__main__":
    main()
