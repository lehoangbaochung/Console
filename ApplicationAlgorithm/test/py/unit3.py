def function(a, n):
    m = a[0]
    for i in range(n):
        if a[i] > m:
            m = a[i]
    if m >= n: 
        return m
    else: 
        return m + 1

n = int(input())
a = list(map(int, input().split(' ')))
print(function(a, n))