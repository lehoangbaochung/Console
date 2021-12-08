import java.util.Scanner;

public class GiangVien {
    private String Ma, HoTen, DiaChi;
    public void setMa(String Ma)
    {
        this.Ma = Ma;
    }
    public String getMa()
    {
        return Ma;
    }
    public void setHoTen(String HoTen)
    {
        this.HoTen = HoTen;
    }
    public String getHoTen()
    {
        return HoTen;
    }
    public void setDiaChi(String DiaChi)
    {
        this.DiaChi = DiaChi;
    }
    public String getDiaChi()
    {
        return DiaChi;
    }
    public GiangVien(){}
    public GiangVien(String Ma, String HoTen, String DiaChi)
    {
        this.Ma = Ma;
        this.HoTen = HoTen;
        this.DiaChi = DiaChi;
    }
    public void Nhap()
    {
        Scanner s = new Scanner(System.in);
        System.out.print("Nhap so luong giang vien: ");
        int n = s.nextInt();
        for (int i=0; i<n; i++)
        {
            System.out.print("Nhap ma giang vien: ");
            Ma = s.nextLine();
            System.out.print("Nhap ho ten giang vien: ");
            HoTen = s.nextLine();
            System.out.print("Nhap dia chi giang vien: ");
            DiaChi = s.nextLine();
        }
    }
    public void HienThi()
    {
        System.out.println("Ma: "+getMa());
    }
}