##LeHoangBaoChung_1851061805_HW1

import numpy as np

class NeuralNetwork():
    
    def __init__(self):
        # seeding for random number generation
        np.random.seed(1)
        
        self.synaptic_weights = 2 * np.random.random((6, 1)) - 1

    def sigmoid(self, x):
        #applying the sigmoid function
        return 1 / (1 + np.exp(-x))

    def sigmoid_derivative(self, x):
        #computing derivative to the Sigmoid function
        return x * (1 - x)

    def train(self, training_inputs, training_outputs, training_iterations):
        
        #training the model to make accurate predictions while adjusting weights continually
        for iteration in range(training_iterations):
            #siphon the training data via  the neuron
            output = self.think(training_inputs)

            #computing error rate for back-propagation
            error = training_outputs - output
            
            #performing weight adjustments
            adjustments = np.dot(training_inputs.T, error * self.sigmoid_derivative(output))

            self.synaptic_weights += adjustments

    def think(self, inputs):
        #passing the inputs via the neuron to get output   
        #converting values to floats
        
        inputs = inputs.astype(float)
        output = self.sigmoid(np.dot(inputs, self.synaptic_weights))
        return output


if __name__ == "__main__":
    inputs = np.array([4.5,3.2,1.3,0.2,1,0,0,
                                4.5,3.1,1.5,0.2,1,0,0,
                                5.5,3.9,1.7,0.4,1,0,0,
                                4.5,3.4,1.4,0.3,1,0,0,
                                5.5,3.4,1.5,0.2,1,0,0,
                                4.5,2.9,1.4,0.2,1,0,0,
                                4.5,3.1,1.5,0.1,1,0,0,
                                5.5,3.7,1.5,0.2,1,0,0,
                                4.5,3.4,1.6,0.2,1,0,0,
                                4.5,3.0,1.4,0.1,1,0,0,
                                4.5,3.0,1.1,0.1,1,0,0,
                                5.5,4.0,1.2,0.2,1,0,0,
                                5.5,4.4,1.5,0.4,1,0,0,
                                5.5,3.9,1.3,0.4,1,0,0,
                                5.5,3.5,1.4,0.3,1,0,0,
                                5.5,3.8,1.7,0.3,1,0,0,
                                5.5,3.8,1.5,0.3,1,0,0,
                                5.5,3.4,1.7,0.2,1,0,0,
                                5.5,3.7,1.5,0.4,1,0,0,
                                4.5,3.6,1.0,0.2,1,0,0,
                                5.5,3.3,1.7,0.5,1,0,0,
                                4.5,3.4,1.9,0.2,1,0,0,
                                5.5,3.0,1.6,0.2,1,0,0,
                                5.5,3.4,1.6,0.4,1,0,0,
                                5.5,3.5,1.5,0.2,1,0,0,
                                5.5,3.4,1.4,0.2,1,0,0,
                                4.5,3.2,1.6,0.2,1,0,0,
                                4.5,3.1,1.6,0.2,1,0,0,
                                5.5,3.4,1.5,0.4,1,0,0,
                                5.5,4.1,1.5,0.1,1,0,0,
                                5.5,4.2,1.4,0.2,1,0,0,
                                4.5,3.1,1.5,0.2,1,0,0,
                                5.5,3.2,1.2,0.2,1,0,0,
                                5.5,3.5,1.3,0.2,1,0,0,
                                4.5,3.6,1.4,0.1,1,0,0,
                                4.5,3.0,1.3,0.2,1,0,0,
                                5.5,3.4,1.5,0.2,1,0,0,
                                7.5,3.2,4.7,1.4,0,1,0,
                                6.5,3.2,4.5,1.5,0,1,0,
                                6.5,3.1,4.9,1.5,0,1,0,
                                5.5,2.3,4.0,1.3,0,1,0,
                                6.5,2.8,4.6,1.5,0,1,0,
                                5.5,2.8,4.5,1.3,0,1,0,
                                6.5,3.3,4.7,1.6,0,1,0,
                                4.5,2.4,3.3,1.0,0,1,0,
                                6.5,2.9,4.6,1.3,0,1,0,
                                5.5,2.7,3.9,1.4,0,1,0,
                                5.5,2.0,3.5,1.0,0,1,0,
                                5.5,3.0,4.2,1.5,0,1,0,
                                6.5,2.2,4.0,1.0,0,1,0,
                                6.5,2.9,4.7,1.4,0,1,0,
                                5.5,2.9,3.6,1.3,0,1,0,
                                6.5,3.1,4.4,1.4,0,1,0,
                                5.5,3.0,4.5,1.5,0,1,0,
                                5.5,2.7,4.1,1.0,0,1,0,
                                6.5,2.2,4.5,1.5,0,1,0,
                                5.5,2.5,3.9,1.1,0,1,0,
                                5.5,3.2,4.8,1.8,0,1,0,
                                6.5,2.8,4.0,1.3,0,1,0,
                                6.5,2.5,4.9,1.5,0,1,0,
                                6.5,2.8,4.7,1.2,0,1,0,
                                6.5,2.9,4.3,1.3,0,1,0,
                                6.5,3.0,4.4,1.4,0,1,0,
                                6.5,2.8,4.8,1.4,0,1,0,
                                6.5,3.0,5.0,1.7,0,1,0,
                                6.5,2.9,4.5,1.5,0,1,0,
                                5.5,2.6,3.5,1.0,0,1,0,
                                5.5,2.4,3.8,1.1,0,1,0,
                                5.5,2.4,3.7,1.0,0,1,0,
                                5.5,2.7,3.9,1.2,0,1,0,
                                6.5,2.7,5.1,1.6,0,1,0,
                                5.5,3.0,4.5,1.5,0,1,0,
                                6.5,3.4,4.5,1.6,0,1,0,
                                6.5,3.1,4.7,1.5,0,1,0,
                                6.5,2.3,4.4,1.3,0,1,0,
                                5.5,3.0,4.1,1.3,0,1,0,
                                5.5,2.5,4.0,1.3,0,1,0,
                                6.5,3.3,6.0,2.5,0,0,1,
                                5.5,2.7,5.1,1.9,0,0,1,
                                7.5,3.0,5.9,2.1,0,0,1,
                                6.5,2.9,5.6,1.8,0,0,1,
                                6.5,3.0,5.8,2.2,0,0,1,
                                7.5,3.0,6.6,2.1,0,0,1,
                                4.5,2.5,4.5,1.7,0,0,1,
                                7.5,2.9,6.3,1.8,0,0,1,
                                6.5,2.5,5.8,1.8,0,0,1,
                                7.5,3.6,6.1,2.5,0,0,1,
                                6.5,3.2,5.1,2.0,0,0,1,
                                5.5,2.5,5.0,2.0,0,0,1,
                                5.5,2.8,5.1,2.4,0,0,1,
                                6.5,3.2,5.3,2.3,0,0,1,
                                6.5,3.0,5.5,1.8,0,0,1,
                                7.5,3.8,6.7,2.2,0,0,1,
                                7.5,2.6,6.9,2.3,0,0,1,
                                6.5,3.2,5.7,2.3,0,0,1,
                                5.5,2.8,4.9,2.0,0,0,1,
                                7.5,2.8,6.7,2.0,0,0,1,
                                6.5,2.7,4.9,1.8,0,0,1,
                                6.5,3.3,5.7,2.1,0,0,1,
                                7.5,3.2,6.0,1.8,0,0,1,
                                6.5,2.8,4.8,1.8,0,0,1,
                                6.5,3.0,4.9,1.8,0,0,1,
                                6.5,2.8,5.6,2.1,0,0,1,
                                7.5,3.0,5.8,1.6,0,0,1,
                                7.5,2.8,6.1,1.9,0,0,1,
                                7.5,3.8,6.4,2.0,0,0,1,
                                6.5,2.8,5.6,2.2,0,0,1,
                                6.5,2.8,5.1,1.5,0,0,1,
                                6.5,2.6,5.6,1.4,0,0,1,
                                7.5,3.0,6.1,2.3,0,0,1,
                                6.5,3.4,5.6,2.4,0,0,1,
                                6.5,3.1,5.5,1.8,0,0,1,
                                6.5,3.0,4.8,1.8,0,0,1,
                                6.5,3.1,5.4,2.1,0,0,1])

    test = np.array([5.5,3.5,1.3,0.3,1,0,0,
                                4.5,2.3,1.3,0.3,1,0,0,
                                4.5,3.2,1.3,0.2,1,0,0,
                                5.5,3.5,1.6,0.6,1,0,0,
                                5.5,3.8,1.9,0.4,1,0,0,
                                4.5,3.0,1.4,0.3,1,0,0,
                                5.5,3.8,1.6,0.2,1,0,0,
                                4.5,3.2,1.4,0.2,1,0,0,
                                5.5,3.7,1.5,0.2,1,0,0,
                                5.5,3.3,1.4,0.2,1,0,0,
                                5.5,2.6,4.4,1.2,0,1,0,
                                6.5,3.0,4.6,1.4,0,1,0,
                                5.5,2.6,4.0,1.2,0,1,0,
                                5.5,2.7,4.2,1.3,0,1,0,
                                5.5,3.0,4.2,1.2,0,1,0,
                                5.5,2.9,4.2,1.3,0,1,0,
                                6.5,2.9,4.3,1.3,0,1,0,
                                5.5,2.5,3.0,1.1,0,1,0,
                                5.5,2.8,4.1,1.3,0,1,0,
                                6.5,3.1,5.6,2.4,0,0,1,
                                6.5,3.1,5.1,2.3,0,0,1,
                                5.5,2.7,5.1,1.9,0,0,1,
                                6.5,3.3,5.7,2.5,0,0,1,
                                6.5,3.0,5.2,2.3,0,0,1,
                                6.5,2.5,5.0,1.9,0,0,1,
                                6.5,3.0,5.2,2.0,0,0,1,
                                6.5,3.4,5.4,2.3,0,0,1,
                                5.5,3.0,5.1,1.8,0,0,1])

    training_inputs = np.split(inputs,  abs( len(inputs)/7) )

    training_outputs = np.array([])
    for array in training_inputs:
        training_outputs = np.append(training_outputs, array[6])

    training_outputs = np.array(training_outputs).T

    training_output_final = np.array(training_outputs).T
    training_input_final = np.array([])
    for array in training_inputs:
        training_input_final = np.append(training_input_final, np.array(array[0:6]))
    training_input_final = np.split(training_input_final,  abs( len(training_input_final)/6) )

    train_input = []
    train_output = []
    for array in training_input_final:
        array[0] = np.floor(array[0]) + 0.7
        train_input.append(array.tolist())

    for array in training_output_final:
        train_output.append(array.tolist())

    print("\n\nTrain input")
    for array in train_input:
        print(array)

    print("\n\nTrain output")
    print(train_output)

    test_inputs = np.split(test,  abs( len(test)/7) )

    test_outputs = np.array([])
    for array in test_inputs:
        test_outputs = np.append(test_outputs, array[6])

    test_outputs = np.array(test_outputs).T

    test_output_final = np.array(test_outputs).T
    test_input_final = np.array([])
    for array in test_inputs:
        test_input_final = np.append(test_input_final, np.array(array[0:6]))
    test_input_final = np.split(test_input_final,  abs( len(test_input_final)/6) )

    test_input = []
    test_output = []
    for array in test_input_final:
        array[0] = np.floor(array[0]) + 0.7
        test_input.append(array.tolist())

    for array in test_output_final:
        test_output.append(array.tolist())

    print("\n\nTest input")
    for array in test_input:
        print(array)
    print("\n\nTest output")
    print(test_output)
    print("\n\n")

    #initializing the neuron class
    neural_network = NeuralNetwork()

    print("Beginning Randomly Generated Weights: ")
    print(neural_network.synaptic_weights)

    #training taking place
    neural_network.train(np.array(train_input), np.array([train_output]).T, 200000)

    print("Ending Weights After Training: ")
    print(neural_network.synaptic_weights)
        