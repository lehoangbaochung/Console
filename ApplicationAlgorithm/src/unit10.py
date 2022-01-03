def function(a, b):
    m = min(len(a), len(b))
    c = abs(len(a) - len(b))
    for i in range(m):
        if a[i] != b[i]:
            c += 1
    return c

a = input("Nhap A = ")
b = input("Nhap B = ")
print("So thao tac it nhat de bien doi A thanh B =", function(a, b))