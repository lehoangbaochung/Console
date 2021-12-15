package test;

import java.util.Random;

import unit3.BoundedBufferMonitor;

public class PerfectNumberMonitor {
    static double n;

    static class T1 extends Thread {
        private final BoundedBufferMonitor b;

        public T1(BoundedBufferMonitor b) {
            this.b = b;
        }

        @Override
        public void run() {
            Random random = new Random();
            while (true) {
                n = random.nextInt(100);
                b.deposit(n);
            }
        }
    }

    static class T2 extends Thread {
        private final BoundedBufferMonitor b;

        public T2(BoundedBufferMonitor b) {
            this.b = b;
        }

        @Override
        public void run() {
            int i = 1, sum = 0;
            while (true) {
                n = b.fetch();
                while (i <= n) {
                    if (n % i == 0) {
                        sum++;
                    }
                    i++;
                }
                if (n == sum && n != 0) {
                    System.out.println((int) n + " is a perfect number!");
                } else {
                    // System.out.println((int) n + " is not a perfect number!");
                }
            }
        }
    }

    public static void main(String[] args) throws InterruptedException {
        BoundedBufferMonitor b = new BoundedBufferMonitor();
        T1 t1 = new T1(b);
        T2 t2 = new T2(b);
        t1.start();
        t2.start();
        t1.join();
        t2.join();
    }
}
