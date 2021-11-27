// Implementation file for StackType.h

//A. 맨 마지막에 들어온 원소
//B. 구현
//C. heap을 사용한 우선순위 큐를 사용한 경우 Push는 원래 O(1)이었지만 O(logN)이 됨, Pop은 원래 O(1)이었지만 O(logN)이 됨.

#include <cstddef>
#include <new>
#include <iostream>

using namespace std;
#include "StackType.h"
void StackType::Push(ItemType newItem)
// Adds newItem to the top of the stack.
// Pre:  Stack has been initialized.
// Post: If stack is full, FullStack exception is thrown;
//       else newItem is at the top of the stack.

{
	if (IsFull())
		throw FullStack();
	else
	{
		StackItem item;
		item.timeStamp = timeStamp++;
		item.value = newItem;
		pq.Enqueue(item);
	}
}
ItemType StackType::Pop()
// Removes top item from Stack and returns it in item.
// Pre:  Stack has been initialized.
// Post: If stack is empty, EmptyStack exception is thrown;
//       else top element has been removed.
{
	if (IsEmpty())
		throw EmptyStack();
	else
	{
		StackItem item;
		pq.Dequeue(item);
		return item.value;
	}
}
bool StackType::IsEmpty() const
// Returns true if there are no elements on the stack; false otherwise.
{
	return pq.IsEmpty();
}
bool StackType::IsFull() const
// Returns true if there is no room for another ItemType 
//  on the free store; false otherwise.
{
	return pq.IsFull();
}

StackType::~StackType()
// Post: stack is empty; all items have been deallocated.
{

}

StackType::StackType()	// Class constructor.
	:pq(50)
{
	
	timeStamp = 0;
}

