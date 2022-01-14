#include <iostream>
#include <algorithm>
using namespace std;

const int N = 10;
int a[N] = {10, 14, 19, 26, 27, 27, 27, 35, 42, 44};

// sap xep noi bot: n phan tu dau tien cua mang a
void bubble_sort(int a[], int n)
{
    bool swapped = true;
    while (swapped)
    {
        swapped = false;
        for (int i = 1; i < n; i++)
            if (a[i] < a[i - 1])
            {
                swap(a[i], a[i - 1]);
                swapped = true;
            }
    }
}

// sap xep chen: n phan tu dau tien cua mang a
void insertion_sort(int a[], int n)
{
    for (int k = 1; k < n; k++)
    {
        int last = a[k], j = k;
        while (j > 0 && a[j - 1] > last)
        {
            a[j] = a[j - 1];
            j--;
        }
        a[j] = last;
    }
}

// sap xep chon: n phan tu dau tien cua mang a
void selection_sort(int a[], int n)
{
    for (int k = 0; k < n - 1; k++)
    {
        int m = k;
        for (int i = k + 1; i < n; i++)
            if (a[m] > a[i])
                m = i;
        swap(a[k], a[m]);
    }
}

// mang phu dung cho sap xep tron
int TA[N];

// tron hai day con a[L..M] va a[M+1..R]
void merge(int a[], int L, int M, int R)
{
    int i = L, j = M + 1;
    for (int k = L; k <= R; k++)
        if (i > M)
            TA[k] = a[j++];
        else if (j > R)
            TA[k] = a[i++];
        else if (a[i] < a[j])
            TA[k] = a[i++];
        else
            TA[k] = a[j++];
    for (int k = L; k <= R; k++)
        a[k] = TA[k];
}

// sap xep tron: n phan tu tu vi tri L den vi tri R
void merge_sort(int a[], int L, int R)
{
    if (L < R)
    {
        int M = (L + R) / 2;
        merge_sort(a, L, M);
        merge_sort(a, M + 1, R);
        merge(a, L, M, R);
    }
}

// phan hoach mang lam hai
int partition(int a[], int L, int R)
{
    int mid = (L + R) / 2;
    int pivot = a[mid];
    swap(a[mid], a[R]);
    int store = L;
    for (int i = L; i <= R - 1; i++)
        if (a[i] < pivot)
        {
            swap(a[store], a[i]);
            store++;
        }
    swap(a[store], a[R]);

    return store;
}

// sap xep nhanh: n phan tu tu vi tri L den vi tri R
void quick_sort(int a[], int L, int R)
{
    if (L < R)
    {
        int M = partition(a, L, R);
        quick_sort(a, L, M - 1);
        quick_sort(a, M + 1, R);
    }
}

// chinh lai heap do loi cua phan tu i, heap toi da n phan tu
void heapify(int a[], int i, int n)
{
    int L = i * 2, R = i * 2 + 1;
    int m = i;
    if (L <= n && a[L] > a[m])
        m = L;
    if (R <= n && a[R] > a[m])
        m = R;
    if (m != i)
    {
        swap(a[i], a[m]);
        heapify(a, m, n);
    }
}

// tao dong tu a[1..n]
void build_heap(int a[], int n)
{
    for (int i = n / 2; i >= 1; i--)
        heapify(a, i, n);
}

// sap xep vun: n phan tu cua a tinh tu a[1]
void heap_sort(int a[], int n)
{
    build_heap(a, n);
    for (int i = n; i > 1; i--)
    {
        swap(a[1], a[i]);
        heapify(a, 1, i - 1);
    }
}

int main(){

}