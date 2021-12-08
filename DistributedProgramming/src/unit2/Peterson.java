package unit2;

public class Peterson implements Lock {
    private boolean[] wantCS = { false, false };
    private int turn = 1;

    @Override
    public void requestCS(int i) {
        int j = 1 - i;
        wantCS[i] = true;
        turn = j;
        while (wantCS[j] && turn == j);
    }

    @Override
    public void releaseCS(int i) {
        wantCS[i] = false;
    }
}
