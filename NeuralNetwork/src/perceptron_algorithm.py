import numpy as np

# define unit step
def define_unit_step(u):
	if u >= 0:
		return 1
	else:
		return 0

# design perceptron model
def design_perceptron_model(x, w, w0):
	u = np.dot(x, w) + w0
	y = define_unit_step(u)
	return y

# calculate AND logic gate
# w1 = 1, w2 = 1, w0 = -1.5
def calc_and_logic_gate(x):
	w = np.array([1, 1])
	w0 = -1.5
	return design_perceptron_model(x, w, w0)

# calculate OR logic gate
# w1 = 1, w2 = 1, w0 = -0.5
def calc_or_logic_gate(x):
    w = np.array([1, 1])
    w0 = -0.5
    return design_perceptron_model(x, w, w0)

# calculate NOT logic gate
# w = -1, w0 = 0.5
def calc_not_logic_gate(x):
    w = -1
    w0 = 0.5
    return design_perceptron_model(x, w, w0)

# test the perceptron model
test1 = np.array([0, 1])
test2 = np.array([1, 1])
test3 = np.array([0, 0])
test4 = np.array([1, 0])
test5 = np.array(1)
test6 = np.array(0)

# print results
print("AND({}, {}) = {}".format(0, 1, calc_and_logic_gate(test1)))
print("AND({}, {}) = {}".format(1, 1, calc_and_logic_gate(test2)))
print("AND({}, {}) = {}".format(0, 0, calc_and_logic_gate(test3)))
print("AND({}, {}) = {}".format(1, 0, calc_and_logic_gate(test4)))

print()
print("OR({}, {}) = {}".format(0, 1, calc_or_logic_gate(test1)))
print("OR({}, {}) = {}".format(1, 1, calc_or_logic_gate(test2)))
print("OR({}, {}) = {}".format(0, 0, calc_or_logic_gate(test3)))
print("OR({}, {}) = {}".format(1, 0, calc_or_logic_gate(test4)))

print()
print("NOT({}) = {}".format(1, calc_not_logic_gate(test5)))
print("NOT({}) = {}".format(0, calc_not_logic_gate(test6)))
