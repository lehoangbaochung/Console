# Cho dãy số a (n phần tử) và số nguyên dương k
# Đếm xem có bao nhiêu cặp số trong a chênh lệch nhau đúng k đơn vị
def function(a, k):
    c = 0
    n = len(a)
    for i in range(n):
        if (a[i] - k) in a[i:] or (a[i] + k) in a[i:]:
            c += 1
    return c

a = list(map(int, input().split(' ')))
k = int(input())
print(function(a, k))