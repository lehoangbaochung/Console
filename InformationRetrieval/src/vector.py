from math import sqrt

# Tập văn bản
docs = [
    'Beautiful is better than ugly',
    'Explicit is better than implicit',
    'Simple is better than complex',
    'Complex is better than complicated',
    'Python is an high-level programming language',
    'Python is a multi-paradigm programming language',
    'Python is dynamically typed and garbage-collected',
    'Python interpreters are available for many operating systems',
    'Python is created by Guido van Rossum and first released in 1991',
    'Python consistently ranks as one of the most popular programming languages',
]

# Tập các từ
terms = ['Python', 'is', 'better', 'than', 'all', 'other', 'high-level', 'programming', 'language']

# Câu truy vấn
query = 'Python is the best'

# Biểu diễn vector
def create_vector(terms: list, doc: str):
    return [doc.split().count(term) for term in terms]

# Chuẩn hoá vector
def normalize_vector(vector: list):
    length = sqrt(sum([point * point for point in vector]))
    return [point / length for point in vector]

# Độ tương tự cosin
def compute_cosin(vector_query: list, vector_doc: list):
    return sum(vector_query[i] * vector_doc[i]
               for i in range(len(vector_query)))

# Khai báo
dictionary = {}
length = len(docs)
vectors = [0] * length
vector_query = create_vector(terms, query)

# Tính điểm số cosin giữa các văn bản với câu truy vấn
for i in range(length):
    vectors[i] = create_vector(terms, docs[i])
    vectors[i] = normalize_vector(vectors[i])
    dictionary[docs[i]] = compute_cosin(vector_query, vectors[i])

# Sắp xếp tập văn bản giảm dần theo điểm số cosin
dictionary = dict(sorted(dictionary.items(), key=lambda item: item[1], reverse=True))

# In các văn bản kèm theo điểm số cosin
index = 1
for doc, score in dictionary.items():
    print(index, doc, score)
    index += 1