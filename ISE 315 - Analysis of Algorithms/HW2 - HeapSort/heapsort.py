import time
import sys
from dataclasses import dataclass


@dataclass
class Vehicles:
    vehicle_id: str
    location: str
    distance: float
    speed: int

    def __lt__(self, other):
        return self.distance / self.speed < other.distance / other.speed

    # Formatted print
    def __repr__(self):
        return self.vehicle_id


@dataclass
class Requests:
    location: str
    distance: float
    lucky_number: int

    # Formatted print
    def __repr__(self):
        return (self.location + '\t'
                + str(self.distance) + '\t'
                + str(self.lucky_number))


class MinHeap:

    def __init__(self, maxsize):
        self.maxsize = maxsize
        self.size = 0
        self.storage = [0] * (self.maxsize + 1)
        self.storage[0] = Vehicles("0", "null", 0, 78)
        self.ROOT = 1

    def swap(self, pos1, pos2):
        self.storage[pos1], self.storage[pos2] = self.storage[pos2], self.storage[pos1]

    # Function to heapify the node at pos
    def min_heapify(self, pos):
        # check if the current node is a leaf or not, and greater than any of its child
        if not (self.size // 2) <= pos <= self.size:
            if self.storage[pos] > self.storage[2 * pos + 1] or self.storage[pos] > self.storage[2 * pos]:

                if self.storage[2 * pos] < self.storage[2 * pos + 1]:
                    # left-child and pos swapped
                    self.swap(pos, 2 * pos)
                    # heapify with parent pos
                    self.min_heapify(2 * pos)
                else:
                    # right-child and pos swapped
                    self.swap(pos, 2 * pos + 1)
                    # heapify
                    self.min_heapify(2 * pos + 1)

    #  Insert a node into the heap
    def insert(self, element):
        if self.size >= self.maxsize:
            return
        self.size += 1
        self.storage[self.size] = element
        self.heapify()

    def decrease_key(self, i, new_val):
        self.storage[i].distance = new_val
        self.min_heapify(i)

    def heapify(self):
        curr = self.size
        while self.storage[curr] < self.storage[curr // 2]:
            self.swap(curr, curr // 2)
            curr = curr // 2

    #  build the min heap
    def minheap(self):
        for i in range(self.size // 2, 0, -1):
            self.min_heapify(i)

    #  min return from the heap
    def extract_min(self):
        extracted = self.storage[self.ROOT]
        self.storage[self.ROOT] = self.storage[self.size]
        self.size -= 1
        self.min_heapify(self.ROOT)
        return extracted


# Read lines from the file and returns them into the form of a Vehicles class, and put all data into list.
def init_vehicles(file_name):
    vehicle_list = list()
    file = open(file_name)

    # Skip the first line of the file
    next(file)

    for line in file:
        data = line.split('\t')
        # add data to the sales_list
        vehicle_list.append(Vehicles(data[0], data[1], float(data[2]), int(data[3])))

    # return the sales_list with n length
    return vehicle_list


# Read lines from the file and returns them into the form of a Requests class, and put all data into list.
def init_requests(file_name):
    request_list = list()
    file = open(file_name)

    # Skip the first line of the file
    next(file)

    for line in file:
        data = line.split('\t')
        # add data to the sales_list
        request_list.append(Requests(data[0], float(data[1]), int(data[2])))

    # return the sales_list with n length
    return request_list


def main():
    # value of N read from the command line
    n = int(sys.argv[1])

    # get data's from vehicles.txt to list
    vehicles_list = init_vehicles("vehicles.txt")

    # get data's from requests.txt to list
    requests_list = init_requests("requests.txt")

    # initialize the size of the Heap
    min_heap = MinHeap(len(vehicles_list))

    # insert Vehicles into the Heap
    # Build a min heap
    for vehicle in vehicles_list:
        min_heap.insert(vehicle)

    # measure the time passed in heapsort with built-in time function (in terms of seconds)
    tic = time.perf_counter()  # start the counter
    with open('call_history.txt', 'w') as f:
        for request in requests_list:
            # If the customer has no lucky numbers
            if request.lucky_number == 0:
                if n == 0:
                    break
                # the vehicle which can arrive the hotel the fastest, top of the min heap
                vehicle = min_heap.extract_min()
                n -= 1
                f.write(vehicle.__repr__() + "\n")
            else:
                # If the customer has a lucky number
                if n == 0:
                    break
                # call the vehicle that positioned in the Lth index of the heap.
                # Then, decrease the key value of the vehicle in the related index -> destination will be 0
                #  to make the vehicle first priority vehicle in the heap
                min_heap.decrease_key(request.lucky_number, 0)
                min_heap.minheap()
                n -= 1
                if n == 0:
                    break
                # take the highest priority vehicle top of the heap
                vehicle = min_heap.extract_min()
                n -= 1
                f.write(vehicle.__repr__() + "\n")

            # update information of the vehicle as it will be at the destination place.
            vehicle.location = request.location
            vehicle.distance = request.distance

            if n == 0:
                break

            # insert the vehicle into heap again
            min_heap.insert(vehicle)
            n -= 1
    toc = time.perf_counter()  # stop the counter

    # write the elapsed time
    print(f"Elapsed time for sorting  elements is {toc - tic:0.6f} seconds")


if __name__ == "__main__":
    main()
