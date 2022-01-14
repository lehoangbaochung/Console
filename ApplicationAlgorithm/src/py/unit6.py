# Tìm các cặp phần tử có độ chênh lệch giữa chúng là nhỏ nhất trong dãy số A
# Nếu có nhiều cặp như vậy thì in ra tất cả
def function(a):
    r = set()
    n = len(a)
    a = sorted(a)
    m = abs(a[n - 1] - a[0])
    for i in range(1, n):
        d = abs(a[i] - a[i - 1])
        if d < m:
            m = d
    for j in range(1, n):
        d = abs(a[j] - a[j - 1])
        if d == m:
            r.add((a[j], a[j -1]))
    if abs(a[n - 1] - a[0]) == m:
        r.add((a[n - 1], a[0]))
    return r

a = list(map(int, input().split(' ')))
print(function(a))