#partition (number theory)
def fuction(n):
    result = set()
    result.add((n, ))
    for i in range(1, n):
        for j in fuction(n - i):
            result.add(tuple(sorted((i, ) + j, reverse=True)))
    return sorted(result, reverse=True)

n = int(input("Nhap n = "))
for i in fuction(n):
    s = str(n) + " = "
    for j in range(0, len(i) - 1):
        s += str(i[j]) + "+"
    s += str(i[len(i) - 1])
    print(s)