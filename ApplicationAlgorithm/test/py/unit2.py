def function(a, n):
    k = a[1] - a[0]
    for i in range(1, n - 1):
        if (a[i] + k != a[i + 1]):
            return 0
    return 1

def func(a, n):
    if n == 4: return 0
    d = 0
    c = 0
    s = 0
    for h in range(1, 10000):
        for i in range(n):
            for j in range(n):
                if a[i] == a[j + h]:
                    if d != h:
                        c = 1
                        d = h
                    c += 1
                if (c == 5):
                    if n == 5 and s == 1: break
                    s += 1
                    c = 1

n = int(input())
a = list(map(int, input().split(' '))) # 3 5 4 2 1
a.sort()
print(func(a, n))