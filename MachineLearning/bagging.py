from sklearn.svm import LinearSVC
from sklearn.ensemble import BaggingClassifier
import hasy_tools  # pip install hasy_tools

# Load and preprocess data
data = hasy_tools.load_data()
X = data['x_train']
X = hasy_tools.preprocess(X)
X = X.reshape(len(X), -1)
y = data['y_train']

# Reduce dataset
dataset_size = 100
X = X[:dataset_size]
y = y[:dataset_size]

# Define model
svm = LinearSVC(random_state=42)
model = BaggingClassifier(base_estimator=svm, n_estimators=31, random_state=314)

# Fit
model.fit(X, y)