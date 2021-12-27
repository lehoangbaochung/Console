def function(a, n):
    c = 0
    k = a[1] - a[0]
    for i in range(1, n - 1):
        if (a[i] + k != a[i + 1]):
            return 0
    return 1

n = int(input())
a = list(map(int, input().split(' '))) # 3 5 4 2 1
a.sort()
print(function(a, n))