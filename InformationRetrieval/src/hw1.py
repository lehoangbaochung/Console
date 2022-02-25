import nltk
dictionary = {}
raw = open('C:/Users/Asus/Downloads/README.txt', encoding='utf8').read()
tokens = nltk.word_tokenize(raw)
for token in tokens:
    if token not in dictionary:
        dictionary[token] = 0
    else:
        dictionary[token] += 1
for key, value in dictionary.items():
    print(key, value)