package unit5;

public class DirectClock {
    private int[] clock;
    private int id;

    public DirectClock(int numberProduce, int id) {
        this.id = id;
        this.clock = new int[numberProduce];
        for (int i = 0; i < numberProduce; i++) {
            clock[i] = 0;
        }
        this.clock[id] = 1;
    }

    public void tick() {
        clock[id]++;
    }

    public int getValue(int position) {
        return clock[position];
    }

    public void sendAction() {
        // sentValue = clock[id];
        tick();
    }

    public void receiveAction(int sender, int sentValue) {
        clock[sender] = Math.max(clock[sender], sentValue);
        clock[id] = Math.max(clock[id], sentValue) + 1;
    }
}