package unit3;

public class BoundedBufferMonitor {
    private final int sizeBuffer = 10;
    private double[] buffers = new double[sizeBuffer];
    private int inBuffer = 0, outBuffer = 0, count = 0;

    public synchronized void deposit(double value) {
        while (count == sizeBuffer) { // buffer is full
            try {
                wait();
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
        count++;
        buffers[inBuffer] = value;
        inBuffer = (inBuffer + 1) % sizeBuffer;
        if (count == 1) {
            notify();
        }
    }

    public synchronized double fetch() {
        double value;
        while (count == 0) { // buffer is empty
            try {
                wait();
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
        count--;
        value = buffers[outBuffer];
        outBuffer = (outBuffer + 1) % sizeBuffer;
        if (count == sizeBuffer - 1) { // empty slots available
            notify();
        }
        return value;
    }
}