def function(a, b):
    if b == 1:
        if a == 1: 
            return 1
        else: 
            return 0
    c = a - b
    if c == 0:
        return function(a, b - 1) + 1
    else:
        if c < b:
            return function(a, b - 1) + function(c, c)
        else:
            return function(a, b - 1) + function(c, b - 1)

k = int(input("Nhap k = "))
print("Co tat ca", function(k, k) - 1, "cach phan tich.")