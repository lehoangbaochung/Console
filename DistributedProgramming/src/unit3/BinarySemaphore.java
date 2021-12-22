package unit3;

public class BinarySemaphore {
    private boolean value;

    public BinarySemaphore(boolean value) {
        this.value = value;
    }

    public synchronized void P() {
        if (!value) {
            try {
                wait(); // blocked processes in queue
            } catch (InterruptedException e) {
                e.printStackTrace();
            } 
        }
        value = false;
    }

    public synchronized void V() {
        value = true;
        notify();
    }
}