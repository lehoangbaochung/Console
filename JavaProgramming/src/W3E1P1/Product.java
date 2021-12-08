/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package W3E1P1;

/**
 *
 * @author ADMIN
 */
public class Product extends Company {
    private String Name;
    private int Number;
    private int Price;

    public Product() {
        super(null);
    }

    
    public Product(String Name, int Number, int Price, String NameC) {
        super(NameC);
        this.Name = Name;
        this.Number = Number;
        this.Price = Price;
    }

    public double Sell_produc(){
        if(Number>150){
            return Number*Price*0.8;
        }
        else if(Number>=100&&Number<=150){
            return Number*Price *0.9;
        }
        else if(Number>=50&&Number<100){
            return Number*Price*0.95;
        }
        else{
            return Number*Price;
        }
    }
    @Override
    public String toString(){
        return "Product"+"\t"+"Number"+"\t"+"Price"+"\t"+"Company";
    }

    public void setName(String Name) {
        this.Name = Name;
    }

    public void setNumber(int Number) {
        this.Number = Number;
    }

    public String getName() {
        return Name;
    }

    public int getNumber() {
        return Number;
    }

    public int getPrice() {
        return Price;
    }

    public void setPrice(int Price) {
        this.Price = Price;
    }
    @Override
    public String getNameC(){
        return super.getNameC();
    }
    public void setNameC(String nameC){
        super.setNameC(nameC);
    }
    
     
}
