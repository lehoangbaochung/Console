#include<iostream>

using namespace std;

int fibo(int n) {
	if (n < 2) return n;
	return fibo(n-1)+fibo(n-2);
}

int bai1(int k) {
	if (k<0) return 0;
	int i=0;
	while (true) {
		if (fibo(i) > k) 
			return fibo(i);
		i++;
	}
}

int main() {
	int k;
	cout << "Nhap k: "; cin >> k;
	cout << "Ket qua: " << bai1(k);
	return 0;
}
