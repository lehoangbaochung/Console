#include <iostream>
using namespace std;

const int MAX = 1000;

int n, x[MAX];

int main() {
	cout << "N = "; cin >> n;
	x[0] = 1 , x[1] = 1;
	for (int i = 2; i <= n ; i++)
        x[i] = x[i - 1] + 2 * x[i - 2]; 
    cout << "So phuong an = " << x[n];
	return 0;
}