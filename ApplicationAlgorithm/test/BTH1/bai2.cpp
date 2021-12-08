#include<iostream>
#include<algorithm>

using namespace std;

void bubble_sort(int a[], int n) {
	bool swapped = true;
	while (swapped) {
		swapped = false;
		for (int i = 1; i < n; i++) {
			if (a[i] < a[i-1]) {
				swap(a[i], a[i-1]);
				swapped = true;
			}
		}
	}
}

int main() {
	int n;
	cout << "Nhap N: "; cin >> n;
	int a[n];
	for (int i=0;i<n;i++) cin >> a[i];
	bubble_sort(a, n);
	int count = 0, cach = 0;
	for(int i=0;i<n;i++) {
		if(a[i+2]-a[i+1]==a[i+1]-a[i]) cach++;
	}
//	int min = a[1]-a[0];
//	int max = a[n-1]-a[0];
//	
//	for (int i=min;i<=max;i++) {
//		for (int j=1;j<n;j++) {
//			if (a[j]-a[j-1]==i) count++;
//		}
//		if (a[1]-a[0]==i && a[n-1]-a[n-2]==i) {
//			count++;
//			if (count == 5) cach++;
//		}
//	}	
	cout << "So cach: " << cach;
	return 0;
}
