/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package S4E1P1;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.util.ArrayList;

/**
 *
 * @author NUCATI
 */
public class DB_Process 
{
    public ArrayList<SV> db_Find_SV()
    {
    ArrayList<SV> lsv = new ArrayList();
    //khai bao bien ket noi
    Connection cn = DB_Connection.getConn();
    //khai bao cau lenh sql
    String sql = "select * from tbsinhvien";
    
    try{
        //khai bao de ket noi cau lenh sql voi mysql
        PreparedStatement ps = (PreparedStatement)cn.prepareStatement(sql);
    
        //do du lieu tu ps vao doi tuong result set
        ResultSet rs = ps.executeQuery();
        
        //do du lieu tu result set vao array list
        while(rs.next())
        {
            //khai bao bien de lay du lieu cua cac truong tuong ung trong bang
            
            String masv  = rs.getString("masv");
            String ht  = rs.getString("ht");
            String ns = rs.getString("ns");
            String gt  = rs.getString("gt");
            String malop  = rs.getString("malop");
            String qq = rs.getString("qq");
            SV sv = new SV(masv,ht,gt,malop,qq,ns);
            
            lsv.add(sv);
        }  
        //xong roi thi dong csdl ,khong thi xung dot du lieu
        cn.close();
    }
    
   catch(Exception e)
   {
       
   }
    return lsv;
    }
    //tim kiem co dieu kien
    /*note:co bao nhieu
     *dieu kien can tim 
     *kiem thi can phai khai 
     *bao bay nhieu bien trong para
    */
   public ArrayList<SV> db_Find_SV(String gt,String qq)
    {
    ArrayList<SV> lsv = new ArrayList();
    //khai bao bien ket noi
    Connection cn = DB_Connection.getConn();
    //khai bao cau lenh sql
    String sql = "SELECT * FROM tbsinhvien WHERE gt = '"+gt+"' AND qq = '"+qq+"'";
    
    try{
        //khai bao de ket noi cau lenh sql voi mysql
        PreparedStatement ps = (PreparedStatement)cn.prepareStatement(sql);
    
        //do du lieu tu ps vao doi tuong result set
        ResultSet rs = ps.executeQuery();
        
        //do du lieu tu result set vao array list
        while(rs.next())
        {
            //khai bao bien de lay du lieu cua cac truong tuong ung trong bang
            
        /*    String masv  = rs.getString("masv");
            String ht  = rs.getString("ht");
            String ns = rs.getString("ns");
            String gt  = rs.getString("gt");
            String malop  = rs.getString("malop");
            String qq = rs.getString("qq");
            SV sv = new SV(masv,ht,gt,malop,qq,ns);*/
            
            //lsv.add(sv);
        }  
        //xong roi thi dong csdl ,khong thi xung dot du lieu
        cn.close();
    }
    
   catch(Exception e)
   {
       
   }
    return lsv;
    }
   
   
   
   
   
   public boolean Insert_tbsv(String MaSV, String HoTen, String GioiTinh, String MaLop, String QueQuan, String NgaySinh)
   {
       boolean kq;
       
       Connection cn = DB_Connection.getConn();
       String sql = "insert into tbsv(msv,tensv,gt,ns,malop,qq) values('" + MaSV +"','" +HoTen +"','" + GioiTinh +"','" +NgaySinh   + "','" +MaLop + "','" +QueQuan+ "')";
       
       try {
           PreparedStatement ps = (PreparedStatement) cn.prepareStatement(sql);
           ps.executeUpdate();
           kq = true;
           cn.close();
       } catch (Exception e) {
           kq = false;
       }       
       return kq;
       
   }
   
   
   
   public boolean Delete_tbsv(String Malop)
   {
       boolean kq;
       
       Connection cn = DB_Connection.getConn();
       String sql = "DELETE FROM tbsv Where MaLop = '"+Malop+"';";
       
       try {
           PreparedStatement ps = (PreparedStatement) cn.prepareStatement(sql);
           ps.executeUpdate();
           kq = true;
           cn.close();
       } catch (Exception e) {
           kq = false;
       }       
       return kq;
       
   }
}