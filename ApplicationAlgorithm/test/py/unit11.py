def function(n):
    a = [1, 1]
    for i in range(2, n + 1):
        a.append(a[i - 1] + 2 * a[i - 2])
    return a[n]

n = int(input("N = "))
print("So phuong an =", function(n))