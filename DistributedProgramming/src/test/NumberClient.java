package test;

import java.io.*;
import java.net.*;

public class NumberClient {
    public static void main(String[] args) throws IOException {
        String hostName = "localhost";
        int port = 2018, length = 1024;
        DatagramPacket sendPacket, receivePacket;
        InetAddress ia = InetAddress.getByName(hostName); 
        try (DatagramSocket dataSocket = new DatagramSocket()) {
            while (true) {
                String sendString = "";
                for (int i = 0; i < 10; i++) {
                    sendString += (int) (Math.random() * 100 + 1) + " ";
                }
                sendString = sendString.trim();
                System.out.println("Client (send): " + sendString);
                byte[] buffer = new byte[sendString.length()];
                buffer = sendString.getBytes();
                sendPacket = new DatagramPacket(buffer, buffer.length, ia, port);
                dataSocket.send(sendPacket);
                byte[] rbuffer = new byte[length];
                receivePacket = new DatagramPacket(rbuffer, rbuffer.length);
                dataSocket.receive(receivePacket);
                String receiveString = new String(receivePacket.getData());
                System.out.println("Client (receive): " + receiveString);
            }
        }
    } 
}
