package unit2;

public class Dekker implements Lock {
    private int turn = 1;
    private boolean[] wantCS = { false, false };

    @Override
    public void requestCS(int i) {
        int j = 1 - i;
        wantCS[i] = true;
        while (wantCS[j]) {
            if (turn == i) {
                Thread.yield();
                wantCS[i] = false;
                while (turn == j) {
                    Thread.yield();
                }
                wantCS[i] = true;
            }
        }
    }
    
    @Override
    public void releaseCS(int i) {
        turn = 1 - i;
        wantCS[i] = false;
    }
}
