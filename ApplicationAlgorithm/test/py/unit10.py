def function(a, b):
   c = 0
   for i in a:
      if (i in b):
         c += i
   return c

a = []
b = []
m = int(input("Nhap m = "))
for i in range(m):
   a.append(int(input("a[" + str(i + 1) + "] = ")))
n = int(input("Nhap n = "))
for i in range(n):
   b.append(int(input("b[" + str(i + 1) + "] = ")))
print("Day con co tong lon nhat =", function(a, b))