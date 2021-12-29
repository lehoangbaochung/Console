package test;

import java.rmi.Naming;
import java.rmi.RemoteException;
import java.rmi.registry.LocateRegistry;
import java.rmi.registry.Registry;
import java.rmi.server.UnicastRemoteObject;

public class NumberRmiServer extends UnicastRemoteObject {
    private final int maxSize = 100;
    private String[] names = new String[maxSize];
    private String[] hosts = new String[maxSize];
    private int[] ports = new int[maxSize];
    private int dirsize = 0;

    protected NumberRmiServer() throws RemoteException {
        super();
    }

    public int getPort(int index) throws RemoteException {
        return ports[index];
    }

    public String getHostName(int index) throws RemoteException {
        return hosts[index];
    }

    public String[] sort(String[] numberStrings) throws RemoteException {
        String splitString = " ";
        String oddNumberString = "", evenNumberString = "";
        for (String numberString : numberStrings) {
            if (Integer.valueOf(numberString) % 2 != 0) {
                oddNumberString += numberString + splitString;
            } else {
                evenNumberString += numberString + splitString;
            }
        }
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
        }
        return numberStrings;
    }

    public static void main(String args[]) throws Exception {
        // create security manager
        System.setSecurityManager(new SecurityManager());
        Registry registry = LocateRegistry.createRegistry(5000);
        try {
            var obj = new NumberRmiServer();
            Naming.rebind("MyNameServer", obj);
            System.out.println("MyNameServer bound in registry");
        } catch (Exception e) {
            System.out.println("NameServiceImpl err: " + e.getMessage());
        }
    }
}
