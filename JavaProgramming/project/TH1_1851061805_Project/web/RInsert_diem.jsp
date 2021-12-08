<%-- 
    Document   : Insert_Diem
    Created on : Jul 26, 2020, 3:10:00 PM
    Author     : Asus
--%>

<%@page import="Database_QLdiem.DB_Process"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Kết quả</title>
    </head>
    <body>
   
        <form method="get" name="getdiem">
    
        <%
            DB_Process ps = new DB_Process();
            String masv = request.getParameter("txt_masv");
            String mahp = request.getParameter("txt_mahp");
            double diem = Double.valueOf(request.getParameter("txt_diem"));
            
            if (ps.db_Insert_diem(masv, mahp, diem))
            {
                %>
                <center>
                <h1>Thêm điểm thành công</h1>
                </center>
                <%
            }

            else
            {
                %>
                <center>
                <h1>Thêm điểm thất bại</h1>
                </center>
                <%   
            }
        %>
        
        </form>
    </body>
</html>
