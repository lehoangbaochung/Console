def function(a, b):
    return 0

a = [], b = []
m = int(input("Nhap m = "))
for i in range(m):
   a.append(int(input("a[" + str(i) + "] = ")))
n = int(input("Nhap n = "))
for i in range(n):
   a.append(int(input("b[" + str(i) + "] = ")))
print("Day con co tong lon nhat =", function(a, b))