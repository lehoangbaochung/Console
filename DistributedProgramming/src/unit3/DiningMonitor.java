package unit3;

public class DiningMonitor implements Resource {
    private final int n;
    private final int state[];
    private static final int thinking = 0, hungry = 1, eating = 2;

    public DiningMonitor(int n) {
        this.n = n;
        state = new int[n];
        for (int i = 0; i < n; i++)
            state[i] = thinking;
    }

    private int left(int i) {
        return (n + i - 1) % n;
    }

    private int right(int i) {
        return (i + 1) % n;
    }

    public synchronized void acquire(int i) throws InterruptedException {
        state[i] = hungry;
        test(i);
        while (state[i] != eating)
            wait();
    }

    public synchronized void release(int i) {
        state[i] = thinking;
        test(left(i));
        test(right(i));
    }

    private void test(int i) {
        if ((state[left(i)] != eating) &&
                (state[i] == hungry) &&
                (state[right(i)] != eating)) {
            state[i] = eating;
            notifyAll();
        }
    }

    public static void main(String[] args) {
        DiningMonitor dm = new DiningMonitor(5);
        for (int i = 0; i < 5; i++)
            new Philosopher(i, dm);
    }
}
