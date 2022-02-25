import numpy as np 

from sklearn.ensemble import BaggingClassifier

from sklearn.svm import SVC

N = 10

X0 = np.array([[2+5.37319011, 1+5.51261889, 2+5.4696794, 1+5.78736889, 1+5.81231157, 2+5.03717355, 1+5.53790057, 2+5.29312867, 1+5.38805594, 1+5.57279694],
[1+5.71875981, 1+5.40558943, 2+5.02144973, 1+5.29380961, 1+5.56119497, 1+5.93397133, 1+5.87434722, 2+5.76537389, 1+5.86419379, 0+5.90707347]]) # class 1

X1 = np.array([[3+5.42746579, 4+5.24760864, 3+5.33595491, 3+5.69420104, 4+5.53897645, 3+5.3071994, 4+5.13924705, 4+5.47383468, 4+5.00512009, 4+5.28205624],
[0+5.71254431, 2+5.39846497, 1+5.61731637, 1+5.94273986, 2+5.54957308, 0+5.19362396, 2+5.09561534, 2+5.41269466, 1+5.89290099, 1+5.79675607]]) # class -1

X = np.concatenate((X0, X1), axis = 1)

y = np.concatenate((np.ones((1, N)), -1*np.ones((1, N))), axis = 1) # labels

y = y.reshape((2*N,))
X = X.T

model = BaggingClassifier(base_estimator=SVC(kernel = 'linear', C = 1e5))

model.fit(X, y)

row = [[5.28205624, 2.79675607]]
yhat = model.predict(row)
print('Predicted Class: %d' % yhat[0])