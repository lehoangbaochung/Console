def function(a, b):
   a = sorted(a, reverse=True)
   b = sorted(b, reverse=True)
   c = 0
   merge_list = a + b
   for i in merge_list:
      if (i in a and i in b):
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