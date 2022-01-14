#include <iostream>
using namespace std;
int a[10000];
int n, k, dem = 0
bool print(int n){
    int v = 1;
    for (int i = 1; i <= n; i++)
    {
        v *= a[i];
    }
    return v >= k;
}
void sinh(int k, int s){
    if (s==n){
        if(print(k-1)) {
            dem++;
        }
        return;
    }
    for (int i = n; i >= 1; i--){
        a[k] = i;
        if(s+i<=n&&a[k]<=a[k-1]){
            sinh(k + 1, s + i);
        }
    }
}
int main(){
    cout << "N = ";
    cin >> n;
    cout << "K = ";
    cin >> k;
    a[0] = n;
    sinh(1, 0);
    cout << "So cach phan tich cap K = " << dem;
}