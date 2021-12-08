 import java.util.Scanner;
public class S1E10 {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.print("Nhập n (0<n<100): ");
        int n = sc.nextInt();
        int a[] = new int[n];
        System.out.println("Nhập các phần tử của mảng: ");
        for (int i=0; i<n; i++){
            System.out.printf("a[%d] = ", i);
            a[i] = sc.nextInt();
        }
        System.out.println("Các phần tử của mảng: ");
        show(a);
        max(a);
        sortASC(a);
        show(a);
    }
    public static void show(int[] a) {
        for (int i = 0; i < a.length; i++) {
            System.out.println(a[i] + " ");
        }    
    }
    public static void max(int[] a){
        System.out.println("Phần tử lớn nhất trong mảng: ");
        for (int i=1; i<a.length; i++){
            int m = a[0];
            while (m>a[i])
                m = a[i];
            System.out.println(m);
        }
    }
    public static void sortASC(int[] a){
        System.out.println("Mảng sau khi đã được sắp xếp: ");
        for (int i=0; i<a.length-1; i++)
            for (int j=i+1; j<a.length; j++){
                if (a[i]>a[j]){
                    int temp = a[0];
                    temp = a[j];
                    a[j] = a[i];
                    a[i] = temp;
                }
            }
        }
}
