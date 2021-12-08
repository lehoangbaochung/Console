<%-- 
    Document   : R_Insert_Diem
    Created on : Jul 26, 2020, 11:47:49 PM
    Author     : Asus
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Thêm điểm</title>
    </head>
    <body>
    <center>
        <form method="POST" action="RInsert_diem.jsp">
            <h1>Thêm điểm</h1>
            <table border="0">
                <thead>
                </thead>
                <tbody>
                    <tr>
                        <td>Mã sinh viên</td>
                        <td><input type="text" name="txt_masv" value="" /></td>
                    </tr>
                    <tr>
                        <td>Mã học phần</td>
                        <td><input type="text" name="txt_mahp" value="" /></td>
                    </tr>
                    <tr>
                        <td>Điểm</td>
                        <td><input type="text" name="txt_diem" value="" /></td>
                    </tr>                
                </tbody>
            </table>
            <input type="submit" value="Thêm điểm" />
            <pre>****************************************************************</pre>
        </form>
    </center>
    </body>
</html>
