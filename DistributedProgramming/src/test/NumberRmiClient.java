package test;

public class NumberRmiClient {
    public static void main(String args[]) throws Exception {
        while (true) {
            String sendString = "";
            for (int i = 0; i < 10; i++) {
                sendString += (int) (Math.random() * 100 + 1) + " ";
            } // rmi://localhost:5000/server
            sendString = sendString.trim();
            System.out.println("Client (send): " + sendString);
            System.out.println("Client (receive): ");
        }
    }
}