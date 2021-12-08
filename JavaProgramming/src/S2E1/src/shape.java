public abstract class shape {
    public shape(){}
    private String Mau;
    private boolean FillMau;
    public boolean isFillMau(){
        return FillMau;
    }
    public String getMau(){
        return Mau;
    }
    public void setFillMau(boolean FillMau){
        this.FillMau = FillMau;
    }
    public void setMau(String Mau){
        this.Mau = Mau;
    }
    public abstract boolean kiemtra();
    public abstract double tinhdientich();
    public abstract double tinhchuvi();
}
