def function(a, n):
    k = 0
    for i in range(n):
        if (a[i] > a[i + 1]) and (k <= a[0]):
            k += 1
            if k == n:
                return k
    return k

a = []
n = int(input())
for i in range(n):
   a.append(int(input()))
a.sort()
print(function(a, n))