package unit2;

public class Bakery implements Lock {
    private final int n;
    private int[] numbers;
    private boolean[] choosings; // inside doorway

    public Bakery(int n) {
        this.n = n;
        numbers = new int[n];
        choosings = new boolean[n];
        for (int i = 0; i < n; i++) {
            numbers[i] = 0;
            choosings[i] = false;
        }
    }

    @Override
    public void requestCS(int i) {
        // step 1: choose a number
        choosings[i] = true;
        for (int j = 0; j < n; j++) {
            if (numbers[j] > numbers[i]) {
                numbers[i] = numbers[j];
            }
        }
        numbers[i]++;
        choosings[i] = false;
        // step 2: check if number is the smallest
        for (int j = 0; j < n; j++) {
            // process j in doorway
            while (choosings[j]);
            // busy wait
            while (numbers[j] != 0 && j < i &&
                ((numbers[j] < numbers[i]) || (numbers[j] < numbers[i])));
        }
    }

    @Override
    public void releaseCS(int i) {
        numbers[i] = 0;
    }
}
