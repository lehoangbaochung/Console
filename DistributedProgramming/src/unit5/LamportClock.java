package unit5;

public class LamportClock {
    private int clock;

    public LamportClock() {
        clock = 1;
    }

    public int getValue() {
        return clock;
    }

    public void tick() {
        clock++;
    }

    public void sendAction() {
        // include c in message
        clock++;
    }

    public void receiveAction(int source, int sentValue) {
        clock = Math.max(clock, sentValue) + 1;
    }
}