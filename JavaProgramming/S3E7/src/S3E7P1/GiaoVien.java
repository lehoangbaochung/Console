package S3E7P1;
public class GiaoVien {
   private String MaGV, HoTen, Diachi;
   private double HeSoLuong;
   public GiaoVien(){}
   public GiaoVien(String MaGV, String HoTen, String Diachi, double HeSoLuong){
       this.MaGV = MaGV;
       this.HoTen = HoTen;
       this.Diachi = Diachi;
       this.HeSoLuong = HeSoLuong;
   }
   public void setMaGV(String MaGV){
       this.MaGV = MaGV;
   }
   public void setHoTen(String HoTen){
       this.HoTen = HoTen;
   }
   public void setDiachi(String Diachi){
       this.Diachi = Diachi;
   }
   public void setHeSoLuong(double HeSoLuong){
       this.HeSoLuong = HeSoLuong;
   }
   public String getMaGV(){
       return MaGV;
   }
   public String getHoTen(){
       return HoTen;
   }
   public String getDiachi(){
       return Diachi;
   }
   public double getHeSoLuong(){
       return HeSoLuong;
   }
}
