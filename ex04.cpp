#include <iostream>
#define MAX_ROWS 10
#define MAX_COLS 10

using namespace std;

int mat[MAX_ROWS][MAX_COLS];
int NumPaths(int row, int col, int n);

int main() {
	for (int i = 0; i < MAX_ROWS; i++) {
		for (int j = 0; j < MAX_COLS; j++) {
			mat[i][j] = -1;
		}
	}

	cout << NumPaths(1, 1, 5);

	return 0;
}

int NumPaths(int row, int col, int n) {
	if (mat[row][col] != -1)
		return mat[row][col];

	if ((row == n) || (col == n))
		mat[row][col] = 1;
	else
		mat[row][col] = NumPaths(row + 1, col, n) + NumPaths(row, col + 1, n);
	
	return mat[row][col];
}