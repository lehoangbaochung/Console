import numpy as np
import statsmodels.api as sm
from sklearn.linear_model import LinearRegression

x = [[1, 200], [5, 700], [8, 800], [6, 400], [3, 100], [10, 600], [9, 550]]
y = [100, 300, 400, 200, 100, 400, 300]
x, y = np.array(x), np.array(y)

print(x)
print(y)

model = LinearRegression().fit(x, y)
print('b0:', model.intercept_)
print('b1 b2:', model.coef_)
y_pred = model.predict(x)
print('Kết quả train với tập test:', y_pred, sep='\n')
r_sq = model.score(x, y)
print('Hệ số tương quan R^2:', r_sq)
x_test = [[7, 680]]
x_test = np.array(x_test)
y_test = model.predict(x_test)
print('Kết quả dự đoán:', y_test, sep='\n')
print('----------------------------------------')

# # Cách 2:
x = sm.add_constant(x)
print(x)
print(y)
model = sm.OLS(y, x)
results = model.fit()
print(results.summary())
print('Hệ số tương quan R^2:', results.rsquared)
print('b0,b1,b2:', results.params)
print('Kết quả train với tập test', results.predict(x), sep='\n')
x_test = sm.add_constant(x_test).reshape((-1,2))
print(x_test)
x_test.T
one = np.ones((x_test.shape[0], 1))
x_test = np.concatenate((one, x_test), axis = 1)
print(x_test)
y_testC2 = results.predict(x_test)
print('Kết quả dự đoán:', y_testC2, sep='\n')






