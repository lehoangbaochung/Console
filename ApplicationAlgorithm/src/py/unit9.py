# Nhập số nguyên dương n
# Hiển thị tất cả số tam phân có độ dài n
def function(n):
    r = ['0', '1', '2']
    for i in range(1, n):
        for j in function(n - i):
            r.append(str(i) + str(j))
    return [k for k in r if len(k) == n]

n = int(input())
print(function(n))