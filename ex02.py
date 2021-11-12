import sys

def logic(n):
    if n == N:
        global count

        count += 1
    else:
        for i in range(N):
            if visited[i]:
                continue
            board[n] = i

            if check(n):
                visited[i] = True
                logic(n+1)
                visited[i] = False

def check(n):
    for i in range(n):
        if (board[n] == board[i]) or (n - i == abs(board[n] - board[i])):
            return False

    return True

if __name__ == '__main__':
    N =  7
    count = 0
    board = [0 for _ in range(N)]
    visited = [False for _ in range(N)]

    logic(0)
    print(count)
