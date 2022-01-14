def function(n):
    if n == 1:
        return 0
    else:
        if n % 2 == 0:
            return 1 + function(n / 2)
        else:
            return 1 + function(3 * n + 1)

n = int(input())
print(int(function(n)))