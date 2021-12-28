def function(n):
    if n == 1 or n == 3:
        return n
    if n % 2 == 0:
        k = n / 3
        return function(n / 2)
    else:
        if (n - 1) % 4 == 0:
            k = (n - 1) / 4
            return 2 * function(2 * k + 1) - function(k)
        if (n - 3) % 4 == 0:
            k = (n - 3) / 4
            return 3 * function(2 * k + 1) - 2 * function(k)

n = int(input("Nhap n = "))
print("g(" + str(n) + ") = " + str(int(function(n))))