import numpy as np
import math
import csv


# tính toán khoảng cách
def calc_distance(pointA, pointB, numOfFeature=4):
    tmp = 0
    for i in range(numOfFeature):
        tmp += (float(pointA[i]) - float(pointB[i])) ** 2
    return math.sqrt(tmp)


# tìm k điểm dữ liệu gần nhất
def k_nearest_neighbor(trainSet, point, k):
    distances = []
    for item in trainSet:
        distances.append({
            "label": item[-1],
            "value": calc_distance(item, point)
        })
    distances.sort(key=lambda x: x["value"])
    labels = [item["label"] for item in distances]
    return labels[:k]


# tìm lớp xuất hiện nhiều nhất trong k lớp tìm được
def find_most_occur(arr):
    labels = set(arr)  # set label
    ans = ""
    maxOccur = 0
    for label in labels:
        num = arr.count(label)
        if num > maxOccur:
            maxOccur = num
            ans = label
    return ans


# thực hiện phân lớp
def classify(file_name):
    # load data
    file = open(f"DataMining/data/{file_name}.csv", "r", encoding="utf-8")
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
        print(f"label: {item[-1]} -> predicted: {answer}")
    return round(numOfRightAnwser / len(testSet), 2) * 100


# in ra quá trình phân lớp và độ chính xác tương ứng
print("score:", classify("scorrorre_revised"), '%')