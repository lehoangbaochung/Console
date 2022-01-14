def function(n):
    result = set()
    result.add((n, ))
    for i in range(1, n):
        for j in function(n - i):
            result.add(tuple(sorted((i, ) + j)))
    return result

def main(n):
    if n < 2:
        return 0
    elif n < 5:
        return 1
    elif n == 5:
        return 2
    c = 0
    for i in function(n):
        s = 0
        for j in i:
            s += j
        if s == n:
            c += 1
    return c

n = int(input())
print(main(n))