def function(n):
    result = set()
    result.add((n, ))
    for i in range(1, n):
        for j in function(n - i):
            result.add(tuple(sorted((i, ) + j)))
    return result

def main(n, k):
    c = 0
    for i in function(n):
        s = 1
        for j in i:
            s *= j
        if s >= k:
            c += 1
    return c

n = int(input("N = "))
k = int(input("K = "))
print("So cach phan tich cap K =", main(n, k))