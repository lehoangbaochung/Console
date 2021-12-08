import java.util.Scanner;
import java.lang.Math;
public class S1E1{
    public static void main(String[] args){
        try (Scanner sc = new Scanner(System.in)) {
            System.out.print("Nhập a: ");
            int a = sc.nextInt();
            System.out.print("Nhập b: ");
            int b = sc.nextInt();
            System.out.print("Nhập c: ");
            int c = sc.nextInt();
            if (a+b>c && a+c>b && b+c>a){
                System.out.println("Ba số a,b,c đã nhập tạo thành một tam giác!");
                int p = a+b+c;
                double s = Math.sqrt(p/2*(p/2-a)*(p/2-b)*(p/2-c));
                System.out.println("Chu vi tam giác: p = "+p);
                System.out.println("Diện tích tam giác: s = "+s);
            }
            else
                System.out.println("Ba số a,b,c đã nhập không phải là ba cạnh của tam giác!");
        }
    }
}
