# To support both python 2 and python 3
from __future__ import division, print_function, unicode_literals
# list of points 
import numpy as np 
import matplotlib.pyplot as plt
from scipy.spatial.distance import cdist


def sigmoid(s):
    return 1/(1 + np.exp(-s))

def logistic_sigmoid_regression(X, y, w_init, eta, tol = 1e-4, max_count = 10000):
    w = [w_init]    
    it = 0
    N = X.shape[1]
    d = X.shape[0]
    count = 0
    check_w_after = 20
    while count < max_count:
        # it += 1
        # mix data 
        mix_id = np.random.permutation(N)
        for i in mix_id:
            xi = X[:, i].reshape(d, 1)
            yi = y[i]
            zi = sigmoid(np.dot(w[-1].T, xi))
            w_new = w[-1] + eta*(yi - zi)*xi
            count += 1
            # stopping criteria
            if count%check_w_after == 0:                
                if np.linalg.norm(w_new - w[-check_w_after]) < tol:
                    return w
            w.append(w_new)
    return w

X = np.array([[ 1.92306918,  0.775673  ],
            [ 2.90509186,  1.7997662 ],
            [ 1.58909188,  1.16143907],
            [ 2.76874122,  1.07663514],
            [ 2.52416203,  1.53020387],
            [ 2.02414192,  1.80692632],
            [ 2.49174878,  2.62943405],
            [ 1.11439322,  2.88348991],
            [ 2.62561276,  2.89077234],
            [ 3.27183166,  0.75454543],
            [ 3.55617919,  0.66250438],
            [ 1.45945603,  2.28222634],
            [ 2.87575608,  2.52637908],
            [ 2.30375703,  2.46497356],
            [ 1.08925412,  2.01982447],
            [ 4.09096119, -0.08330889],
            [ 1.80350003,  1.91837255],
            [ 1.25827634,  1.8856175 ],
            [ 2.08532169,  1.79005729],
            [ 1.9340609,   1.09208652],
            [ 4.49775285,  1.46545116],
            [ 3.07311718,  3.76212796],
            [ 3.52528933,  1.59844519],
            [ 2.39091046,  2.33431976],
            [ 3.12302646,  1.41945943],
            [ 4.62359547,  2.44921113],
            [ 3.38696098,  2.46494505],
            [ 4.36167918,  1.88637824],
            [ 3.21261415,  2.40558547],
            [ 2.71754956,  2.33882965],
            [ 4.01073111,  0.96947283],
            [ 3.11892586,  4.10522222],
            [ 2.29402636,  2.07905375],
            [ 3.7365999,   2.41022672],
            [ 4.29699439,  2.79542218],
            [ 4.63617269,  2.00962462],
            [ 2.84870815,  1.77280105],
            [ 4.45368062,  2.44805003],
            [ 4.97052399,  1.86194687],
            [ 3.01324102,  1.54377016]
            ]).T

y = np.concatenate((np.zeros((1, N)), np.ones((1, N))), axis = 1).T
X = np.concatenate((np.ones((1, 2*N)), X), axis = 0)
print('x',X)
print('y',y)

eta = .05 
d = X.shape[0]
w_init = np.random.randn(d, 1)

w = logistic_sigmoid_regression(X, y, w_init, eta, tol = 1e-4, max_count= 10000)
print(w[-1])

nhan = sigmoid(np.dot(w[-1].T, X))

print(nhan)

for row in nhan:
    for i in range(0,row.size):
        if nhan[0,i]>=0.5:
            nhan[0,i]=1
        else:
            nhan[0,i]=0

print('Kết quả dự đoán',nhan)