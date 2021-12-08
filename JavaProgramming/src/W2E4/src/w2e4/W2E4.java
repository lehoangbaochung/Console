package w2e4;
import java.util.Scanner;

public class W2E4{
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.print("Enter name of supplier: ");
        String NameS = sc.next();
        System.out.print("Enter address: ");
        String Address = sc.next();
        System.out.print("Enter name of product: ");
        String Name = sc.next();
        System.out.print("Enter price of product: ");
        int Price = sc.nextInt();
        System.out.print("Enter number of product: ");
        int Number = sc.nextInt();
        SUPPLIER sp = new SUPPLIER(NameS, Address);
        PRODUCT pd = new PRODUCT(NameS, Address, Name, Price, Number);        
        System.out.print("Enter TC: ");
        int TC = sc.nextInt();
        if (TC == 1)
            System.out.println(sp);
            // khi su dung phuong thuc ghi de toString thi k can goi ten phuong thuc nay
        else
            System.out.println(pd);
    }
}

