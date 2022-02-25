# Le Hoang Bao Chung
# Lop: 60TH3
# MSV: 1851061805

import tkinter as tk
from tkinter import messagebox
import numpy as np
from sklearn.pipeline import make_pipeline
from sklearn.preprocessing import StandardScaler

master = tk.Tk()
tk.Label(master, text="X").grid(row=0, column=0)
tk.Label(master, text="Y").grid(row=0, column=1)

e1 = tk.Entry(master)
e2 = tk.Entry(master)

e1.grid(row=1, column=0)
e2.grid(row=1, column=1)

X = np.array([[2+5.37319011, 1+5.71875981], 
[1+5.51261889, 1+5.40558943], 
[2+5.4696794, 2+5.02144973], 
[1+5.78736889, 1+5.29380961],
[1+5.81231157, 1+5.56119497],
[2+5.03717355, 1+5.93397133],
[1+5.53790057,	1+5.87434722],
[2+5.29312867, 2+5.76537389],
[2+5.29312867, 1+5.86419379],
[1+5.57279694, 0+5.90707347],
[3+5.42746579, 0+5.71254431],
[4+5.24760864, 2+5.39846497],
[3+5.33595491, 1+5.61731637],
[3+5.69420104, 1+5.61731637],
[4+5.53897645, 2+5.54957308],
[3+5.3071994, 0+5.19362396],
[4+5.13924705, 2+5.09561534],
[4+5.47383468, 2+5.41269466],
[4+5.00512009, 1+5.89290099],
[4+5.28205624, 1+5.79675607]])
y = np.array([1,1,1,1,1,1,1,1,1,1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,])

from sklearn.svm import SVC
clf = make_pipeline(StandardScaler(), SVC(gamma='auto'))
clf.fit(X, y)

def predict():
   x = float(e1.get())
   y = float(e2.get()) 
   i = clf.predict([[x,y]])
   messagebox.showinfo("Result", "Label: {}".format(i[0]))

tk.Button(master, text='Show', command=predict).grid(row=3, column=0, sticky=tk.W, pady=4)      
tk.Button(master, text='Quit', command=master.destroy).grid(row=3, column=1, sticky=tk.W, pady=4)                               
master.mainloop()