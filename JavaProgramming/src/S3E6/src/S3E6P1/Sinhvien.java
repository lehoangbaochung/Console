/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package S3E6P1;

import java.util.Date;

/**
 *
 * @author Asus
 */
public class Sinhvien {
    private String MaSV, HoTen, DiaChi;
    private Date NgaySinh;
    private boolean GioiTinh;
    public String getMaSV(){
        return MaSV;
    }
    public String getHoTen(){
        return HoTen;
    }
    public String getDiaChi(){
        return DiaChi;
    }
    public Date getNgaySinh(){
        return NgaySinh;
    }
    public boolean getGioiTinh(){
        return GioiTinh;
    }
    public void setMaSV(String MaSV){
        this.MaSV = MaSV;
    }
    public void setHoTen(String HoTen){
        this.HoTen = HoTen;
    }
    public void setDiaChi(String DiaChi){
        this.DiaChi = DiaChi;
    }
    public void setNgaySinh(Date NgaySinh){
        this.NgaySinh = NgaySinh;
    }
    public void setGioiTinh(boolean GioiTinh){
        this.GioiTinh = GioiTinh;
    }
    public Sinhvien(){}
    public Sinhvien(String MaSV, String HoTen, Date NgaySinh, boolean GioiTinh, String DiaChi){
        this.MaSV = MaSV;
        this.HoTen = HoTen;
        this.NgaySinh = NgaySinh;
        this.GioiTinh = GioiTinh;
        this.DiaChi = DiaChi;
    }
}
