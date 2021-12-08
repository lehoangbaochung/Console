package unit2;

public interface Lock {
    public void requestCS(int i); // may block

    public void releaseCS(int i);
}