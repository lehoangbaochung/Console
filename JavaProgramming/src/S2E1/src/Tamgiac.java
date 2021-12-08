import static java.lang.Math.sqrt;
import java.util.Scanner;
public class Tamgiac extends shape{
    public Tamgiac(){}
    private double canh1, canh2, canh3;
    public void setCanh1(double canh1){
        this.canh1 = canh1;
    }
    public void setCanh2(double canh2){
        this.canh2 = canh2;
    }
    public void setCanh3(double canh3){
        this.canh3 = canh3;
    }
    public double getCanh1(){
        return canh1;
    }
    public double getCanh2(){
        return canh2;
    }
    public double getCanh3(){
        return canh3;
    };
    @Override
    public boolean kiemtra()
    {
        return (canh1 + canh2 > canh3) || (canh1 + canh3 > canh2) || (canh2 + canh3 > canh1);       
    }
    @Override
    public double tinhchuvi(){
        return canh1 + canh2 + canh3;
    }
    @Override
    public double tinhdientich(){
        double p = (canh1 + canh2 + canh3)/2;
        return sqrt(p*(p-canh1)*(p-canh2)*(p-canh3));
    }
    public static void main(String[] args){
        Tamgiac tg = new Tamgiac();
        Scanner sc = new Scanner(System.in);
        System.out.println("Nhap gia tri cua ba canh: ");
        double canh1 = sc.nextDouble(); tg.setCanh1(canh1);
        double canh2 = sc.nextDouble(); tg.setCanh2(canh2);
        double canh3 = sc.nextDouble(); tg.setCanh3(canh3);
        if (tg.kiemtra() == true){
            System.out.println("Ba canh vua nhap tao thanh mot tam giac!");
            System.out.println("Chu vi cua tam giac la: "+tg.tinhchuvi());
            System.out.println("Dien tich cua tam giac la: "+tg.tinhdientich());
        }
        else
            System.out.print("Ba canh vua nhap khong tao thanh mot tam giac!");      
    }
}