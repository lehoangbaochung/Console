package S3E3P1;

public class PhanSo {
    private int TuSo, MauSo;
    public PhanSo(){}
    public PhanSo(int TuSo, int MauSo){
        this.TuSo = TuSo;
        this.MauSo = MauSo;
    }
    public void setTuSo(int TuSo){
        this.TuSo = TuSo;
    }
    public void setMauSo(int MauSo){
        this.MauSo = MauSo;
    }
    public int getTuSo(){
        return TuSo;
    }
    public int getMauSo(){
        return MauSo;
    }
    public boolean KiemTra(String s){
        try{
            Integer.parseInt(s);
        }
        catch(NumberFormatException e){
            return false;
        }
        return true;
    }
    public String rutgon(){
        if (TuSo == 0 || MauSo == 0)
            return ""+TuSo+"/"+MauSo;
        else
            while (TuSo != MauSo){
                if (TuSo > MauSo)
                    TuSo -= MauSo;
                else
                    MauSo -= TuSo;
            }
        return ""+TuSo+"/"+MauSo;
    }
    public double Tinhtoan(){
        return TuSo/MauSo;
    }
}
