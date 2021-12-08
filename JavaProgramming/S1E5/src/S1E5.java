import java.util.Scanner;
public class S1E5 {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.print("Input a: ");
        double a = sc.nextDouble();
        System.out.print("Input b: ");
        double b = sc.nextDouble();
        double x = -b/a;
        System.out.print("Result: x = "+x);
    }
}
