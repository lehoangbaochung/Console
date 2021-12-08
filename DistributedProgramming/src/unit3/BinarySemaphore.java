package unit3;

public class BinarySemaphore {
    private boolean value;

    public BinarySemaphore(boolean value) {
        this.value = value;
    }

    public synchronized void P() throws InterruptedException {
        if (!value) {
            wait(); // in queue of blocked processes
        }
        value = false;
    }

    public synchronized void V() {
        value = true;
        notify();
    }
}