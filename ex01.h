#pragma once
template <class ItemType>
void swap(ItemType& one, ItemType& two);

template<class ItemType>
// Assumes ItemType is either a built-in simple type or a class
// with overloaded relational operators.
struct HeapType
{
	void ReheapDown(int root, int bottom);
	void ReheapUp(int root, int bottom);
	ItemType* elements;   // Array to be allocated dynamically
	int numElements;
};

template <class ItemType>
void Swap(ItemType& one, ItemType& two)
{
	ItemType temp;
	temp = one;
	one = two;
	two = temp;
}

template<class ItemType>
void HeapType<ItemType>::ReheapUp(int root, int bottom)
{
	int parent;
	bool reheaped = false;

	while (bottom > root && !reheaped)
	{
		parent = (bottom - 1) / 2;

		if (elements[parent] < elements[bottom])
		{
			Swap(elements[parent], elements[bottom]);
			bottom = parent;
		}
		else
			reheaped = true;
	}
}

template<class ItemType>
void HeapType<ItemType>::ReheapDown(int root, int bottom)
{
	int maxChild, leftChild, rightChild;
	bool reheaped = false;

	leftChild = root * 2 + 1;

	while (leftChild <= bottom && !reheaped)
	{
		if (leftChild == bottom)
			maxChild = leftChild;
		else {
			rightChild = leftChild + 1;
			maxChild = (elements[leftChild] <= elements[rightChild]) ? rightChild : leftChild;
		}

		if (elements[root] < elements[maxChild]) {
			Swap(elements[root], elements[maxChild]);
			root = maxChild;
			leftChild = root * 2 + 1;
		}
		else
			reheaped = true;
	}
}