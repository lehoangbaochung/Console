package org.apache.jsp;

import javax.servlet.*;
import javax.servlet.http.*;
import javax.servlet.jsp.*;

public final class Insert_005fSV_jsp extends org.apache.jasper.runtime.HttpJspBase
    implements org.apache.jasper.runtime.JspSourceDependent {

  private static final JspFactory _jspxFactory = JspFactory.getDefaultFactory();

  private static java.util.List<String> _jspx_dependants;

  private org.glassfish.jsp.api.ResourceInjector _jspx_resourceInjector;

  public java.util.List<String> getDependants() {
    return _jspx_dependants;
  }

  public void _jspService(HttpServletRequest request, HttpServletResponse response)
        throws java.io.IOException, ServletException {

    PageContext pageContext = null;
    HttpSession session = null;
    ServletContext application = null;
    ServletConfig config = null;
    JspWriter out = null;
    Object page = this;
    JspWriter _jspx_out = null;
    PageContext _jspx_page_context = null;

    try {
      response.setContentType("text/html;charset=UTF-8");
      pageContext = _jspxFactory.getPageContext(this, request, response,
      			null, true, 8192, true);
      _jspx_page_context = pageContext;
      application = pageContext.getServletContext();
      config = pageContext.getServletConfig();
      session = pageContext.getSession();
      out = pageContext.getOut();
      _jspx_out = out;
      _jspx_resourceInjector = (org.glassfish.jsp.api.ResourceInjector) application.getAttribute("com.sun.appserv.jsp.resource.injector");

      out.write("\n");
      out.write("\n");
      out.write("\n");
      out.write("<!DOCTYPE html>\n");
      out.write("<html>\n");
      out.write("    <head>\n");
      out.write("        <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">\n");
      out.write("        <title>JSP Page</title>\n");
      out.write("    </head>\n");
      out.write("    <body>\n");
      out.write("    <center>\n");
      out.write("        \n");
      out.write("        \n");
      out.write("        <form action=\"RInsert_SV.jsp\" method=\"POST\" name=\"posts\">\n");
      out.write("       \n");
      out.write("        \n");
      out.write("        <table border=\"1\">\n");
      out.write("           \n");
      out.write("            <tbody>\n");
      out.write("                <tr>\n");
      out.write("                    <td>Mã sinh viên</td>\n");
      out.write("                    <td><input type=\"text\" name=\"txt_ma\" value=\"\" /></td>\n");
      out.write("                </tr>\n");
      out.write("                <tr>\n");
      out.write("                    <td>Họ tên</td>\n");
      out.write("                    <td><input type=\"text\" name=\"txt_ht\" value=\"\" /></td>\n");
      out.write("                </tr>\n");
      out.write("                 <tr>\n");
      out.write("                    <td>Giới tính</td>\n");
      out.write("                    <td><input type=\"text\" name=\"txt_gt\" value=\"\" /></td>\n");
      out.write("                </tr>\n");
      out.write("                <tr>\n");
      out.write("                    <td>Quê quán</td>\n");
      out.write("                    <td><input type=\"text\" name=\"txt_qq\" value=\"\" /></td>\n");
      out.write("                </tr>\n");
      out.write("                <tr>\n");
      out.write("                    <td>Ngày sinh</td>\n");
      out.write("                    <td><input type=\"text\" name=\"txt_ns\" value=\"\" /></td>\n");
      out.write("                </tr>\n");
      out.write("              \n");
      out.write("                <tr>\n");
      out.write("                    <td>Mã lớp</td>\n");
      out.write("                    <td><select name=\"ddl_lop\">\n");
      out.write("                            <option>TH1</option>\n");
      out.write("                            <option>TH2</option>\n");
      out.write("                        </select></td>\n");
      out.write("                </tr>\n");
      out.write("                <tr>\n");
      out.write("                    <td><input type=\"submit\" value=\"Thêm sinh viên\" name=\"bt_them\" /> </td>\n");
      out.write("                </tr>\n");
      out.write("            </tbody>\n");
      out.write("\n");
      out.write("        </table>\n");
      out.write("\n");
      out.write("         </form>\n");
      out.write("    </center>\n");
      out.write("        \n");
      out.write("    </body>\n");
      out.write("</html>\n");
    } catch (Throwable t) {
      if (!(t instanceof SkipPageException)){
        out = _jspx_out;
        if (out != null && out.getBufferSize() != 0)
          out.clearBuffer();
        if (_jspx_page_context != null) _jspx_page_context.handlePageException(t);
        else throw new ServletException(t);
      }
    } finally {
      _jspxFactory.releasePageContext(_jspx_page_context);
    }
  }
}
