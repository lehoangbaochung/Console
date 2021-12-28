def function(w, a):
    n = len(w)
    for i in a:
        if (int(i / n) % 2 == 0):
            print(w[i % n])
        else:
            print(w[::-1][i % n])

a = []
w = input()
m = int(input())
for i in range(m):
    a.append(int(input()))
function(w, a)