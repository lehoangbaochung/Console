package S3E14P1;

import java.applet.Applet;
import java.awt.Color;
import java.awt.Graphics;

public class Chart extends Applet {

    @Override
    public void init() {
        // TODO start asynchronous download of heavy resources
    }

    // TODO overwrite start(), stop() and destroy() methods

    @Override
    public void paint(Graphics g) {
        super.paint(g);
        int x, y, h;
        x = y = 0;
        h = 500;
        g.setColor(Color.red);
        g.fillArc(x, y, h, h, 0, 120);
        
        g.setColor(Color.yellow);
        g.fillArc(x, y, h, h, 120, 120);
        
        g.setColor(Color.green);
        g.fillArc(x, y, h, h, 240, 120);
    }
}
