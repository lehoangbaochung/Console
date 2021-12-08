from __future__ import print_function
import numpy as np
import matplotlib.pyplot as plt

# Ho ten: Le Hoang Bao Chung
K = 3
# MSV: 1851061805
x = 5/10 

X = np.array([[6,9,8,6,8,6,7,5,7,9,2,8,3,3,7,9,7,7,4,1],
              [5,9,3,4,5,5,8,4,3,9,5,8,9,9,6,7,4,9,9,3],
              [9,8,7,3,4,9,8,6,4,7,3,6,4,9,9,6,4,5,7,4]]).T + x

def kmeans_display(X, label):
    X0 = X[label == 0, :]
    X1 = X[label == 1, :]
    X2 = X[label == 2, :]

    ax = plt.axes(projection='3d')
    ax.scatter3D(X0[:, 0], X0[:, 1], X0[:, 2])
    ax.scatter3D(X1[:, 0], X1[:, 1], X1[:, 2])
    ax.scatter3D(X2[:, 0], X2[:, 1], X2[:, 2])
    ax.set_xlabel("Toan")
    ax.set_ylabel("Ly")
    ax.set_zlabel("Hoa")  
    plt.show()

from sklearn.cluster import KMeans
kmeans = KMeans(n_clusters=K, random_state=0).fit(X)
print("Centers found by scikit-learn:")
print(kmeans.cluster_centers_)
pred_label = kmeans.predict(X)
print("Label predicted by scikit-learn:")
print(pred_label)
kmeans_display(X, pred_label)