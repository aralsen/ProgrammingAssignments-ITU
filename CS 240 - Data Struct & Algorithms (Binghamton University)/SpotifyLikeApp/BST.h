#ifndef BST_H
#define BST_H

#include <iostream>
#include <cassert>
using namespace std;

/*-----------------------------
  class BinaryNode
------------------------------*/
template <typename T>
class BinaryNode {
public:
    T data;
    BinaryNode<T>* left;
    BinaryNode<T>* right;
public:
    BinaryNode(const T &Data) {
        data = Data;
        left = NULL;
        right = NULL;
    };
    BinaryNode() : data(T()), left(NULL), right(NULL) {}
};
/*-----------------------------
  class BST
------------------------------*/
template<class T>
class BST
{
public:
    // typedef
    typedef BinaryNode<T> Node;

    // constructors & destructor
    BST() : root(NULL), cur_size(0) {}
    BST(const BST& tree);
    virtual ~BST() { clearTree(root); }

    // other member functions
    void insert(const T& x);
    void remove(const T& x);
    void removeMin();

    const T& findMin() const;
    const T& findMax() const;
    T* find(const T& x);

    bool isEmpty() const { return cur_size == 0; }
    int size() const { return cur_size; }

    // traversal functions
    void printPreorder(ostream & os) const;
    void printInorder(ostream & os) const;
    void printPostorder(ostream & os) const;

    void clearTree() { clearTree(root); cur_size = 0;}

protected:
    // data members
    Node *root;
    int cur_size;

    // hidden functions
    void insert(const T& x, Node * & ptr);
    void remove(const T& x, Node * & ptr);
    void removeMin(Node * & ptr);
    Node *findMin(Node * ptr) const;
    Node *findMax(Node * ptr) const;
    Node *find(const T& x, Node * ptr) const;
    void clearTree(Node * & ptr);
    Node *clone(Node * ptr) const;

    void printPreorder(ostream & os, Node *ptr) const;
    void printInorder(ostream & os, Node *ptr) const;
    void printPostorder(ostream & os, Node *ptr) const;
};

/*
 *  Public member functions
 */

// Copy constructor
template<class T>
BST<T>::BST(const BST& tree)
{
    root = clone(tree.root);
    cur_size = tree.cur_size;
}

// Some top-level public functions which call their
// corresponding hidden functions with parameter root

template<class T>
void BST<T>::insert(const T& x)
{
    insert(x, root);
}

template<class T>
void BST<T>::remove(const T& x)
{
    remove(x, root);
}

template<class T>
void BST<T>::removeMin()
{
    removeMin(root);
}

template<class T>
const T& BST<T>::findMin() const
{
    Node *ptr = findMin(root);
    assert(ptr);
    return ptr->data;
}

template<class T>
const T& BST<T>::findMax() const
{
    Node *ptr = findMax(root);
    assert(ptr);
    return ptr->data;
}

template<class T>
T* BST<T>::find(const T& x)
{
    Node *ptr = find(x, root);
    if (ptr)
        return &ptr->data;
    else
        return (T*) NULL;
}

/*
 *  Hidden (protected) functions
 */

// Recursive version of insert
template<class T>
void BST<T>::insert(const T& x, Node * & ptr)
{
    if (ptr == NULL)
    {
        ptr = new Node(x);
        cur_size++;
    }
    else
    {
        if (x < ptr->data)
            insert(x, ptr->left);
        else
            insert(x, ptr->right);
    }
}

// Recursive version of remove
template<class T>
void BST<T>::remove(const T& x, Node * & ptr)
{
    if (ptr)
    {
        if (x < ptr->data)
            remove(x, ptr->left);
        else if (x > ptr->data)
            remove(x, ptr->right);
        else
        {
            // Node to be removed found.  There are 3 cases.
            // Case 1: the node has 2 children
            if (ptr->left && ptr->right)
            {
                // Copy the minimum value in the right
                // subtree to write over to-be-deleted node
                Node *min = findMin(ptr->right);
                ptr->data = min->data;

                // Then call removeMin to delete the min node
                // in the right subtree.  Note we must pass
                // ptr->right (instead of local Node* variable)
                // for the case where ptr is root.
                removeMin(ptr->right);
            }
            else  // Case 2 & 3: 1 left/right child or 0 child
            {
                Node *temp = ptr;
                ptr = ptr->left ? ptr->left : ptr->right;
                delete temp;
                cur_size--;
            }
        }
    }
    // If node to be deleted is not found in the tree,
    // do nothing.
}

// Recursive version of removeMin
template<class T>
void BST<T>::removeMin(Node * & ptr)
{
    if (ptr)
    {
        if (ptr->left) // left subtree exists
            removeMin(ptr->left);
        else
        {
            // The current node is the minimum node.
            // Promote its right subtree (which could be
            // NULL as well) to this position and then
            // delete the current node.
            Node *min = ptr;
            ptr = ptr->right;
            delete min;
            cur_size--;
        }
    }
    // Error condition - no minimum in the tree.
}


// Iterative version of findMin
template<class T>
typename BST<T>::Node* BST<T>::findMin(Node * ptr) const
{
    if (ptr)
    {
        while (ptr->left)
            ptr = ptr->left;
    }
    return ptr;
}

// Iterative version of findMax
template<class T>
typename BST<T>::Node* BST<T>::findMax(Node * ptr) const
{
    if (ptr)
    {
        while (ptr->right)
            ptr = ptr->right;
    }
    return ptr;
}

// Iterative version of find
template<class T>
typename BST<T>::Node* BST<T>::find(const T& x, Node * ptr) const
{
    while (ptr)
    {
        if (x < ptr->data)
            ptr = ptr->left;
        else if (ptr->data < x)
            ptr = ptr->right;
        else
            break;
    }
    return ptr;
}

// Basically a recursive postorder traversal
// over a tree and delete each node
template<class T>
void BST<T>::clearTree(Node * & ptr)
{
    if (ptr)
    {
        clearTree(ptr->left);
        clearTree(ptr->right);
        delete ptr;   // visit => delete node
        ptr = NULL;
    }
}

// Basically a recursive preorder traversal
// over a tree and copy each node
template<class T>
typename BST<T>::Node * BST<T>::clone(Node * ptr) const
{
    if (ptr)
    {
        Node *newnode = new Node(ptr->data);
        newnode->left = clone(ptr->left);
        newnode->right = clone(ptr->right);
        return newnode;
    }
    return NULL;
}

//
// traversal functions
//

template<class T>
void BST<T>::printPreorder(ostream & os) const
{
    printPreorder(os, root);
}

template<class T>
void BST<T>::printInorder(ostream & os) const
{
    printInorder(os, root);
}

template<class T>
void BST<T>::printPostorder(ostream & os) const
{
    printPostorder(os, root);
}

template<class T>
void BST<T>::printPreorder(ostream & os, Node *ptr) const
{
    if (ptr)
    {
        os << ptr->data << endl;
        printPreorder(os, ptr->left);
        printPreorder(os, ptr->right);
    }
}

template<class T>
void BST<T>::printInorder(ostream & os, Node *ptr) const
{
    if (ptr)
    {
        printInorder(os, ptr->left);
        os << ptr->data << endl;
        printInorder(os, ptr->right);
    }
}

template<class T>
void BST<T>::printPostorder(ostream & os, Node *ptr) const
{
    if (ptr)
    {
        printPostorder(os, ptr->left);
        printPostorder(os, ptr->right);
        os << ptr->data << endl;
    }
}

#endif