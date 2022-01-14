# Trả về giá trị Fibonacci thứ n
def function(n):
    if n < 2:
        return n
    else:
        return function(n - 1) + function(n - 2)
    
n = int(input())
print(function(n))