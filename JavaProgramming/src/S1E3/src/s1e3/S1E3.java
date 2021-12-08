import java.util.Scanner;
import java.lang.String;
public class S1E3 {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.print("Input a: ");
        double a = sc.nextDouble();
        System.out.print("Input b: ");
        double b = sc.nextDouble();
        System.out.print("Input operation: ");
        String c = sc.next();
        switch(c){
            case "+":
                double r = a+b;
                System.out.println("Result: "+r);
                break;
            case "-":
                r = a-b;
                System.out.println("Result: "+r);
                break;
            case "*":
                r = a*b;
                System.out.println("Result: "+r);
                break;
            case "/":
                if (b!=0){
                    r = a/b;
                    System.out.println("Result: "+r);
                }
                else
                    System.out.print("Can't devide to 0!");
                break;
            default:
                System.out.println("Incorrect input!");
        }
    }   
}
