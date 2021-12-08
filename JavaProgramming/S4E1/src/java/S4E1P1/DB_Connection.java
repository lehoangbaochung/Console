/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package S4E1P1;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
//import javax.naming.ldap.ManageReferralControl;

/**
 *
 * @author NUCATI
 */
public class DB_Connection {
    
    
    public static Connection getConn(){
        Connection conn = null; // Tra ve mot chuoi ket noi
        try {
            // Khai bao May ao chua CSDL
            Class.forName("com.mysql.jdbc.Driver");
            conn = DriverManager.getConnection("jdbc:mysql://localhost:3306/java_web","root","12345678");
            
            
        } catch (ClassNotFoundException | SQLException e) {
            // System.out.println(e);
        }
        
          
        return conn;
    }
    public static void main(String[] args)
    {
       // DB_Connection conn = new DB_Connection();
        System.out.println(DB_Connection.getConn());
    }
}
