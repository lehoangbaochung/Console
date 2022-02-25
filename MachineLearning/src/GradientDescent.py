import math
import numpy as np
import matplotlib.pyplot as plt

def hamso(x):
    return x**2 + 5*np.sin(x)
def daoham(x):
    return x*2 + 5*np.cos(x)

def main(x0, learning_rate):
    x = [x0]
    for i in range(100):
        x_new = x[-1] - learning_rate * daoham(x[-1])
        if (abs(daoham(x_new)) < 1e-5): break
        x.append(x_new)
    return (x, i)

(x1, loop_count) = main(-5, 0.1)
print("Diem toi uu x1 = %f, f(x) = %f va lap %d lan" %(x1[-1], hamso(x1[-1]), loop_count))