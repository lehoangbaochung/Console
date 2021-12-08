package S2E3P1;
public abstract class Mathang {
    String Mamh, Ten;
    double dongia;
    public Mathang(){}
    public Mathang(String Mamh, String Ten, double dongia){
        this.Mamh = Mamh;
        this.Ten = Ten;
        this.dongia = dongia;        
    }
    public void setMamh(String Mamh){
        this.Mamh = Mamh;
    }
    public void setTen(String Ten){
        this.Ten = Ten;
    }
    public void setDongia(double dongia){
        this.dongia = dongia;
    }
    public String getMamh(){
        return Mamh;
    }
    public String getTen(){
        return Ten;
    }    
    public double getDongia(){
        return dongia;
    }
    public abstract void Nhap();
    public abstract void HienThi();
}
