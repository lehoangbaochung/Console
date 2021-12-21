def fibonacci(n):
    if n < 2:
        return n
    else:
        return fibonacci(n - 1) + fibonacci(n - 2)

def function(k):
    if k < 1:
        return 0
    else:
        i = 0
        while (fibonacci(i) <= k):
            i += 1
        return fibonacci(i)

k = int(input())
print(function(k))