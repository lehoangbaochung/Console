package S3E5P1;

import static java.lang.Math.sqrt;

public class PhuongTrinhBac2 {
    private int a, b, c;
    public PhuongTrinhBac2(){}
    public PhuongTrinhBac2(int a, int b, int c){
        this.a = a;
        this.b = b;
        this.c = c;
    }
    public void setA(int a){
        this.a = a;
    }
    public void setB(int b){
        this.b = b;
    }
    public void setC(int c){
        this.c = c;
    }
    public int getA(){
        return a;
    }
    public int getB(){
        return b;
    }
    public int getC(){
        return c;
    }
    public boolean KiemTra(){
        return ((a != 0) || (a == (int)a) || (b == (int)b) || (c == (int)c));
    }
    @Override
    public String toString(){
        if (b < 0 && c > 0)
            if (b == -1)
                return "{"+a+"x^2-x+"+c+" = 0}";
            else
                return "{"+a+"x^2"+b+"x+"+c+" = 0}";
        else if (b < 0 && c < 0)
            if (b == -1)
                return "{"+a+"x^2-x"+c+" = 0}";
            else
                return "{"+a+"x^2"+b+"x"+c+" = 0}";
        else if (b > 0 && c < 0)
            if (b == 1)
                return "{"+a+"x^2+x"+c+" = 0}";
            else
                return "{"+a+"x^2+"+b+"x"+c+" = 0}";
        return "{"+a+"x^2+"+b+"x+"+c+" = 0}";
    }
    public String GiaiPT(){
        int delta = b*b-4*a*c;
        if (delta <0)
            return "Phương trình vô nghiệm!";
        else if (delta == 0)
            return "x1 = x2 = "+(-b/(2*a));
        else
            return "x1 = "+((-b+sqrt(delta)/(2*a)))+"; x2 = "+((-b-sqrt(delta)/(2*a)));
    }
}
