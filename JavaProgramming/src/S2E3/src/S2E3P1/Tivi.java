package S2E3P1;
import java.util.Scanner;
public class Tivi extends Mathang {
    private String LoaiTV;
    private int ManHinh;
    static Scanner s = new Scanner(System.in);
    public void setLoaiTV(String LoaiTV){
        this.LoaiTV = LoaiTV;
    }
    public void setManHinh(int ManHinh){
        this.ManHinh = ManHinh;
    }
    public String getLoaiTV(){
        return LoaiTV;
    }
    public int getManHinh(){
        return ManHinh;
    }
    public Tivi(){}
    public Tivi(String LoaiTV, int ManHinh, String Mamh, String Ten, double dongia){
        super(Mamh, Ten, dongia);
        this.LoaiTV = LoaiTV;
        this.ManHinh = ManHinh;
    }
    @Override
    public void Nhap(){
        System.out.print("Nhap ma mat hang: ");
        Mamh = s.next();
        System.out.print("Nhap ten mat hang: ");
        Ten = s.next();
        System.out.print("Nhap don gia: ");
        dongia = s.nextDouble();
        System.out.print("Nhap loai ti vi: ");
        LoaiTV = s.next();
        System.out.print("Nhap kich co man hinh: ");
        ManHinh = s.nextInt();
    }
    @Override
    public void HienThi(){
        System.out.println(""+getMamh()+"\t"+getTen()+"\t"+getDongia()+"\t"+getLoaiTV()+"\t"+getManHinh());
    }
    public static void main(String[] args) {
        Mathang []DSMH = new Mathang[100];
        int size = 0;
        String nhap;
        do{   
            Mathang tv = new Tivi();
            tv.Nhap();
            DSMH[size] = tv;
            size++;
            System.out.print("Ban co muon tiep tuc nhap khong (y/n)?: ");
            nhap = s.next();           
        }
        while("n".equals(nhap) == false);
        System.out.println("Ma MH\tTen MH\tDon gia\tLoai TV\tKich co man hinh");
        for (int i = 0; i<size; i++)
            DSMH[i].HienThi();
    }
}


