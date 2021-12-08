package S3E21P1;

import java.applet.Applet;
import java.awt.Color;
import java.awt.Graphics;

public class Chess extends Applet {

    @Override
    public void init() {       
    }
    
    @Override
    public void paint(Graphics g) {
        super.paint(g);
        int x, y, w, h;
        x = y = 0;
        w = h = 50;
        for(int i = 0; i<7; i++){
            for(int j = 0; j<7; j++){
                if ((i+j) % 2 == 0)
                    g.setColor(Color.red);
                else
                    g.setColor(Color.black);
            g.fillRect(x+i*w, y+j*w, w, h);
            }  
        }
    }
}
