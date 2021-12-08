package unit3;

public class ReaderWriter {
    private final Object object;
    private int numberReader = 0, numberWriter = 0;

    public ReaderWriter(Object object) {
        this.object = object;
    }

    public void writeDB() throws InterruptedException {
        synchronized (object) {
            while (numberReader > 0 || numberWriter > 0) {
                object.wait();
            }
            numberWriter = 1;
        }
        // ghi dữ liệu vào DB (không cần phải ở trong monitor)
        synchronized (object) {
            numberWriter = 0;
            object.notifyAll();
        }
    }

    public void readDB() throws InterruptedException {
        synchronized (object) {
            while (numberWriter > 0) {
                object.wait();
            }
            numberReader++;
        }
        // đọc dữ liệu vào DB (không cần phải ở trong monitor)
        synchronized (object) {
            numberReader--;
            object.notify();
        }
    }
}
