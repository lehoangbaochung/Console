package w2e4;
public class SUPPLIER {
    private final String NameS, Address;
    public SUPPLIER(String NameS, String Address){
        this.NameS = NameS;
        this.Address = Address;
    }
    @Override
    public String toString(){
        return NameS+"\t"+Address.substring(0, 3);
    }
}