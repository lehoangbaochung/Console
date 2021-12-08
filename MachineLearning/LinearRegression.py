from __future__ import division, print_function, unicode_literals
import numpy as np 
import matplotlib.pyplot as plt
x=17
tg=11
# dientich (m2)
X = np.array([[30+x, 32.4138+x, 34.8276+x, 37.2414+x, 39.6552+x, 42.069+x,44.4828+x, 46.8966+x,49.3103+x, 51.7241+x, 54.1379+x,
               56.5517+x, 58.9655+x, 61.3793+x,63.7931+x,66.2069+x,68.6207+x,71.0345+x,73.4483+x,75.8621+x,78.2759+x,
               80.6897+x,83.1034+x,85.5172+x,87.931+x,90.3448+x,92.7586+x,95.1724+x,97.5862+x,100+x]]).T
#Gia tien (vnd)
y = np.array([[ 448.524+tg, 509.248+tg, 535.104+tg,  551.432+tg, 623.418+tg, 625.992+tg, 655.248+tg,701.377+tg, 748.918+tg, 757.881+tg,
                831.004+tg, 855.409+tg, 866.707+tg,902.545+tg,952.261+tg, 995.531+tg,1069.78+tg,1074.42+tg,1103.88+tg,1138.69+tg,
                1153.13+tg,1240.27+tg,1251.9+tg,1287.97+tg,1320.47+tg,1374.92+tg,1410.16+tg,1469.69+tg,1478.54+tg,1515.28+tg]]).T

# Visualize dữ liệu
plt.figure(0)
plt.plot(X, y, 'ro')
plt.axis([30, 120, 400, 1630])
plt.xlabel('Dien tich (m2)')
plt.ylabel('Gia (vnd)')
#plt.show()

# Tinh toan :
one = np.ones((X.shape[0], 1))
Xbar = np.concatenate((one, X), axis = 1)
A = np.dot(Xbar.T, Xbar)
b = np.dot(Xbar.T, y)
w = np.dot(np.linalg.pinv(A), b)

# He so :
print('w = ', w)

# Ve duong thang bieu dien 
w_0 = w[0][0]
w_1 = w[1][0]
x0 = np.linspace(1630, 25, 2)
y0 = w_0 + w_1*x0
plt.figure(1)
plt.plot(X.T, y.T, 'ro')    
plt.plot(x0, y0)               
plt.axis([30, 120, 400, 1630])
plt.xlabel('Dien tich (m2)')
plt.ylabel('Gia (vnd)')

# Du doan du lieu ko dung de training 
y1 = w_1*562 + w_0

print('Du doan gia tien cua 562 m2: %.2f (vnd)'  %(y1) )
# KL: Ket qua du doan kha giong du lieu thuc te 

# Su dung thu vien : Scikit-learn 
# import library scikit-learn
from sklearn import linear_model

# Su dung linear_model của Linear Regression :
regr = linear_model.LinearRegression(fit_intercept=False) 
regr.fit(Xbar, y)

# Tinh toan ket qua :
print( 'Solution found by scikit-learn  : ', regr.coef_ )
print( 'Solution found by (5): ', w.T)
plt.show()
