package S3E4P1;
public class PhuongTrinhBacNhat {
    private int a, b;
    public void setA(int a){
        this.a = a;
    }
    public void setB(int b){
        this.b = b;
    }
    public int getA(){
        return a;
    }
    public int getB(){
        return b;
    }
    public PhuongTrinhBacNhat(){}
    public PhuongTrinhBacNhat(int a, int b){
        this.a = a;
        this.b = b;
    }
    @Override
    public String toString(){
        return ("{"+a+"x+"+b+" = 0}");
    }
    public boolean KiemTra(){
        return (a == (int)a || (b == (int)b) || (a != 0));    
    }
    public String GiaiPT(){
        return (""+-b/a);
    };
}
