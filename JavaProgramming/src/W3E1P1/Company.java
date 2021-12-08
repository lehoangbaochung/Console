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
public class Company {
    private String NameC ;

    public Company(String NameC) {
        this.NameC = NameC;
    }

    public String getNameC() {
        return NameC;
    }

    public void setNameC(String NameC) {
        this.NameC = NameC;
    }
    
    public String toString(){
        return NameC;
    }
    
}
