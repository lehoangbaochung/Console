package test;

import java.net.*;
import java.io.*;

public class NumberServer {
    private static String interweare(String numberSequence) {
        String splitString = " ";
        String oddNumberString = "", evenNumberString = "";
        String[] numberStrings = numberSequence.split(splitString);
        for (String numberString : numberStrings) {
            if (Integer.valueOf(numberString) % 2 != 0) {
                oddNumberString += numberString + splitString;
            } else {
                evenNumberString += numberString + splitString;
            }
        }
        numberSequence = "";
        int oddNumberIndex = 0, evenNumberIndex = 0;
        String[] oddNumberStrings = oddNumberString.trim().split(splitString);
        String[] evenNumberStrings = evenNumberString.trim().split(splitString);
        for (int i = 0; i < numberStrings.length; i++) {
            if (i % 2 == 0 && evenNumberIndex < evenNumberStrings.length) {
                numberStrings[i] = evenNumberStrings[evenNumberIndex];
                evenNumberIndex++;
            } else if (i % 2 != 0 && oddNumberIndex < oddNumberStrings.length) {
                numberStrings[i] = oddNumberStrings[oddNumberIndex];
                oddNumberIndex++;
            }
            numberSequence += numberStrings[i] + splitString;
        }
        return numberSequence.trim();
    }

    public static void main(String[] args) throws SocketException, InterruptedException {
        int port = 2018, length = 1024;
        try (DatagramSocket dataSocket = new DatagramSocket(port)) {
            byte[] buffers = new byte[length];
            DatagramPacket dataPacket = new DatagramPacket(buffers, buffers.length);
            while (true) {
                Thread thread = new Thread(() -> {
                    try {
                        dataSocket.receive(dataPacket);
                        String receiveString = new String(dataPacket.getData(), 0, dataPacket.getLength());
                        System.out.println("Server (receive): " + receiveString);
                        String sendString = interweare(receiveString);
                        System.out.println("Server (send): " + sendString);
                        DatagramPacket sendPacket = new DatagramPacket(
                            sendString.getBytes(), sendString.length(),
                            dataPacket.getAddress(), dataPacket.getPort());
                        dataSocket.send(sendPacket);
                    } catch (IOException e) {
                        e.printStackTrace();
                    }
                });
                thread.start();
                thread.join();
            }
        }
    }
}
