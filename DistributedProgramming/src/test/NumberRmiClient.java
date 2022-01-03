package test;

import java.rmi.registry.*;

public class NumberRmiClient {
    public static void main(String args[]) throws Exception {
        var registry = LocateRegistry.createRegistry(5000);
        var service = (NumberRmiService) registry.lookup("localhost");
        while (true) {
            var sendString = "";
            for (int i = 0; i < 10; i++) {
                sendString += (int) (Math.random() * 100 + 1) + " ";
            }
            Thread.sleep(1000);
            sendString = sendString.trim();
            System.out.println("Client (send): " + sendString);
            var receiveString = service.interweare(sendString);
            System.out.println("Client (receive): " + receiveString);
        }
    }
}