<%-- 
    Document   : Insert_SV
    Created on : Jul 23, 2020, 9:08:23 AM
    Author     : DELL
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
    </head>
    <body>
    <center>
        
        
        <form action="RInsert_SV.jsp" method="POST" name="posts">
       
        
        <table border="1">
           
            <tbody>
                <tr>
                    <td>Mã sinh viên</td>
                    <td><input type="text" name="txt_ma" value="" /></td>
                </tr>
                <tr>
                    <td>Họ tên</td>
                    <td><input type="text" name="txt_ht" value="" /></td>
                </tr>
                 <tr>
                    <td>Giới tính</td>
                    <td><input type="text" name="txt_gt" value="" /></td>
                </tr>
                <tr>
                    <td>Quê quán</td>
                    <td><input type="text" name="txt_qq" value="" /></td>
                </tr>
                <tr>
                    <td>Ngày sinh</td>
                    <td><input type="text" name="txt_ns" value="" /></td>
                </tr>
              
                <tr>
                    <td>Mã lớp</td>
                    <td><select name="ddl_lop">
                            <option>TH1</option>
                            <option>TH2</option>
                        </select></td>
                </tr>
                <tr>
                    <td><input type="submit" value="Thêm sinh viên" name="bt_them" /> </td>
                </tr>
            </tbody>

        </table>

         </form>
    </center>
        
    </body>
</html>
