import java.util.Scanner;
public class S1E2 {
    static int factorial(int n){
        if (n==1)
            return 1;
        else
            return n*factorial(n-1);
    }
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.print("Nhập vào một số nguyên: ");
        int n = sc.nextInt();
        if (n>0){
            System.out.print(n+"! = "+factorial(n));
        }
        else
            System.out.print("n<0 !");        
    } 
}