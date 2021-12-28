def function(n):
    if n < 3:
        if n < 0:
            return 0
        return n
    if n % 3 == 0:
        k = n / 3
        return function(2 * k)
    elif (n - 1) % 3 == 0:
        k = (n - 1) / 3
        return function(2 * k) + function(2 * k + 1)
    else:
        k = (n - 2) / 3
        return function(2 * k) + function(2 * k + 1) + function(2 * k + 2)

n = int(input("Nhap n = "))
print("f(" + str(n) + ") = " + str(int(function(n))))