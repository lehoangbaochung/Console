package test;

import java.rmi.RemoteException;
import java.rmi.registry.LocateRegistry;
import java.rmi.server.UnicastRemoteObject;

public class NumberRmiServer extends UnicastRemoteObject implements NumberRmiService {

    protected NumberRmiServer() throws RemoteException {
        super();
    }

    public String interweare(String numberSequence) throws RemoteException {
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

    public static void main(String args[]) throws Exception {
        var registry = LocateRegistry.createRegistry(5000);
        var numberRmi = new NumberRmiServer();
        registry.rebind("localhost", numberRmi);
        System.out.println("Server localhost was in registry");
    }
}
