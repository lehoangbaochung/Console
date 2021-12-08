package w2e4;
public class PRODUCT extends SUPPLIER {
    private final String Name;
    private final int Price, Number;
    
    public PRODUCT(String NameS, String Address, String Name, int Price, int Number) {
        super(NameS, Address);
        this.Name = Name;
        this.Price = Price;
        this.Number = Number;
    }
    
    @Override   
    public String toString() {
        return super.toString()+"\t"+Name+"\t"+Price+"\t"+Number;
    }
    public double Sell_Price(){
        if (Number >= 20)
            return Price*Number*0.8;
        else
            return Price*Number;
    }
}
