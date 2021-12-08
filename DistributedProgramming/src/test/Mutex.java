package test;

import unit2.Dekker;
import unit2.Lock;

public class Mutex extends Thread {
    private final Lock lock;
    private final int id;
    private static int counter;

    public Mutex(Lock lock, int id) {
        setName("T" + id);
        this.lock = lock;
        this.id = id;
    }

    private void incrementer() {
        for (int i = 0; i < 50; i++) {
            counter += 2;
            System.out.println(getName() + ": Counter(in) = " + counter);
        } 
    }

    private void decrementer() {
        for (int i = 0; i < 50; i++) {
            counter -= 2;
            System.out.println(getName() + ": Counter(de) = " + counter);
        }
    }

    @Override
    public void run() {
        lock.requestCS(id);
        incrementer();
        lock.releaseCS(id);
        decrementer();
    }

    public static void main(String[] args) throws InterruptedException {
        counter = 0;
        Lock dekker = new Dekker();
        Mutex mutex1 = new Mutex(dekker, 0);
        Mutex mutex2 = new Mutex(dekker, 1);
        mutex1.start();
        mutex2.start();
        mutex1.join();
        mutex2.join();
        System.out.println("Result: Counter = " + counter);
    }
}
