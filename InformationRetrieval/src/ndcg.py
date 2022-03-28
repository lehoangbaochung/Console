from math import log

l = [
    (588, 1.0),
    (589, 0.6),
    (576, 0.0),
    (590, 0.8),
    (986, 0.0),
    (592, 1.0),
    (984, 0.0),
    (988, 0.0),
    (578, 0.0),
    (985, 0.0),
    (103, 0.0),
    (591, 0.0),
    (772, 0.2),
    (990, 0.0),
]


def calc_cg(n: int):
    cg = l[0][-1]
    for i in range(1, n + 1):
        cg += l[i][-1]
    return round(cg, 2)


def calc_dcg(n: int):
    dcg = calc_cg(2)
    for i in range(2, n):
        dcg += l[i][-1] / round(log(i, 2), 2)
    return round(dcg, 2)


def calc_idcg(n: int):
    return calc_dcg(n)


def calc_ndcg(n: int):
    return calc_dcg(n) / calc_idcg(n)

print()
for n in range(0, len(l)):
    print(f"CG ({l[n]}, {n + 1}) = {calc_cg(n)}")
print()
for n in range(0, len(l)):
    print(f"DCG ({n}) = {calc_dcg(n)}")
print()
l.sort(key=lambda tup: tup[1], reverse=True)
for n in range(0, len(l)):
    print(f"IDCG ({n}) = {calc_dcg(n)}")
print()
for n in range(0, len(l)):
    print(f"NDCG ({n}) = {calc_ndcg(n)}")
