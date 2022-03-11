import os
from whoosh.index import create_in
from whoosh.fields import *
from whoosh.qparser import QueryParser

dict_path = 'InformationRetrieval\indexdir'
root_path = 'C:\\Users\\Asus\\Downloads\\THTT-TH4-Chuong trinh tim kiem day du\\Wiki Docs'

# Lấy về đường dẫn tới các file văn bản
filepaths = [os.path.join(root_path, fn) for fn in os.listdir(root_path)]

# Nếu thư mục chứa chỉ mục chưa tồn tại thì tạo ra
if not os.path.exists(dict_path):
    os.mkdir(dict_path)

# Định nghĩa lược đồ cho chỉ mục (không lưu trữ trường content)
schema = Schema(title=TEXT(stored=True), path=ID(stored=True), content=TEXT)

# Tạo chỉ mục
ix = create_in(dict_path, schema)
writer = ix.writer()

# Xử lý lần lượt từng file văn bản
for path in filepaths:
    # Mở file
    fp = open(path, 'r')
    print(path)

    # Đọc toàn bộ nội dung file rồi tách xâu dựa trên dấu xuống dòng đầu
    # tiên. Dòng đầu tiên là tiêu đề, phần còn lại là nội dung.
    text = fp.read().split('\n', 1) # 1 nghĩa là chỉ tách xâu 1 lần

    # Tiêu đề trong chỉ mục gồm tên file và tiêu đề văn bản
    writer.add_document(title=path.split('\\')[1] + ': ' + text[0], path=path, content=text[1])

    # Đóng file
    fp.close()

# Kết thúc ghi các văn bản vào chỉ mục
writer.commit()
print('Finished')

def join(query, term):
    result = ''
    split = query.split()
    length = len(split)
    for i in range(length - 1):
        result = f'{split[i]} {term} '
    result += split[length - 1]
    if (term == 'NOT'):
        return term + ' ' + result
    return result

def search(query_raw, term):
    with ix.searcher() as searcher:
        # Xử lý câu truy vấn
        query_string = join(query_raw, term)

        # Hiển thị câu truy vấn
        print('Query (before parse):', query_string)

        # Tìm kiếm trong trường content
        query = QueryParser('content', ix.schema).parse(query_string)
        results = searcher.search(query)

        # Hiển thị câu truy vấn
        print('Query (after parse):', query)

        # Số kết quả trả về
        num_results = len(results)

        if (num_results == 0):
            print('No results')
        else:
            # Hiện các kết quả, mỗi dòng gồm số thứ tự, tiêu đề, điểm số
            for i in range(len(results)):
                print(i, results[i]['title'], str(results[i].score))

            # Yêu cầu người dùng chọn kết quả muốn xem chi tiết
            k = input('Which result do you want to show? ')

            # Mở và hiển thị nội dung file tương ứng với kết quả đã chọn
            try: 
                if (int(k) < len(results)):
                    fp = open(results[k]['path'], 'r')
                    print()
                    print(fp.read())
                    fp.close()
            # Kết thúc nếu người dùng không chọn xem kết quả
            finally: return

# Yêu cầu người dùng nhập vào xâu truy vấn
search(input('Find document containing all words: '), 'AND')
search(input('Find document containing least one word: '), 'OR')
search(input('Find document not containing words: '), 'NOT')