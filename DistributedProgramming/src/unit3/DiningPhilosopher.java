package unit3;

public class DiningPhilosopher implements Resource {
    private final int n;
    private final BinarySemaphore[] forks;

    public DiningPhilosopher(int n) {
        this.n = n;
        forks = new BinarySemaphore[n];
        for (int i = 0; i < n; i++) {
            forks[i] = new BinarySemaphore(true);
        }
    }

    @Override
    public void acquire(int id) throws InterruptedException {
        forks[id].P();
        forks[(id + 1) % n].P();
    }

    @Override
    public void release(int id) {
        forks[id].V();
        forks[(id + 1) % n].V();
    }
    
    public static void main(String[] args) {
        DiningPhilosopher dp = new DiningPhilosopher(5);
        for (int i = 0; i < 5; i++) {
            new Philosopher(i, dp);
        }
    }
}
