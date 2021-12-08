package S3E18P1;

import java.applet.Applet;
import java.awt.Color;
import java.awt.Graphics;

public class BeerShot extends Applet {
    int x,y,dx,dy,h;
    @Override
    public void init() {
    }

    @Override
    public void paint(Graphics g) {
        super.paint(g); //To change body of generated methods, choose Tools | Templates.
        dx=this.getWidth();
        dy=this.getHeight();
        x=y=100;
        h=50;
        
        for(int i=0; i<6; i++){
            if(i%2 != 0){
                g.setColor(Color.white);
                g.fillOval(x-i*10, y-i*10, h+i*30, h+i*30);
                g.setColor(Color.red);
                g.fillOval(x-i*5, y-i*5, h+i*20, h+i*20);
            }
        }

        
        g.setColor(Color.black);
        g.drawLine(dx/2, 0, dx/2, dy);
        
        g.setColor(Color.black);
        g.drawLine(0, dy/2, dx, dy/2);
        
        
    }

    
}
