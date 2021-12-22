import unit2.Dekker;
import unit2.Lock;

public class App extends Thread  {
    private final Lock lock;
    private final int id;

    public App(Lock lock, int id) {
        this.lock = lock;
        this.id = id;
    }
    
    private void CS() {
        System.out.println("CS");
    }

    private void nonCS() {
        System.out.println("nonCS");
    }

    @Override
    public void run() {
        while (true) {
            lock.requestCS(id);
            CS();
            lock.releaseCS(id);
            nonCS();
        }
    }

    public static void main(String[] args) {
        Lock dekker = new Dekker();
        App app1 = new App(dekker, 0);
        App app2 = new App(dekker, 1);
        app1.start();
        app2.start();
    }
}
