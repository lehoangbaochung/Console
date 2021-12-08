package S3E22P1;

import java.applet.Applet;
import java.awt.Color;
import java.awt.Graphics;


public class Bubble extends Applet implements Runnable {
    int dx = this.getWidth(),  dy = this.getHeight(), x = 0, y, space = 10, w, h;
    

    @Override
    public void init() {
        Thread t = new Thread(this);
        t.start();
    }

    @Override
    public void paint(Graphics g) {
        w = h = 100;
        super.paint(g);
        g.setColor(Color.pink);
        g.fillOval(x, y, w, h);
    }

    @Override
    public void run() {
        while(true){
            repaint();
            x = x+space;
            y = y+5;
            if (x == 1200 && y == 600){
            while(true){
                repaint();
                x = x-space;
                y = y-5;
                if (x == 0 && y == 0){
                    while(true){
                        repaint();
                        x = x+space;
                        y = y+5;
                        try{
                            Thread.sleep(10);
                        }
                        catch(InterruptedException e){}
                    }
                    
                }
                try{
                    Thread.sleep(10);
                }
                catch(InterruptedException e){}
            }
            }
            try{
                Thread.sleep(10);
            }
            catch(InterruptedException e){}
        }
       
            
        }
            
}
