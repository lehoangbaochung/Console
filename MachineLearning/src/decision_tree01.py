import pandas as pd
from sklearn.tree import DecisionTreeClassifier 
from sklearn.model_selection import train_test_split
from sklearn import metrics
col_names = ['pregnant', 'glucose', 'bp', 'skin', 'insulin', 'bmi', 'pedigree', 'age', 'label']
# load dataset
pima = pd.read_csv("C:\\Users\\Asus\\Downloads\\diabetes.csv", header=1, names=col_names)
feature_cols=[0, 4, 5, 7, 1, 2, 6] # keep these
X = pima.iloc[:,feature_cols]
y = pima.label
X_train, X_test, y_train, y_test = train_test_split(X, y)
classifier = DecisionTreeClassifier()
classifier = classifier.fit(X_train,y_train) # train
y_pred = classifier.predict(X_test) # predict
print("Accuracy:",metrics.accuracy_score(y_test, y_pred)) 

from sklearn.tree import export_graphviz
from six import StringIO
from IPython.display import Image  
import pydotplus

from sklearn.tree import export_graphviz
import six
import sys
sys.modules['sklearn.externals.six'] = six
from IPython.display import Image
import pydotplus
dot_data = StringIO()
export_graphviz(classifier, out_file=dot_data,
 filled=True, rounded=True,
 special_characters=True,
 feature_names = feature_cols,
 class_names=['0','1'])
graph = pydotplus.graph_from_dot_data(dot_data.getvalue())
graph.write_png('C:\\Users\\Asus\\Downloads\\diabetes.png')
Image(graph.create_png())

