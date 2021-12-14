#include <iostream>

using namespace std;

long long function(int n)
{
    if (n == 1 || n == 3)
        return n;
    if (n % 2 == 0)
        return function(n / 2);
   	else
   	{
   		int k;
   		if ((n - 1) % 4 == 0)
   		{
   			k = (n - 1) / 4;
			return 2 * function(2 * k + 1) - function(k);
		}
	    if ((n - 3) % 4 == 0)
	    {
	    	k = (n - 3) / 4;
	    	return 3 * function(2 * k + 1) - 2 * function(k);
		}	
	}
	return 0;  
}

int main()
{
    int n;
    cout << "Nhap n = ";
    cin >> n;
    cout << "g(" << n << ") = " << function(n);
    return 0;
}

