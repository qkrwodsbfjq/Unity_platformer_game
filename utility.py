def printMatrix(d):
    m=len(d)
    n=len(d[0])

    for i in range(0,m):
        for j in range(0,n):
            print("%5d"%d[i][j],end=" ")
        print("\n")


def order(i,j,p):
    if i==j:
        print("A",i,end="")
    else:
        k=p[i][j]
        print("(",end="")
        order(i,k,p)
        order(k+1,j,p)
        print(")",end="")

d=[5,2,3,4,6,7,8]
n=len(d)-1

m=[[0 for j in range(1,n+2)] for i in range(1,n+2)]
p=[[0 for j in range(1,n+2)] for i in range(1,n+2)]

def minmult(n, d,p):
    for i in range(0,n+1):
        m[i][i]=0
    for diagonal in range(1,n):
        for i in range(1,n-diagonal+1):
            j=i+diagonal
            min_val=m[i][i]+m[i+1][j]+d[i-1]*d[i]*d[j]
            min_k=i
            for k in range(i,j):
                x=m[i][k]+m[k+1][j]+d[i-1]*d[k]*d[j]

                if x<min_val:
                    min_val=x
                    min_k=k
            m[i][j]=min_val
            p[i][j]=min_k
    return m[1][n]
minmult(n,d,p)

print()
printMatrix(m)
print()
printMatrix(p)
order(1,6,p)
