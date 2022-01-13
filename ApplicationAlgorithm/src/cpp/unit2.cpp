/*
Một cửa hàng có N đồ vật, mỗi đồ vật có trọng lượng w và giá trị p
Một tên trộm lọt vào cửa hàng chỉ có thể lấy trộm số đồ vật có tổng trọng lượng tối đa W đơn vị
Hãy chỉ ra cách lựa chọn các đồ vật ăn trộm sao cho tổng giá trị lấy được là lớn nhất
*/
#include <iostream>

using namespace std;

#pragma region declares variables
int n;         // số lượng đồ vật
int index;     // chỉ số của đồ vật
int p_current; // giá trị của đồ vật đang xét
int w_current; // trọng lượng của đồ vật đang xét
int p_max;     // giá trị tối đa
int w_max;     // trọng lượng tối đa
int w[], p[];
#pragma endregion

int main()
{
    cout << "W = ";
    cin >> w_max;
    cout << "N = ";
    cin >> n;
    for (int i = 0; i < n; i++)
    {
        cout << "W[" << i << "] = ";
        cin >> w[i];
        cout << "P[" << i << "] = ";
        cin >> p[i];
        // lấy đồ vật có giá trị lớn nhất sao cho trọng lượng của nó nhỏ hơn w_max
        if (w_current < w[i] < w_max)
        {
            index = i;
            p_max = p[i];
            w_current = w[i];
        }
    }
    // duyệt để lấy thêm các phần tử khác
    for (int i = 0; i < n; i++)
    {
        p_current = p[i];
        w_current = w[i];
        for (int j = 0; j < n; j++)
        {
            if (j != i && w_current + w[i] <= w_max)
            {
                w_current += w[i];
                p_max += w[i];
            }
        }
            
    }
}