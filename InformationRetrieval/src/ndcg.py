from math import log

l = []


def calc_cg(n: int):
    cg = 0
    for i in range(0, n):
        cg += l[i][-1]
    return round(cg, 2)


def calc_dcg(n: int):
    dcg = calc_cg(2)
    for i in range(2, n):
        dcg += l[i][-1] / round(log(i, 2), 2)
    return round(dcg, 2)


def calc_idcg(n: int):
    sorted(l, key=lambda tup: tup[1], reverse=True)
    return calc_dcg(n)


def calc_ndcg(n: int):
    return calc_dcg(n) / calc_idcg(n)


while(True):
    s = input()
    if (s.startswith("input")):
        s = s.split()
        i = (s[-2], (float)(s[-1]))
        l.append(i)
        print("Item added: ", i)
    elif (s.startswith("sort")):
        l = sorted(l, key=lambda tup: tup[1], reverse=True)
        print(f"Sorted list: {l}")
    elif (s.startswith("cg")):
        n = int(s.split()[-1])
        print(f"CG ({n}) = {calc_cg(n)}")
    elif (s.startswith("dcg")):
        n = int(s.split()[-1])
        print(f"DCG ({n}) = {calc_dcg(n)}")
    elif (s.startswith("idcg")):
        n = int(s.split()[-1])
        print(f"IDCG ({n}) = {calc_idcg(n)}")
    elif (s.startswith("ndcg")):
        n = int(s.split()[-1])
        print(f"NDCG ({n}) = {calc_ndcg(n)}")
    else:
        break
