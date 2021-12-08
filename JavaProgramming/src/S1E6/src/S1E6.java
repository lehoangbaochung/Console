import java.util.Scanner;
import java.lang.Math;
public class S1E6 {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.print("Input a: ");
        double a = sc.nextDouble();
        System.out.print("Input b: ");
        double b = sc.nextDouble();
        System.out.print("Input c: ");
        double c = sc.nextDouble();
        double d = b*b-4*a*c;
        if (d==0){
            double x = -b/2*a;
            System.out.print("Result: x = "+x);
        }
        else if (d>0){
            double x1 = (-b+Math.sqrt(d))/2*a;
            double x2 = (-b-Math.sqrt(d))/2*a;
            System.out.print("Result:\nx1 = "+x1+"\nx2 = "+x2);
        }
        else
            System.out.print("No result!");
    }
}
