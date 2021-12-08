/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package S3E22P1;

import java.applet.Applet;
import java.awt.Color;
import java.awt.Font;
import java.awt.Graphics;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author ADMIN
 */
public class JavaApllet extends Applet implements Runnable{

    int x,y,dx,dy,sx,sy;
    /**
     * Initialization method that will be called after the applet is loaded into
     * the browser.
     */
    
    @Override
    public void init() {
        // TODO start asynchronous download of heavy resources
        
        dx=this.getWidth();
        dy=this.getHeight();
        x=dx/2;
        y=dy/2;
        sx=20;
        Thread t=new Thread(this);
        t.start();
    }
  

    // TODO overwrite start(), stop() and destroy() methods

    @Override
    public void paint(Graphics g) {
        
        super.paint(g); //To change body of generated methods, choose Tools | Templates.
        Font f=new Font("Times", Font.BOLD, 30);
        g.setFont(f);
        g.setColor(Color.red);
        g.fillOval(x, y, 30, 30);
        
    }

    @Override
    public void run() { 
        //To change body of generated methods, choose Tools | Templates.
        boolean check=true;
        while(true){
            dx=this.getWidth();
            dy=this.getHeight();
            x=dx/2;
           if(check){
               y=y-20;
           }
           else{
               y=y+20;
           }
           if(y<=0){
               check=false;
           }
           if(y>=dy){
               check=true;
           }
            
            
            
            repaint();
            
            try {
                Thread.sleep(10);
            } catch (InterruptedException ex) {
                Logger.getLogger(JavaApllet.class.getName()).log(Level.SEVERE, null, ex);
            }
        }
        
    }
    
    
}
