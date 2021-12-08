package S3E11P1;

import java.applet.Applet;
import java.awt.Color;
import java.awt.Font;
import java.awt.Graphics;

public class FourSeasons extends Applet {

    @Override
    public void init() {
        // TODO start asynchronous download of heavy resources
    }

    @Override
    public void paint(Graphics g) {
        super.paint(g); 
        int x, y, w, h;
        x = y = 5;
        w = h = 200;
        Font f = new Font("Times", Font.BOLD, 25);
        g.setFont(f);
        // xuân
        g.setColor(Color.gray);
        g.fillRect(x, y, w, h);
        g.setColor(Color.blue);
        g.fillOval(x, y, w, h);
        g.setColor(Color.orange);
        g.drawString("Xuân", x+20, y+100);
        // hạ
        g.setColor(Color.pink);
        g.fillRect(x+w, y, w, h);
        g.setColor(Color.red);
        g.fillOval(x+w, y, h, h);
        g.setColor(Color.blue);
        g.drawString("Hạ", x+w+20, y+100);
        // thu
        g.setColor(Color.lightGray);
        g.fillRect(x, y+w, w, h);
        g.setColor(Color.darkGray);
        g.fillOval(x, y+w, w, h);
        g.setColor(Color.cyan);
        g.drawString("Thu", x+20, y+w+100);
        // đông
        g.setColor(Color.gray);
        g.fillRect(x+w, y+w, w, h);
        g.setColor(Color.blue);
        g.fillOval(x+w, y+w, w, h);
        g.setColor(Color.orange);
        g.drawString("Đông", x+w+20, y+w+100);      
    }
    
}
