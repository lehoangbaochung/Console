words = {'一次': 'một lần', '一': 'một', '次': 'lần', '又': 'lại', '爱': 'yêu', '你': 'anh',
         '多': 'nhiều', '甜蜜': 'ngọt ngào', '甜': 'ngọt', '蜜': 'ngào',
		 '梦': 'giấc', '醒': 'tỉnh dậy', '醉': 'say', '时': 'lúc', '欢': 'vui'}
chars = input('input: ')
result = ''
for char in chars:
	if char in words:
		result += words[char] + ' '
print('result:', result.removesuffix(' '))