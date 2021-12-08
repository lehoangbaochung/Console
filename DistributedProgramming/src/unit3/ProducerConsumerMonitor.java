package unit3;

public class ProducerConsumerMonitor {
    private final BoundedBufferSemaphore buffer;

    public ProducerConsumerMonitor(BoundedBufferSemaphore buffer) {
        this.buffer = buffer;
    }

    // or produce
    public void deposit(double value) throws InterruptedException {
        synchronized (buffer) {
            while (buffer.isFull()) {
                buffer.wait();
                buffer.deposit(value); // thêm một phần tử vào bộ đệm
            }
            if (!buffer.isEmpty()) {
                buffer.notify();
            }
        }
    }
    
    // or consume
    public void fetch() throws InterruptedException {
        synchronized (buffer) {
            while (buffer.isEmpty()) {
                buffer.wait();
                buffer.fetch(); // lấy một phần tử khỏi bộ đệm
            }
            if (!buffer.isFull()) {
                buffer.notify();
            }
        }
    }
}
