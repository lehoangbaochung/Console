package test;

import java.rmi.*;

public interface NumberRmiService extends Remote {
    public String interweare(String numberSequence) throws RemoteException;
}