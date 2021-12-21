#partition (number theory)
def fuction(n):
    result = set()
    result.add((n, ))
    for i in range(1, n):
        for j in fuction(n - i):
            result.add((i, ) + j)
    return sorted(result)

n = int(input("Nhap n = "))
m = int(input("Nhap m = "))
for i in fuction(n):
    if len(i) == m:
        s = str(n) + " = "
        for j in i:
            s += str(j) + "+"
        s = s.removesuffix("+")
        print(s)