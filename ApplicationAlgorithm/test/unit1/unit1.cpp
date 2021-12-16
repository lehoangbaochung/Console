#include <iostream>

using namespace std;

int fibonacci(int n)
{
	if (n < 2)
		return n;
	return fibonacci(n - 1) + fibonacci(n - 2);
}

int fuction(int k)
{
	if (k < 0)
		return 0;
	int i = 0;
	while (true)
	{
		if (fibonacci(i) > k)
			return fibonacci(i);
		i++;
	}
}

int main()
{
	int k;
	cout << "Nhap k: ";
	cin >> k;
	cout << "Ket qua: " << fuction(k);
	return 0;
}
