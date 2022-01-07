#include<iostream>
using namespace std;
const int M = 1000;
int a;
int sinh(int a,int b){
	if(b==1)
		if(a==1) return 1;
		else return 0;
	int c=a-b;
	if(c==0) return sinh(a,b-1)+1;
	else
		if(c<b) return sinh(a,b-1)+sinh(c,c);
		else return sinh(a,b-1)+sinh(c,b-1);
}
 int main(){
 	cout<<"Nhap k = ";
 	cin>>a;
 	cout<<"Co tat ca "<<sinh(a,a)-1<<" cach phan tich.";
 }