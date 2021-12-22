package unit3;

public class BoundedBufferSemaphore {
    private final int sizeBuffer = 10;
    private int inBuffer = 0, outBuffer = 0;
    private double[] buffers = new double[sizeBuffer];
    private BinarySemaphore mutex = new BinarySemaphore(true);
    private CountingSemaphore isEmpty = new CountingSemaphore(0);
    private CountingSemaphore isFull = new CountingSemaphore(sizeBuffer);

    public void deposit(double value) {
        isFull.P(); // wait if buffer is full
        mutex.P(); // ensures mutual exclusion       
        buffers[inBuffer] = value; // update the buffer
        inBuffer = (inBuffer + 1) % sizeBuffer;
        mutex.V();
        isEmpty.V(); // notify any waiting customer
    }

    public double fetch() {
        isEmpty.P(); // wait if buffer is empty
        mutex.P(); // ensures mutual exclusion
        double value = buffers[outBuffer]; // read from buffer
        outBuffer = (outBuffer + 1) % sizeBuffer;
        mutex.V();
        isFull.V(); // notify any waiting producer
        return value;
    }

    public boolean isFull() {
        return buffers.length == sizeBuffer;
    }

    public boolean isEmpty() {
        return buffers.length == 0;
    }
}
