package unit5;

public class VectorClock {
    private int[] values;
    private int id;

    public VectorClock(int numberProduce, int id) {
        this.id = id;
        this.values = new int[numberProduce];
        for (int i = 0; i < numberProduce; i++) {
            values[i] = 0;
        }
        this.values[id] = 1;
    }
    
    public void tick() {
        values[id]++;
    }

    public void sendAction() {
        // include the vector in message
        values[id]++;
    }

    public void receiveAction(int[] sentValues) {
        for (int i = 0; i < values.length; i++) {
            values[i] = Math.max(values[i], sentValues[i]);
        }
        values[id]++;
    }

    public int getValue(int position) {
        return values[position];
    }

    @Override
    public String toString() {
        String valueString = "";
        for (int value : values) {
            valueString += value + " ";
        }
        return valueString.trim();
    }
}
