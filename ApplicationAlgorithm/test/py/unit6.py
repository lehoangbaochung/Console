def function(m, n):
    if m == 0 or n == 0: return 1
    return function(m - 1, n) + function(m, n - 1)

m = int(input("Nhap M = "))
n = int(input("Nhap N = "))
print("So cach =", function(m, n))