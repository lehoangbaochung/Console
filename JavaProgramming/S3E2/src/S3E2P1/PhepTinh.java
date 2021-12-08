package S3E2P1;
public class PhepTinh {
    private int ToanHang1, ToanHang2;
    private char ToanTu;
    public PhepTinh(){}
    public PhepTinh(int ToanHang1, int ToanHang2, char ToanTu){
        this.ToanHang1 = ToanHang1;
        this.ToanHang2 = ToanHang2;
        this.ToanTu = ToanTu;
    }
    public void setToanHang1(int ToanHang1){
        this.ToanHang1 = ToanHang1;
    }
    public void setToanHang2(int ToanHang2){
        this.ToanHang2 = ToanHang2;
    }
    public void setToanTu(char ToanTu){
        this.ToanTu = ToanTu;
    }
    public int getToanHang1(){
        return ToanHang1;
    }
    public int getToanHang2(){
        return ToanHang2;
    }
    public char getToanTu(){
        return ToanTu;
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
    public double TinhToan(){
        if (ToanTu == '+')
            return ToanHang1 + ToanHang2;
        else if (ToanTu == '-')
            return ToanHang1 - ToanHang2;
        else if (ToanTu == '*')
            return ToanHang1 * ToanHang2;
        else if (ToanTu == '/')
            return ToanHang1 / ToanHang2;
        else
            return 0;
    }
}
