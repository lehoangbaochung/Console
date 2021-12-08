package unit3;

public interface Resource {
    public void acquire(int id) throws InterruptedException;

    public void release(int id);
}
