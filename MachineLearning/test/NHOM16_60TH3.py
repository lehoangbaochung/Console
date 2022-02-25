import sys
import six
import pydotplus
import PIL.Image
import numpy as np
import pandas as pd
import matplotlib.pyplot as plt
from tkinter import *
from PIL import ImageTk
from six import StringIO
from IPython.display import Image
from sklearn.tree import _tree
from sklearn.tree import export_graphviz
from sklearn.tree import DecisionTreeClassifier

col_names = ['Temperature','RH','Ws','Rain','DMC','BUI','Classes']
features = col_names[:6]

# Train
df = pd.read_csv("D:/Repositories/MachineLearning/BTL/train.csv", header=1, names=col_names)
X_train = df[features]
y_train = df.Classes

# Test
df_test = pd.read_csv("D:/Repositories/MachineLearning/BTL/test.csv", header=1, names=col_names)
X_test = df_test[features]
y_test = df_test.Classes

# Build model
dtree = DecisionTreeClassifier(criterion="entropy")
dtree = dtree.fit(X_train, y_train)
y_pred = dtree.predict(X_test)

# Create tree
sys.modules['sklearn.externals.six'] = six
dot_data = StringIO()
export_graphviz(dtree, out_file=dot_data, filled=True, rounded=True,
                special_characters=True, feature_names=features, class_names=['0', '1'])
graph = pydotplus.graph_from_dot_data(dot_data.getvalue())
graph.write_png('D:/Repositories/MachineLearning/BTL/tree.png')
Image(graph.create_png())

def ShowDataset(df, title):
    n_bins = 10
    fig, ((ax0,ax1),(ax2,ax3),(ax4,ax5)) = plt.subplots(nrows=3, ncols=2)

    ax0.hist(df['Temperature'], n_bins, histtype='bar')
    ax0.set_title('Temperature')

    ax1.hist(df['RH'], n_bins, histtype='bar')
    ax1.set_title('RH')

    ax2.hist(df['Ws'], n_bins, histtype='bar')
    ax2.set_title('Ws')

    ax3.hist(df['Rain'],n_bins, histtype='bar')
    ax3.set_title('Rain')

    ax4.hist(df['DMC'], n_bins, histtype='bar')
    ax4.set_title('DMC')

    ax5.hist(df['BUI'], n_bins, histtype='bar')
    ax5.set_title('BUI')

    fig.tight_layout()
    fig.suptitle(title)
    plt.show()

# show training data
ShowDataset(df, 'DataTraining')
# show test data
ShowDataset(df_test, 'DataTest')

def inputData():
    f_temp = temperature.get()
    f_rh = rh.get()
    f_ws = ws.get()
    f_rain = rain.get()
    f_dmc=dmc.get()
    f_bui=bui.get()

    label = dtree.predict([[f_temp, f_rh, f_ws, f_rain,f_dmc,f_bui]])[0]
    if(label == 0):
        message.set("Không cháy")
    else:
        message.set("Có cháy")

# defining form function 
def form():
    global window
    window = Tk()
    # set title of screen
    window.title("Cây quyết định")
    # maximize window
    window.state('zoomed')

    # declaring variable
    global message
    global temperature
    global rh
    global ws
    global rain
    global dmc
    global bui

    message = StringVar()
    temperature = StringVar()
    rh = StringVar()
    ws = StringVar()
    rain = StringVar()
    dmc = StringVar()
    bui = StringVar()

    # Creating layout of form
    Label(window, width='200', text="Dự đoán khả năng xảy ra cháy rừng", bg="orange", fg="white").pack()

    Label(window, text="Temperature *").place(x=30, y=360)
    Entry(window, textvariable=temperature).place(x=120, y=360)

    Label(window, text="RH * ").place(x=300, y=360)
    Entry(window, textvariable=rh).place(x=370, y=360)

    Label(window, text="Ws * ").place(x=30, y=400)
    Entry(window, textvariable=ws).place(x=120, y=400)

    Label(window, text="Rain * ").place(x=300, y=400)
    Entry(window, textvariable=rain).place(x=370, y=400)
    
    Label(window, text="DMC * ").place(x=30, y=440)
    Entry(window, textvariable=dmc).place(x=120, y=440)

    Label(window, text="BUI * ").place(x=300, y=440)
    Entry(window, textvariable=bui).place(x=370, y=440)

    Button(window, text="Dự đoán", width=10, height=1, bg="orange", command=inputData).place(x=220, y=480)
    Label(window, text="Khả năng cháy rừng đối với dữ liệu người dùng đã nhập:").place(x=100, y=540)
    Label(window, text="", textvariable=message, bg="orange", fg="white").place(x=420, y=540)
    Label(window, text="Kết quả chương trình", bg="orange", fg="white").place(x=200, y=40)

    count1 = 0
    count2 = 0
    for i in range(len(y_test)):
        if(y_test[i] == y_pred[i]):
            count1 = count1+1
        else:
            count2 = count2+1

    Label(window, text=f"Số lượng mẫu thử: {len(X_test)}").place(x=200, y=80)
    Label(window, text=f"Số nhãn chính xác: {count1}").place(x=200, y=120)
    Label(window, text=f"Số nhãn bị nhầm: {count2}").place(x=200, y=160)
    Label(window, text=f"Tỉ lệ chính xác: {count1/len(X_test)*100}%").place(x=200, y=200)

    load = PIL.Image.open('D:/Repositories/MachineLearning/BTL/tree.png')
    resize_img = load.resize((700, 700))
    render = ImageTk.PhotoImage(resize_img)
    img = Label(window, image=render)
    img.place(x=550, y=30)
    window.mainloop()

# calling function form
form()

# print rule
def get_rules(tree, feature_names, class_names):
    tree_ = tree.tree_
    feature_name = [
        feature_names[i] if i != _tree.TREE_UNDEFINED else "undefined!"
        for i in tree_.feature
    ]
    paths = []
    path = []
    
    def recurse(node, path, paths):    
        if tree_.feature[node] != _tree.TREE_UNDEFINED:
            name = feature_name[node]
            threshold = tree_.threshold[node]
            p1, p2 = list(path), list(path)
            p1 += [f"({name} <= {np.round(threshold, 3)})"]
            recurse(tree_.children_left[node], p1, paths)
            p2 += [f"({name} > {np.round(threshold, 3)})"]
            recurse(tree_.children_right[node], p2, paths)
        else:
            path += [(tree_.value[node], tree_.n_node_samples[node])]
            paths += [path]          
    recurse(0, path, paths)

    # sort by samples count
    samples_count = [p[-1][1] for p in paths]
    ii = list(np.argsort(samples_count))
    paths = [paths[i] for i in reversed(ii)]   

    rules = []
    for path in paths:
        rule = "if "       
        for p in path[:-1]:
            if rule != "if ":
                rule += " and "
            rule += str(p)
        rule += " then "
        if class_names is None:
            rule += "response: "+str(np.round(path[-1][0][0][0],3))
        else:
            classes = path[-1][0][0]
            l = np.argmax(classes)
            rule += f"class: {class_names[l]} (proba: {np.round(100.0*classes[l]/np.sum(classes),2)}%)"
        rule += f" based on {path[-1][1]:,} samples"
        rules += [rule]        
    return rules

rules = get_rules(dtree, features, ['0','1'])
count = 1
for r in rules:
    print("Rule",count,":",r)
    count=count+1