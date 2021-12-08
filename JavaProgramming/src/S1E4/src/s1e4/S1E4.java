import java.util.Scanner;
public class S1E4 {
    static int UCLN(int a, int b){
        if (b==0)
            return a;
        else
            return UCLN(b, a%b);
    }
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.print("Nhập tử số: ");
        int a = sc.nextInt();
        System.out.print("Nhập mẫu số: ");
        int b = sc.nextInt();
        if ((a%UCLN(a,b))==0 && b%UCLN(a,b)==0 && (UCLN(a,b)!=1)){
            b = b/UCLN(a,b);
            a = a/UCLN(a,b);
            System.out.print("Phân số tối giản: "+a+"/"+b);
        }
        else
            System.out.print("Phân số đã được tối giản!: "+a+"/"+b);
    }
}
