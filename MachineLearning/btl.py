import pandas as pd
from sklearn import metrics
import pydotplus;
from sklearn.tree import DecisionTreeClassifier
from sklearn.model_selection import train_test_split

col_names=['Temperature', 'RH', 'Ws', 'Rain', 'FFMC', 'DMC','DC','ISI','BUI','FWI','Classes']
df = pd.read_csv("forest_fire.csv")

features = ['Temperature', 'RH', 'Ws', 'Rain', 'FFMC', 'DMC','DC','ISI','BUI','FWI']

X = df[features]
y = df['Classes']

X_train, X_test, y_train, y_test = train_test_split(X, y,test_size=0.3, random_state=1)

dtree = DecisionTreeClassifier(criterion="entropy")
dtree = dtree.fit(X_train,y_train)
y_pred = dtree.predict(X_test)

# Model Accuracy, how often is the classifier correct?
print("Accuracy:",metrics.accuracy_score(y_test, y_pred))
print(y_pred)

from sklearn.tree import export_graphviz
from six import StringIO
from IPython.display import Image  
import pydotplus
import six
import sys

sys.modules['sklearn.externals.six'] = six

from IPython.display import Image
import pydotplus

dot_data = StringIO()
export_graphviz(dtree, out_file=dot_data,  
                filled=True, rounded=True,
                special_characters=True, feature_names = features,class_names=['0','1'])
graph = pydotplus.graph_from_dot_data(dot_data.getvalue())  
graph.write_png('tree.png')

from tkinter import *
from PIL import ImageTk, Image  

#defining login function
def login():
    #getting form data
    f_temp=temperature.get();
    f_rh=rh.get()
    f_ws=ws.get()
    f_rain=rain.get()
    f_ffmc=ffmc.get()
    f_dmc=dmc.get();
    f_dc=dc.get();
    f_isi=isi.get();
    f_fwi=fwi.get();
    f_bui=bui.get();
    
    label=dtree.predict([[f_temp,f_rh, f_ws, f_rain, f_ffmc,f_dmc,f_dc,f_isi,f_fwi,f_bui]])[0]
    if(label==0):
        message.set("No fire")
    else:
        message.set("fire")    
    
#defining loginform function
def form():
    global login_screen
    login_screen = Tk()
    #Setting title of screen
    login_screen.title("Input Form")
    #setting height and width of screen
    login_screen.geometry("550x250")
    #declaring variable
    global message;
    global temperature;
    global ws;
    global rain;
    global ffmc;
    global dmc;
    global dc;
    global isi;
    global fwi;
    global bui;
    global rh;
    
    message=StringVar()
    temperature = StringVar()
    ws = StringVar()
    rain = StringVar()
    ffmc=StringVar()
    dmc=StringVar()
    dc=StringVar()
    isi = StringVar()
    fwi = StringVar()
    bui = StringVar()
    rh  = StringVar()
    
    #Creating layout of login form
    Label(login_screen,width='200', text="Please enter details below", bg="orange",fg="white").pack()
    
    Label(login_screen, text="Temperature *").place(x=20,y=40)
    Entry(login_screen, textvariable=temperature).place(x=100,y=42)

    Label(login_screen, text="RH * ").place(x=300,y=40)
    Entry(login_screen, textvariable=rh).place(x=370,y=42)

    Label(login_screen, text="Ws * ").place(x=20,y=80)
    Entry(login_screen, textvariable=ws).place(x=100,y=82)

    Label(login_screen, text="Rain * ").place(x=300,y=80)
    Entry(login_screen, textvariable=rain).place(x=370,y=82)
 
    Label(login_screen, text="FFMC * ").place(x=20,y=110)
    Entry(login_screen, textvariable=ffmc).place(x=100,y=112)
    
    Label(login_screen, text="DMC * ").place(x=300,y=110)
    Entry(login_screen, textvariable=dmc).place(x=370,y=112)
    
    Label(login_screen, text="DC * ").place(x=20,y=140)
    Entry(login_screen, textvariable=dc).place(x=100,y=142)
    
    Label(login_screen, text="ISI * ").place(x=300,y=140)
    Entry(login_screen, textvariable=isi).place(x=370,y=142)
  
    Label(login_screen, text="BUI * ").place(x=20,y=170)
    Entry(login_screen, textvariable=bui).place(x=100,y=172)
    
    Label(login_screen, text="FWI * ").place(x=300,y=170)
    Entry(login_screen, textvariable=fwi).place(x=370,y=172)
  
    Label(login_screen, text="",textvariable=message).place(x=120,y=190)
   
    Button(login_screen, text="Login", width=10, height=1, bg="orange",command=login).place(x=170,y=220)
    load = Image.open("tree.png")
    
    resize_img = load.resize((300, 500))
    render = ImageTk.PhotoImage(resize_img)
    img = Label(login_screen, image=render)
    img.place(x=500, y=20)
    
    login_screen.mainloop()
#calling function Loginform
form()


