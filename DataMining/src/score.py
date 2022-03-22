import enum
import numpy as np
import csv


class Score(enum.Enum):
   A = 1
   B = 2
   C = 3
   D = 4
   F = 0


class Subject():
    def __init__(self, id: str, name: str, credit_count: int) -> None:
        self.id = id
        self.name = name
        self.credit_count = credit_count

    def set_score(self, process_score: float, exam_score: float, final_score: float) -> None:
        self.process_score = process_score
        self.exam_score = exam_score
        self.final_score = final_score

    def get_score(self) -> Score:
        if (self.final_score < 4):
           return Score.F
        elif (self.final_score >= 4 and self.final_score < 5.5): 
            return Score.D
        elif (self.final_score >= 5.5 and self.final_score < 7.0): 
            return Score.C
        elif (self.final_score >= 7.0 and self.final_score < 8.5):
           return Score.B
        elif (self.final_score >= 8.5 and self.final_score <= 10):
           return Score.A
        else: 
            return Exception

subjects = []
file = open(f"DataMining/data/score.csv", "r", encoding="utf-8")
data = csv.reader(file)  # csv format
data = np.array(list(data))  # covert to matrix
data = np.delete(data, 0, 0)  # delete header
np.random.shuffle(data)  # shuffle data
file.close()

for row in data:
    subject = Subject(row[0], row[1], row[2])
    subject.set_score(row[3], row[4], float(row[5]))
    subjects.append(subject)

subjects.sort(key=lambda x: x.final_score, reverse=True)
for subject in subjects:
    print(subject.name, subject.get_score().name)
