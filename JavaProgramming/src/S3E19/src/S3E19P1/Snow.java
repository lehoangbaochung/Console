package S3E19P1;

import java.applet.Applet;
import java.awt.Color;
import java.awt.Graphics;

public class Snow extends Applet {

    @Override
    public void init() {
        // TODO start asynchronous download of heavy resources
    }

    @Override
    public void paint(Graphics g) {
        super.paint(g);
        int x, y, l;
        x = y = 200;
        l = 200;
        g.setColor(Color.blue);
        g.drawLine(x, y+50, x+l, y+50);
        
        g.setColor(Color.blue);
        g.drawLine(x, y-50, x+l, y+l);
        
        g.setColor(Color.blue);
        g.drawLine(x, y+50, x+200, y+50);
        
        g.setColor(Color.blue);
        g.drawLine(x, y+50, x+200, y+50);
        
        g.setColor(Color.blue);
        g.drawLine(x, y+50, x+200, y+50);
    }
}
