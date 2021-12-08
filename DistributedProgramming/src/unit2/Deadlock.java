package unit2;

public class Deadlock {
    class Attemp1 implements Lock {
        private boolean openDoor = false;

        @Override
        public void requestCS(int i) {
            while (!openDoor) {
                openDoor = false;
            }
        }

        @Override
        public void releaseCS(int i) {
            openDoor = true;
        }
    }

    class Attemp2 implements Lock {
        private boolean[] wantCS = { false, false };

        @Override
        public void requestCS(int i) { // entry protocol
            wantCS[i] = true; // declare intent
            while (wantCS[1 - i])
                ; // busy wait
        }

        @Override
        public void releaseCS(int i) {
            wantCS[i] = false;
        }
    }

    class Attemp3 implements Lock {
        private int turn = 0;

        @Override
        public void requestCS(int i) {
            while (turn == 1 - i)
                ;
        }

        @Override
        public void releaseCS(int i) {
            turn = 1 - i;
        }
    }
}
