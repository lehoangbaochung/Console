package unit3;

public class Philosopher implements Runnable {
    private final int id;
    private final Resource resource;

    public Philosopher(int id, Resource resource) {
        this.id = id;
        this.resource = resource;
        new Thread(this).start();
    }

    @Override
    public void run() {
        while (true) {
            try {
                System.out.println("Philosopher " + id + " is thinking");
                Thread.sleep(3000);
                System.out.println("Philosopher " + id + " is hungry");
                resource.acquire(id);
                System.out.println("Philosopher " + id + " is eating");
                Thread.sleep(4000);
                resource.release(id);
            } catch (InterruptedException e) {
                e.printStackTrace();
                return;
            }
        }
    } 
}
