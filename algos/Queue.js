/**
 * Class to represent a queue using an array to store the queued items.
 * Follows a FIFO (First In First Out) order where new items are added to the
 * back and items are removed from the front.
 */
class Queue {
    constructor() {
        this.items = [];
    }

    /**
     * Retrieves the size of this queue.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {number} The length.
     */
    len() {
        return this.items.length;
    }

    /**
     * Adds a new given item to the back of this queue.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @param {any} item The new item to add to the back.
     * @returns {number} The new size of this queue.
     */
    enqueue(item) {
        this.items.push(item);
        return this.items.length;
    }

    /**
     * Removes and returns the first item of this queue.
     * - Time: O(n) linear, due to having to shift all the remaining items to
     *    the left after removing first elem.
     * - Space: O(1) constant.
     * @returns {any} The first item or undefined if empty.
     */
    dequeue() {
        return this.items.shift();
    }

    /**
     * Retrieves the first item without removing it.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {any} The first item or undefined if empty.
     */
    front() {
        return this.items[0];
    }

    /**
     * Returns whether or not this queue is empty.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {boolean}
     */
    isEmpty() {
        return this.items.length === 0;
    }

    print() {
        console.log(this.items);
        return this.items;
    }
}

/* Rebuild the above class using a linked list instead of an array. */

/* 
In order to maintain an O(1) enqueue time complexity like .push with an array
We add a tail to our linked list so we can go directly to the last node
*/

class QueueNode {
    constructor(data) {
        this.data = data;
        this.next = null;
    }
}

class LinkedListQueue {
    constructor() {
        this.head = null;
        this.tail = null;
        this.size = 0;
    }

    /**
     * Retrieves the size of this queue.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {number} The length.
     */
    len() {
        return this.size;
    }

    /**
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {boolean} Indicates if the list is empty.
     */
    isEmpty() {
        return this.size === 0;
    }

    /**
     * Adds a given val to the back of the queue.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @param {any} val
     * @returns {number} The new size of the queue.
     */
    enqueue(val) {
        const newTail = new QueueNode(val);

        if (this.isEmpty()) {
            this.head = newTail;
            this.tail = newTail;
        } else {
            this.tail.next = newTail;
            this.tail = newTail;
        }
        this.size++;
        return this.size;
    }

    /**
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {any} The removed item.
     */
    dequeue() {
        if (!this.head) {
            return null;
        }

        const dequeued = this.head;
        this.head = this.head.next;

        if (this.head === null) {
            this.tail = null;
        }

        this.size--;
        return dequeued.data;
    }

    /**
     * Retrieves the first item without removing it.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {any} The first item.
     */
    front() {
        return this.head ? this.head.data : null;
    }


    /**
     * Enqueues each of the given items.
     * - Time: O(n) linear since enqueue is O(1), n = vals.length.
     * - Space: O(1) constant.
     * @param {Array<any>} vals
     */
    seed(vals) {
        vals.forEach((val) => this.enqueue(val));
    }

    print() {
        let runner = this.head;
        let vals = "";

        while (runner) {
            vals += `${runner.data}${runner.next ? ", " : ""}`;
            runner = runner.next;
        }
        console.log(vals);
        return vals;
    }

}


//Returns boolean whether queues are same length with same elements
//Use only methods from Queue classes, do not directly alter linked list or array
//No extra arrays / objects / etc
//The queues should be in the same order when you're done! 

function CompareQueues(qOne, qTwo) {
    if (qOne.len() != qTwo.len()) {
        return false;
    }
    let count = 0;
    let isEqual = true;
    const len = qOne.len();

    while (count < len) {
        const dequeuedOne = qOne.dequeue();
        const dequeuedTwo = qTwo.dequeue();

        if (dequeuedOne !== dequeuedTwo) {
            isEqual = false;
        }

        qOne.enqueue(dequeuedOne);
        qTwo.enqueue(dequeuedTwo);
        count++;
    }
    return isEqual;
}

/**
 * Determines whether the sum of the left half of the queue items is equal to
 * the sum of the right half. Avoid indexing the queue items directly via
 * bracket notation, use the queue methods instead for practice.
 * Use no extra array or objects.
 * The queue should be returned to it's original order when done.
 * If queue cannot be evenly divided, return false.
 * - Time: O(?).
 * - Space: O(?).
 * @returns {boolean} Whether the sum of the left and right halves is equal.
 */
function isSumOfHalvesEqual(queue) {
    const len = queue.len();

    if (queue.isEmpty() || len % 2 !== 0) {
        return false;
    }

    const halfLen = len / 2;
    let leftSum = 0;
    let rightSum = 0;
    let count = 0;

    while (count < len) {
        const dequeued = queue.dequeue();
        if (count < halfLen) {
            leftSum += dequeued;
        } else {
            rightSum += dequeued;
        }
        count++;
        queue.enqueue(dequeued);
    }
    return leftSum === rightSum;
}

const arrayQueueOne = new Queue();
arrayQueueOne.items = [1, 2, 9, 3, 3, 6];
arrayQueueOne.print();

const arrayQueueTwo = new Queue();
arrayQueueTwo.items = [7,7,7,7];
arrayQueueTwo.print();

const listQueue = new LinkedListQueue();
listQueue.seed([1, 2, 9, 3, 3, 6]);
listQueue.print();




