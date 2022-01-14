# Cho dãy số a (n phần tử) và số nguyên dương k (0 < k < n)
# Tìm phần tử nhỏ thứ k trong dãy số a
def function(a, k):
    return sorted(a)[k - 1]
    
a = list(map(int, input().split(' ')))
k = int(input())
print(function(a, k))