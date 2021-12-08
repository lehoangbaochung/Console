package unit3;

public class CountingSemaphore {
    private int value;
    
    public CountingSemaphore(int value) {
        this.value = value;
    }

    public synchronized void P() throws InterruptedException {
        value--;
        if (value < 0) {
            wait();
        }
    }

    public synchronized void V() {
        value++;
        if (value <= 0) {
            notify(); 
        }
    }
}
