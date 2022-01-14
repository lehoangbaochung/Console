# Nhập 2 số nguyên a,b
# Tính luỹ thừa b của a (a^b)
# Nếu giá trị tìm được quá lớn in ra 9 chữ số cuối cùng
def function(a, b):
    e = pow(a, b)
    if e < 1000000000:
        return e
    else:
        return str(e)[-9:] 

a = int(input("Nhap a = "))
b = int(input("Nhap b = "))
print(function(a, b))