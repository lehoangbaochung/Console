/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Database_QLdiem;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.SQLException;

/**
 *
 * @author Asus
 */
public class DB_Process {
    public boolean db_Insert_diem(String MaSV, String MaHP, double Diem){
        boolean kq = true;
        Connection cn = DB_Connection.getCon();
        String sql = "Insert into diem values ('"+MaSV+"', '"+MaHP+"', "+Diem+")";
        
        try {
            PreparedStatement ps = (PreparedStatement)cn.prepareStatement(sql);
            ps.executeUpdate();
            cn.close();
        } 
        catch (SQLException e) {}
        
        return kq;
    }

}
