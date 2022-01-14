# Cho dãy số nguyên a gồm n phần tử
# Chọn ra k số trong a sao cho chênh lệch giữa các số là tối thiểu
# In ra sự chênh lệch đó
def function(a, k):
    a = sorted(a)
    return a[k - 1] - a[0]

a = list(map(int, input().split(' ')))
k = int(input())
print(function(a, k))