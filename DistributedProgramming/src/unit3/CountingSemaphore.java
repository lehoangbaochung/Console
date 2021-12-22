package unit3;

public class CountingSemaphore {
    private int value;
    
    public CountingSemaphore(int value) {
        this.value = value;
    }

    public synchronized void P() {
        value--;
        if (value < 0) {
            try {
                wait();
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
    }

    public synchronized void V() {
        value++;
        if (value <= 0) {
            notify(); 
        }
    }
}
