import numpy as np

def function(a):
    return np.all(np.diff(a))

n = int(input())
a = list(map(int, input().split(' ')))
a.sort()
print(function(a))