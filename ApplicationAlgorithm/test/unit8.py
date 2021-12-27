#partition (number theory)
def function(n):
    result = set()
    result.add((n, ))
    for i in range(1, n):
        for j in function(n - i):
            result.add(tuple(sorted((i, ) + j, reverse=True)))
    return sorted(result, reverse=True)

n = int(input("Nhap n = "))
for i in function(n):
    s = str(n) + " = "
    for j in i:
        s += str(j) + "+"
    print(s.removesuffix("+"))