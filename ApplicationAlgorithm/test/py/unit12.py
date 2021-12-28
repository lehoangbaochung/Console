def function(k):
    result = set()
    result.add((k, ))
    for i in range(1, k):
        for j in function(k - i):
            result.add((i, ) + j)
    return result

def counter(k):
    c = 0
    for i in function(k):
        if list(i) == list(set(i)) and len(i) > 1:
            c += 1  
    return c

k = int(input("Nhap k = "))
print("Co tat ca", counter(k), "cach phan tich.")