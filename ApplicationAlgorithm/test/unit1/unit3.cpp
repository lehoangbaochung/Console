#include<iostream>

using namespace std;

int height(int a[], int n) {
	int max=a[0];
    for (int i=1;i<n;i++)
        if (a[i]>max)
        	max = a[i];
	if(max>=n)
		return n;
	else
		return max+1;
}

int main() {
	int n;
	cin >> n;
	int a[n];
	for(int i=0;i<n;i++) {
		cin >> a[i];
	}
	cout << height(a,n);
}
