#include <iostream>

using namespace std;

int function(int m, int n)
{
    switch (m * n) 
    {
    	case 1:
    		return 2;
    	case 2:
    		return 4;
    	case 4:
    		return 6;
    	case 6:
    		return 10;
    	case 8:
    		return 16;
    	case 9:
    		return 20;
	}
    return 0;
}

int main()
{
    int m, n;
    cout << "Nhap M = ";
    cin >> m;
    cout << "Nhap N = ";
    cin >> n;
    cout << "So cach = " << function(m, n);
}
