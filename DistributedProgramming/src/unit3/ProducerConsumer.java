package unit3;

import java.util.Random;

public class ProducerConsumer {
    public static void main(String[] args) {
        BoundedBufferSemaphore buffer = new BoundedBufferSemaphore();
        new Producer(buffer);
        new Consumer(buffer);
    }

    static class Producer implements Runnable {
        private final BoundedBufferSemaphore buffer;

        public Producer(BoundedBufferSemaphore buffer) {
            this.buffer = buffer;
            new Thread(this).start();
        }

        @Override
        public void run() {
            double item;
            Random random = new Random();
            while (true) {
                item = random.nextDouble();
                System.out.println("The produced item: " + item);
                try {
                    buffer.deposit(item);
                    Thread.sleep(2000);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
            }
        }
    }

    static class Consumer implements Runnable {
        private final BoundedBufferSemaphore buffer;

        public Consumer(BoundedBufferSemaphore buffer) {
            this.buffer = buffer;
            new Thread(this).start();
        }

        @Override
        public void run() {
            double item;
            while (true) {
                try {
                    item = buffer.fetch();
                    System.out.println("The fetched item: " + item);
                    Thread.sleep(5000);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                    return;
                }
            }
        }
    }
}
