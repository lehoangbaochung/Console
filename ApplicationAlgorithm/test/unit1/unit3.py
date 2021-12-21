def function(a, n):
    k = 0
    for i in range(n):
        if (a[i] > a[i + 1]) and (k <= a[0]):
            k += 1
            if k == n:
                return k
    return k

a = []
N = int(input())
for i in range(N):
   n = int(input())
   a.append(n)
a.sort()
print(function(a, N))