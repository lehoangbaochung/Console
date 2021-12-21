#include <iostream>
#include <algorithm>
using namespace std;
int tang = 0, dem = 0;
int tinh(int a[], int n)
{
	for (int i = 0; i <= n; i++)
	{
		if ((a[i] >= a[i + 1]) && tang <= a[0])
		{
			tang++;
			if (tang == n)
				return tang;
		}
	}
	return tang;
}
bool sosanh(int a, int b)
{
	return a > b;
}
int main()
{
	int n;
	cin >> n;
	int a[n];
	for (int i = 0; i < n; i++)
	{
		cin >> a[i];
	}
	sort(a, a + n, sosanh);
	cout << tinh(a, n);
}
