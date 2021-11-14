/*
재귀함수는 코드에 대한 직관성을 높여주는 역할을 해준다.
아래 코드에서 보다시피 재귀함수로 작성하는 것이 그 의미를 더 쉽게 이해할 수 있다.
프로그램 코드 작성시에도 재귀함수는 문제에 나와있는 조건 (0 혹은 1일때 n, 이후는 Fib(n-2) + Fib(n-1) 을 언어 그대로 구현이 가능하다.
따라서 프로그래밍 효율에서는 재귀함수가 더 뛰어나다.

재귀함수를 사용하면 함수를 여러번 호출하게 된다.
실제 컴파일 후 머신 언어로 된 코드를 살펴보면, 함수 호출 시 현재 사용중인 메모리를 저장한 후 jump가 일어나 그 위치로 이동해서 실행하게 된다.
이 과정이 반복문보다 더 시간이 오래 걸린다고 알려져있다.
따라서 프로그램 동작 효율면에서는 반복문이 더 뛰어나다.
*/

#include <iostream>

using namespace std;

int Fib_a(int n);	// 재귀함수 사용
int Fib_b(int n);	// 재귀함수 미사용

int main() {
	cout << Fib_a(10) << endl;
	cout << Fib_b(10) << endl;

	return 0;
}

int Fib_a(int n) {	// 재귀함수 사용
	if (n == 0 || n == 1)
		return n;
	return Fib_a(n - 1) + Fib_a(n - 2);
}

int Fib_b(int n) {	// 재귀함수 미사용
	if (n == 0 || n == 1)
		return n;

	int back1 = 1;
	int back2 = 0;

	for (int i = 0; i <= n - 2; i++) {	// 0번째 1번째는 맨 위에서 처리하므로 n - 2
		int temp;
		temp = back1 + back2;
		back2 = back1;
		back1 = temp;
	}

	return back1;
}