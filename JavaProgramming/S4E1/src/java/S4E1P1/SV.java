package S4E1P1;

import java.util.Date;

public class SV {
    String maSV, Hoten, GT, QQ, MaL, NS;

    public SV(String maSV, String Hoten, String GT, String QQ, String MaL, String NS) {
        this.maSV = maSV;
        this.Hoten = Hoten;
        this.GT = GT;
        this.QQ = QQ;
        this.MaL = MaL;
        this.NS = NS;
    }
    
    public SV(){}
    
    public String getMaSV() {
        return maSV;
    }

    public void setMaSV(String maSV) {
        this.maSV = maSV;
    }

    public String getHoten() {
        return Hoten;
    }

    public void setHoten(String Hoten) {
        this.Hoten = Hoten;
    }

    public String getGT() {
        return GT;
    }

    public void setGT(String GT) {
        this.GT = GT;
    }

    public String getQQ() {
        return QQ;
    }

    public void setQQ(String QQ) {
        this.QQ = QQ;
    }

    public String getMaL() {
        return MaL;
    }

    public void setMaL(String MaL) {
        this.MaL = MaL;
    }

    public String getNS() {
        return NS;
    }

    public void setNS(String NS) {
        this.NS = NS;
    }
}
