/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Database_QLdiem;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

/**
 *
 * @author Asus
 */
public class DB_Connection {
    @SuppressWarnings("empty-statement")
    public static Connection getCon(){
        Connection conn = null;
        try{
            Class.forName("com.mysql.jdbc.Driver");
            conn = DriverManager.getConnection("jdbc:mysql://localhost/diem","root","12345678");
        }  
        catch(ClassNotFoundException | SQLException e) {};
        
        return conn;
    }
    
    public static void main(String[] args) {
        System.out.println(getCon());
    }
}
