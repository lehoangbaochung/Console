package unit3;

public class ReaderWriterSemaphore {
    private int numberReader = 0;
    private BinarySemaphore mutex = new BinarySemaphore(true);
    private BinarySemaphore wlock = new BinarySemaphore(true);

    public void startRead() throws InterruptedException {
        mutex.P();
        numberReader++;
        if (numberReader == 1) {
            wlock.P();
        }
        mutex.V();
    }

    public void endRead() throws InterruptedException {
        mutex.P();
        numberReader--;
        if (numberReader == 0) {
            wlock.V();
        }
        mutex.V();
    }

    public void startWrite() throws InterruptedException {
        wlock.P();
    }

    public void endWrite() {
        wlock.V();
    }
}
