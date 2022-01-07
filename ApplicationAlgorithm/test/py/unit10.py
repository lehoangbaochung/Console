def function(a, b):
   m = len(a)
   n = len(b)
   c = [[0 for _ in range(n)] for _ in range(m)]
   print(c)
   for i in range(m):
      for j in range(n):
         if i == 0 or j == 0:
            c[i][j] = 0
         elif a[i] == b[j]:
            c[i][j] = c[i - 1][j - 1] + a[i]
         else:
            c[i][j] = max(c[i - 1][j], c[i][j - 1])
   print(c)
   return c[m - 1][n - 1]

a = []
b = []
m = int(input("Nhap m = "))
for i in range(m):
   a.append(int(input("a[" + str(i + 1) + "] = ")))
n = int(input("Nhap n = "))
for i in range(n):
   b.append(int(input("b[" + str(i + 1) + "] = ")))
print("Day con co tong lon nhat =", function(a, b))