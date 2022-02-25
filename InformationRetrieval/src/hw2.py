import nltk
raw = ''
tokens = []
dictionary = {}
root_path = 'C:/Users/Asus/Downloads/THTT-TH4-Chuong trinh tim kiem day du/Wiki Docs/'
file_name = ''
for i in range(1, 10):
    file_name = '0' + str(i) + '.txt'
    path = root_path + file_name
    raw = open(path, encoding='utf8').read()
    tokens = nltk.word_tokenize(raw)
    for token in tokens:
        if token not in dictionary:
            dictionary[token] = {}
        if file_name not in dictionary[token]:
            dictionary[token][file_name] = 0
        if token in dictionary and file_name in dictionary[token]:
            dictionary[token][file_name] += 1
for x, y in dictionary.items():
    print(x, y)