#include <iostream>
#include <vector>

using std::vector;

int max(int a, int n) {}

// Phương pháp 1: duyệt toàn bộ cặp (i,j)
int tong_max(vector<int> &a, int n)
{
    int m = a[1];
    for (int i = 1; i <= n; i++)
        for (int j = i; j <= n; j++)
        {
            int s = 0;
            for (int k = i; k <= j; k++)
                s += a[k];
            if (s > m)
                m = s;
        }
    return m;
}

// Phương pháp 2: duyệt nhưng tận dụng lại tổng cũ
int tong_max2(vector<int> &a, int n)
{
    int m = a[1];
    for (int i = 1; i <= n; i++)
    {
        int s = 0;
        for (int j = i; j <= n; j++)
        {
            s += a[j];
            if (s > m)
                m = s;
        }
    }
    return m;
}

// Phương pháp 3: chia để trị
int tong_max3(vector<int> &a, int dau, int cuoi)
{
    // xét trường hợp độ dài là 1
    if (dau == cuoi)
        return a[dau];
    // chia đôi dãy: (dau, mid) + (mid+1, cuoi)
    int mid = (dau + cuoi) / 2;
    // tính max trong 3 trường hợp
    int m_trai = tong_max3(a, dau, mid);
    int m_phai = tong_max3(a, mid + 1, cuoi);
    int m_giua = trai(a, dau, mid) + phai(a, mid + 1, cuoi);
    // trả về max của 3 trường hợp
    return max(m_giua, max(m_trai, m_phai));
}

// tìm đoạn max phía trái (kết thúc ở cuoi)
int trai(vector<int> &a, int dau, int cuoi)
{
    int m = a[cuoi], s = 0;
    for (int i = cuoi; i >= dau; i--)
    {
        s += a[i];
        if (s > m)
            m = s;
    }
    return m;
}

// tìm đoạn max phía phải (bắt đầu từ dau)
int phai(vector<int> &a, int dau, int cuoi)
{
    int m = a[dau], s = 0;
    for (int i = dau; i <= cuoi; i++)
    {
        s += a[i];
        if (s > m)
            m = s;
    }
    return m;
}

// Phương pháp 4: quy hoạch động
int tong_max4(vector<int> &a, int n)
{
    vector<int> w(n + 1);
    w[1] = a[1];
    for (int k = 2; k <= n; k++)
        w[k] = max(a[k], w[k - 1] + a[k]);
    int m = w[1];
    for (int i = 2; i <= n; i++)
        if (m < w[i])
            m = w[i]; 
    return m;
}

// Phương pháp 4.1: quy hoạch động tối ưu hơn
int tong_max4_1(vector<int> &a, int n)
{
    int w = a[1], m = a[1];
    for (int k = 2; k <= n; k++)
    {
        if (w > 0)
            w = w + a[k];
        else
            w = a[k];
        if (w > m)
            m = w;
    }
    return m;
}
