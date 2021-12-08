package test;

public class SquareNumber extends Thread {
    private static final int[] numbers = 
        { 0, 1, 2, 9, 10, 11, 12, 13, 14, 16, 64, 3, 4, 5, 6, 7, 8, 17, 18, 19 }; // n = 20
    private final int startIndex, endIndex;
    private long startTime, endTime;
    private int count = 0;

    public SquareNumber(int id, int startIndex, int endIndex) {
        setName("T" + id);
        this.startIndex = startIndex;
        this.endIndex = endIndex;
    }

    private boolean isSquareNumber(int n) {
        return Math.sqrt(n) == (int) Math.sqrt(n);
    }

    @Override
    public void run() {
        int i = startIndex;
        startTime = System.nanoTime();
        while (i < endIndex) {
            if (isSquareNumber(numbers[i])) {
                count++;
                System.out.println(String.format("So chinh phuong (%s): %d", getName(), numbers[i]));
            }
            i++;
        }
        endTime = System.nanoTime();
    }

    @Override
    public String toString() {
        return String.format("Luong (%s) tim duoc: %d so chinh phuong voi thoi gian %d (ns)",
            getName(), count, endTime - startTime);
    }

    private static void startThread(final int k) throws InterruptedException {
        int l, i = 0, n = 0, c = numbers.length / k;
        long startTime = System.nanoTime();
        SquareNumber t;
        while (i < k) {
            l = c + n;
            if (l <= numbers.length) {
                t = new SquareNumber(i, n, l);
                t.start();
                t.join();
                System.out.println(t.toString());
            } else {
                t = new SquareNumber(i, n, numbers.length);
                t.start();
                t.join();
                System.out.println(t.toString());
            }
            n = l;
            i++;
        }
        long endTime = System.nanoTime();
        System.out.println(String.format("Tong thoi gian chay cua %d luong: %d (ns)", k, endTime - startTime));
    }

    public static void main(String[] args) throws InterruptedException {
        System.out.println("--Chay mot luong--");
        startThread(1);
        System.out.println("");
        System.out.println("--Chay da luong--");
        startThread(6);
    }
}
