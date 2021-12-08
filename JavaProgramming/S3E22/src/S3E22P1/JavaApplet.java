package S3E22P1;

import java.applet.Applet;
import java.awt.Color;
import java.awt.Font;
import java.awt.Graphics;


public class JavaApplet extends Applet implements Runnable {
    int dx = this.getWidth(),  dy = this.getHeight(), x = 0, y, space = 10;

    @Override
    public void init() {
        y = dy/2;
        Thread t = new Thread(this);
        t.start();
    }

    @Override
    public void paint(Graphics g) {
        super.paint(g);
        Font f = new Font("Times", Font.BOLD, 20);
        g.setFont(f);
        g.setColor(Color.blue);
        g.drawString("Java Applet", x, 200);
    }

    @Override
    public void run() {
        while(true){
            repaint();
            x = x+space;
            if (x == 1260) x=0;
            try{
                Thread.sleep(50);
            }
            catch(InterruptedException e){}
        }
       
            
        }
            
}
