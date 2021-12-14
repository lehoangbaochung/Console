#include <iostream>

using namespace std;

long long function(int n)
{
    if (n < 3)
        return n;
    int k;
    if (n % 3 == 0)
    {
    	k = n / 3;
    	return function(2 * k);
	}
   	else if ((n - 1) % 3 == 0)
   	{
   		k = (n - 1) / 3;
        return function(2 * k) + function(2 * k + 1);
	}
    else
    {
    	k = (n - 2) / 3;
        return function(2 * k) + function(2 * k + 1) + function(2 * k + 2);
	}
	return 0;  
}

int main()
{
    int n;
    cout << "Nhap n = ";
    cin >> n;
    cout << "f(" << n << ") = " << function(n);
    return 0;
}