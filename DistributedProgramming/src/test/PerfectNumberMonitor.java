package test;

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
            while (true) {
                n = (int) (Math.random() * 100 + 1);
                b.deposit(n);
            }
        }
    }

    static class T2 extends Thread {
        private final BoundedBufferMonitor b;

        public T2(BoundedBufferMonitor b) {
            this.b = b;
        }

        private void check() {
            int i = 1, sum = 0;
            while (i <= n / 2) {
                if (n % i == 0) {
                    sum += i;
                }
                i++;
            }
            if (n == sum) {
                System.out.println((int) n + " is a perfect number!");
            } else {
                // System.out.println((int) n + " is not a perfect number!");
            }
        }

        @Override
        public void run() {
            while (true) {
                n = b.fetch();
                check();
            }
        }
    }

    public static void main(String[] args) {
        BoundedBufferMonitor b = new BoundedBufferMonitor();
        T1 t1 = new T1(b);
        T2 t2 = new T2(b);
        t1.start();
        t2.start();
    }
}