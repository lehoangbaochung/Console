#include <iostream>
#include <bits/stdc++.h>
using namespace std;

string w;
int n;

char function(int a)
{
    string m = w;
    int l = w.length();
    reverse(m.begin(), m.end());
    if ((int)(i / n) % 2 == 0)
        return w[i % n];
    else
        return m[i % n];
}

int main()
{
    cin >> w;
    cin >> n;
    int a;
    for (int i = 0; i < n; i++)
    {
        cin >> a;
        cout << function(a);
    }
    return 0;
}