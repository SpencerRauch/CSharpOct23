/**
 * A class to represents a single item of a SinglyLinkedList that can be
 * linked to other Node instances to form a list of linked nodes.
 */
class ListNode {
    /**
     * Constructs a new Node instance. Executed when the 'new' keyword is used.
     * @param {any} data The data to be added into this new instance of a Node.
     *    The data can be anything, just like an array can contain strings,
     *    numbers, objects, etc.
     * @returns {ListNode} A new Node instance is returned automatically without
     *    having to be explicitly written (implicit return).
     */
    constructor(data) {
        this.data = data;
        /**
         * This property is used to link this node to whichever node is next
         * in the list. By default, this new node is not linked to any other
         * nodes, so the setting / updating of this property will happen sometime
         * after this node is created.
         *
         * @type {ListNode|null}
         */
        this.next = null;
    }
}

/**
 * This class keeps track of the start (head) of the list and to store all the
 * functionality (methods) that each list should have.
 */
class SinglyLinkedList {
    /**
     * Constructs a new instance of an empty linked list that inherits all the
     * methods.
     * @returns {SinglyLinkedList} The new list that is instantiated is implicitly
     *    returned without having to explicitly write "return".
     */
    constructor() {
        /** @type {ListNode|null} */
        this.head = null;
    }

    /**
     * Determines if this list is empty.
     * - Time: O(?).
     * - Space: O(?).
     * @returns {boolean}
     */
    isEmpty() {
        return this.head === null;
    }

    /**
     * Creates a new node with the given data and inserts it at the back of
     * this list.
     * - Time: O(?).
     * - Space: O(?).
     * @param {any} data The data to be added to the new node.
     * @returns {SinglyLinkedList} This list.
     */
    insertAtBack(data) {
        //your code here
        let newEnd = new ListNode(data);
        if (this.isEmpty()) {
            this.head = newEnd;
            return;
        }
        let runner = this.head;
        while (runner.next !== null) {
            runner = runner.next;
        }
        runner.next = newEnd;
        //Your code here
    }

    /**
     * Creates a new node with the given data and inserts it at the back of
     * this list.
     * - Time: O(?).
     * - Space: O(?).
     * @param {any} data The data to be added to the new node.
     * @param {?ListNode} runner The current node during the traversal of this list
     *    or null when the end of the list has been reached.
     * @returns {SinglyLinkedList} This list.
     */
    insertAtBackRecursive(data, runner = this.head) {
        //your code here
        if (this.head === null) {
            this.head = new ListNode(data);
            return;
        }
        if (runner.next === null) {
            runner.next = new ListNode(data);
            return;
        }
        return this.insertAtBackRecursive(data, runner.next);
    }

    /**
     * Calls insertAtBack on each item of the given array.
     * - Time: O(n * m) n = list length, m = arr.length.
     * - Space: O(1) constant.
     * @param {Array<any>} vals The data for each new node.
     * @returns {SinglyLinkedList} This list.
     */
    insertAtBackMany(vals) {
        for (const item of vals) {
            this.insertAtBack(item);
        }
        return this;
    }

    /**
     * Converts this list into an array containing the data of each node and prints it.
     * - Time: O(n) linear.
     * - Space: O(n).
     * @returns {Array<any>} An array of each node's data.
     */
    toArr() {
        const arr = [];
        let runner = this.head;

        while (runner) {
            arr.push(runner.data);
            runner = runner.next;
        }
        console.log(arr);
        return arr;
    }

    /**
     * Creates a new node with the given data and inserts that node at the front
     * of this list.
     * - Time: (?).
     * - Space: (?).
     * @param {any} data The data for the new node.
     * @returns {SinglyLinkedList} This list.
     */
    insertAtFront(data) {
        //your code here
        let newHead = new ListNode(data);
        newHead.next = this.head;
        this.head = newHead;
        return this;
    }

    /**
     * Removes the first node of this list.
     * - Time: (?).
     * - Space: (?).
     * @returns {any} The data from the removed node or null if no first node.
     */
    removeHead() {
        //Your code here
        if (this.isEmpty()) return null;
        let removed = this.head;
        this.head = this.head.next;
        return removed.data;
    }

    // EXTRA
    /**
     * Calculates the average of this list.
     * - Time: (?).
     * - Space: (?).
     * @returns {number|null} The average of the node's data or null if empty.
     */
    average() {
        //your code here
        if (this.isEmpty()) return null;
        let runner = this.head;
        let count = 0;
        let sum = 0;
        while (runner) {
            count++;
            sum += runner.data;
            runner = runner.next;
        }
        return sum / count;
    }

    /**
     * Removes the last node of this list.
     * - Time: O(?).
     * - Space: O(?).
     * @returns {any} The data from the node that was removed or null if no nodes were removed.
     */
    removeBack() {
        if (this.isEmpty()) {
            return null;
        }

        // only one node, remove the head
        if (this.head.next === null) {
            return this.removeHead();
        }
        //more than one node, move to one before the end
        let runner = this.head;
        while (runner.next.next) {
            runner = runner.next;
        }

        const removedData = runner.next.data;
        runner.next = null;
        return removedData;
    }

    /**
     * Determines whether or not the given search value exists in this list iteratively.
     * - Time: O(?).
     * - Space: O(?).
     * @param {any} val The data to search for in the nodes of this list.
     * @returns {boolean}
     */
    contains(val) {
        let runner = this.head;
        while (runner) {
            if (runner.data === val) return true;
            runner = runner.next;
        }
        return false;
    }

    /**
     * Determines whether or not the given search value exists in this list recursively.
     * - Time: O(?).
     * - Space: O(?).
     * @param {any} val The data to search for in the nodes of this list.
     * @param {?ListNode} current The current node during the traversal of this list
     *    or null when the end of the list has been reached.
     * @returns {boolean}
     */
    containsRecursive(val, current = this.head) {
        //Your code here
        if (!current) return false;
        if (current.data === val) return true;
        return this.containsRecursive(val, current.next);
    }

    /**
     * Retrieves the data of the second to last node in this list.
     * - Time: O(?).
     * - Space: O(?).
     * @returns {any} The data of the second to last node or null if there is no
     *    second to last node.
     */
    secondToLast() {
        if (!this.head || !this.head.next) {
            return null;
        }

        // There are at least 2 nodes since the above return hasn't happened.
        let runner = this.head;

        while (runner.next.next) {
            runner = runner.next;
        }
        return runner.data;
    }

    /**
     * Removes the node that has the matching given val as it's data.
     * - Time: O(?).
     * - Space: O(?).
     * @param {any} val The value to compare to the node's data to find the
     *    node to be removed.
     * @returns {boolean} Indicates if a node was removed or not.
     */
    removeVal(val) {
        if (this.isEmpty()) {
            return false;
        }

        if (this.head.data === val) {
            this.removeHead();
            return true;
        }

        let runner = this.head;

        while (runner.next) {
            if (runner.next.data === val) {
                runner.next = runner.next.next;
                return true;
            }
            runner = runner.next;
        }
        return false;
    }

    // EXTRA
    /**
     * Inserts a new node before a node that has the given value as its data.
     * - Time: O(?).
     * - Space: O(?).
     * @param {any} newVal The value to use for the new node that is being added.
     * @param {any} targetVal The value to use to find the node that the newVal
     *    should be inserted in front of.
     * @returns {boolean} To indicate whether the node was pre-pended or not.
     */
    prepend(newVal, targetVal) {
        if (this.isEmpty()) {
            return null;
        }

        if (this.head.data === targetVal) {
            this.insertAtFront(newVal);
            return this.head;
        }
        // we already know we're not going to need to prepend before the head
        let runner = this.head;

        while (runner) {
            // End of list and not found.
            if (runner.next === null) {
                return null;
            }

            if (runner.next.data === targetVal) {
                const prependNode = new ListNode(newVal);
                prependNode.next = runner.next;
                runner.next = prependNode;
                return prependNode;
            }
            runner = runner.next;
        }
    }

    /**
     * Concatenates the nodes of a given list onto the back of this list.
     * - Time: O(?).
     * - Space: O(?).
     * @param {SinglyLinkedList} addList An instance of a different list whose
     *    whose nodes will be added to the back of this list.
     * @returns {SinglyLinkedList} This list with the added nodes.
     */
    concat(addList) {
        let runner = this.head;

        if (runner === null) {
            this.head = addList.head;
        } else {
            while (runner.next) {
                runner = runner.next;
            }
            runner.next = addList.head;
        }
        return this;
    }

    /**
     * Finds the node with the smallest data and moves that node to the front of
     * this list.
     * - Time: O(?).
     * - Space: O(?).
     * @returns {SinglyLinkedList} This list.
     */
    moveMinToFront() {
        if (this.isEmpty()) {
            return this;
        }

        let minNode = this.head;
        let runner = this.head;
        let prev = this.head;

        while (runner.next) {
            if (runner.next.data < minNode.data) {
                prev = runner;
                minNode = runner.next;
            }
            runner = runner.next;
        }

        if (minNode === this.head) {
            return this;
        }

        prev.next = minNode.next;
        minNode.next = this.head;
        this.head = minNode;
        return this;
    }

    // EXTRA
    /**
     * Splits this list into two lists where the 2nd list starts with the node
     * that has the given value.
     * splitOnVal(5) for the list (1=>3=>5=>2=>4) will change list to (1=>3)
     * and the return value will be a new list containing (5=>2=>4)
     * - Time: O(?).
     * - Space: O(?).
     * @param {any} val The value in the node that the list should be split on.
     * @returns {SinglyLinkedList} The split list containing the nodes that are
     *    no longer in this list.
     */
    splitOnVal(val) {
        const newList = new SinglyLinkedList();

        if (this.isEmpty()) {
            return newList;
        }

        if (this.head.data === val) { // if head is value, empty this list into the new list
            newList.head = this.head;
            this.head = null;
            return newList;
        }

        let runner = this.head;

        while (runner.next) {
            if (runner.next.data === val) {
                newList.head = runner.next;
                runner.next = null;
                return newList;
            }
            runner = runner.next;
        }
        return newList;
    }

    /**
     * Reverses this list in-place without using any extra lists.
     * - Time: O(n) linear, n = list length.
     * - Space: O(1) constant.
     * @returns {SinglyLinkedList} This list.
     */
    reverse() {
        //Your code here
        let prev = null; //our reference to the previous node, start it at null 
        let node = this.head; //we'll start at the head

        while (node) { //while we have a node
            const nextNode = node.next; //store reference to the next node -- this will be null for the last node
            node.next = prev; //point the current node backwards
            prev = node; //current node becomes the previous node
            node = nextNode; //move on to the next node
        }
        this.head = prev; //reset head to the last known node
        return this;
    }

    /**
      * Determines whether the list has a loop in it which would result in
      * infinitely traversing unless otherwise avoided. A loop is when a node's
      * next points to a node that is behind it.
      * - Time: O(n) linear, n = list length.
      * - Space: O(1) constant.
      * @returns {boolean} Whether the list has a loop or not.
      */
    hasLoop() {
        /**
          *APPROACH:
          *two runners are sent out and one runner goes faster so it will
          *eventually 'lap' the slower runner if there is a loop, 
          *at the moment faster runner laps slower runner, they are at the same
          *place, aka same instance of a node.
        */
        if (!this.head) {
            return false; //no loops in empty lists
        }

        let fasterRunner = this.head; 
        let runner = this.head;

        while (fasterRunner && fasterRunner.next) { //while fastRunner is still a node that has a .next
            runner = runner.next; //runner moves one
            fasterRunner = fasterRunner.next.next; //fastRunner moves two

            if (runner === fasterRunner) {
                return true; //if they collide, fastRunner has lapped and landed on runner
            }
        }
        return false;
    }

    /**
   * Determines whether the list has a loop in it which would result in
   * infinitely traversing unless otherwise avoided.
   * In a normal object, the keys cannot be other objects, but in a Map object,
   * they can be. We can't use the .data as the keys in a normal object because
   * that would could cause hasLoop to return a false positive when there are
   * nodes with duplicate data but no loop.
   * - Time: O(n) linear, n = list length.
   * - Space: O(n) linear due to the Map.
   * @returns {boolean} Whether the list has a loop or not.
   */
    hasLoopMap() {
        if (this.isEmpty()) {
            return false; //no loops in empty lists
        }

        const seenMap = new Map(); //keeps track of all nodes visited
        let runner = this.head;

        while (runner) {
            if (seenMap.has(runner)) { //if we've already seen this node, a loop exists
                return true;
            }
            seenMap.set(runner, true); //otherwise, set this node a key with a value of true in our map
            runner = runner.next; //check next node
        }
        return false; //if we run out of nodes to iterate, there is no loop
    }

}

const emptyList = new SinglyLinkedList();
const singleNodeList = new SinglyLinkedList().insertAtBackMany([1]);
const biNodeList = new SinglyLinkedList().insertAtBackMany([1, 2]);
const firstThreeList = new SinglyLinkedList().insertAtBackMany([1, 2, 3]);
const secondThreeList = new SinglyLinkedList().insertAtBackMany([4, 5, 6]);
const unorderedList = new SinglyLinkedList().insertAtBackMany([
    -5, -10, 4, -3, 6, 1, -7, -2,
]);

// node 4 connects to node 1, back to head
const perfectLoopList = new SinglyLinkedList().insertAtBackMany([1, 2, 3, 4]);
perfectLoopList.head.next.next.next = perfectLoopList.head;

// node 4 connects to node 2
const loopList = new SinglyLinkedList().insertAtBackMany([1, 2, 3, 4]);
loopList.head.next.next.next = loopList.head.next;

