def function(m, n):
    if n == 0:
        if m == 0:
            return 1
        else:
            return 0
    else:
        return function(a, m, n - 1) + function(a, m - a[n], n - 1)

a = []
m = int(input("Nhap m = "))
n = int(input("Nhap n = "))
for i in range(n):
   o = int(input("a[" + str(i) + "] = "))
   a.append(o)
print("Co tat ca", function(a, m, n - 1), "cach phan tich.")