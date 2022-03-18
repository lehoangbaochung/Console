import csv
import math
import random


# phân tách dữ liệu theo lớp
def separateByClass(dataset):
    separated = {}
    for i in range(len(dataset)):
        vector = dataset[i]
        if (vector[-1] not in separated):
            separated[vector[-1]] = []
            separated[vector[-1]].append(vector)
    return separated


# tính trung bình
def mean(numbers):
    return sum(numbers) / float(len(numbers))


# tính độ lệch chuẩn
def stdev(numbers):
    avg = mean(numbers)
    variance = sum([pow(x-avg, 2) for x in numbers])/float(len(numbers)-1)
    return math.sqrt(variance)

# tóm tắt dữ liệu


def summarize(dataset):
    summaries = [(mean(attribute), stdev(attribute))
                 for attribute in zip(*dataset)]
    del summaries[-1]
    return summaries

# tóm tắt các thuộc tính theo lớp


def summarizeByClass(dataset):
    separated = separateByClass(dataset)
    summaries = {}
    for classValue, instances in separated.items():
        summaries[classValue] = summarize(instances)
    return summaries
