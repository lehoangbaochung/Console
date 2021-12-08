package S3E1P1;
public class GiaiThua {
    private int n;
    public GiaiThua(){}
    public GiaiThua(int n){
        this.n = n;
    }
    public void setN(int n){
        this.n = n;
    }
    public int getN(){
        return n;
    }
    public boolean KiemTra(){
        return n>0;
    }
    public String TinhGT(){
        int sum=1;
        for(int i=1;i<=n;i++){
            sum=sum*i;
        }
        return String.valueOf(sum);
        
    }
}
