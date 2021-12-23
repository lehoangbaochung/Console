package unit5;

public class MatrixClock {
    private int[][] matrix;
    private int id, n;

    public MatrixClock(int numberProduce, int id) {
        this.id = id;
        n = numberProduce;
        matrix = new int[numberProduce][numberProduce];
        for (int i = 0; i < numberProduce; i++) {
            for (int j = 0; i < numberProduce; j++) {
                matrix[i][j] = 0;
            }
        }
        matrix[id][id] = 1;
    }
    
    public void tick() {
        matrix[id][id]++;
    }

    public void sendAction() {
        // include the matrix in message
        matrix[id][id]++;
    }

    public void receiveAction(int[][] values, int sourceId) {
        // component-wise maximum of matrices
        for (int i = 0; i < n; i++) {
            if (i != id) {
                for (int j = 0; j < n; j++) {
                    matrix[i][j] = Math.max(matrix[i][j], values[i][j]);
                }
            }
        }
        // update the vector of this process
        for (int j = 0; j < n; j++) {
            matrix[id][j] = Math.max(matrix[id][j], values[sourceId][j]);
        }
        matrix[id][id]++;
    }

    public int getValue(int i, int j) {
        return matrix[i][j];
    }
}
