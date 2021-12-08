import java.util.Scanner;
public class CanBo extends GiangVien {
    private String ChucVu;
    private double HeSo;
    Scanner s = new Scanner(System.in);
    public void setChucVu(String ChucVu)
    {
        this.ChucVu = ChucVu;
    }
    public String getChucVu()
    {
        return ChucVu;
    }
    public void setHeSo(double HeSo)
    {
        this.HeSo = HeSo;
    }
    public double getHeSo()
    {
        return HeSo;
    }
    public CanBo(){}
    public CanBo(String ChucVu, double HeSo, String Ma, String HoTen, String DiaChi)
    {
        super(Ma, HoTen, DiaChi);
        this.ChucVu = ChucVu;
        this.HeSo = HeSo;        
    }
    public boolean KiemTra(String HoTen)
    {
        return HoTen.equals(super.getHoTen());
    }
    @Override
    public void Nhap()
    {
        System.out.print("Nhap so luong can bo: ");
        int n = s.nextInt();
        for (int i=0; i<n; i++)
        {
            System.out.print("Nhap chuc vu can bo: ");
            ChucVu = s.nextLine();
            System.out.print("Nhap he so luong can bo: ");
            HeSo = s.nextDouble();
        }
    }
    public static void main(String[] args) {

    }
}