from tkinter import *
from knn import *



    
root = Tk()
root.geometry("200x250")

mylabel = Label(root, text='Scrollbars', font="30")
mylabel.pack()

myscroll = Scrollbar(root)
myscroll.pack(side=RIGHT, fill=Y)

mylist = Listbox(root, yscrollcommand=myscroll.set)

mylist.pack(side=LEFT, fill=BOTH)

myscroll.config(command=mylist.yview)



v = StringVar()
t = ''
label = Label(root, textvariable=v)
label.pack()

file = open(f"DataMining/data/iris.csv", "r", encoding="utf-8")
data = csv.reader(file)  # csv format
data = np.array(list(data))  # convert to matrix
data = np.delete(data, 0, 0)  # delete header
np.random.shuffle(data)  # shuffle data
file.close()

# parse data
trainSet = data[:100]  # training data from 1->100
testSet = data[100:]  # the others is testing data

# duyệt qua các giá trị trong bộ dữ liệu test để kiểm tra
numOfRightAnwser = 0
for item in testSet:
    knn = k_nearest_neighbor(trainSet, item, 5)
    answer = find_most_occur(knn)
    numOfRightAnwser += item[-1] == answer
    t += f"label: {item[-1]} -> predicted: {answer}\n"
    v.set(t)
    mylist.insert(0, t)

root.mainloop()
