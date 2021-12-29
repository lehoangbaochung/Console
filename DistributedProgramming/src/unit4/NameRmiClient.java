package unit4;

import java.rmi.Naming;

public class NameRmiClient {
    public static void main(String args[]) {
        try {
            NameService r = (NameService) Naming.lookup("rmi://localhost:5000/server");
            //int i = r.insert("p1", "tick.ece", 2058);
            int j = r.search("p1");
            if (j != -1)
                System.out.println(r.getHostName(j) + ":" + r.getPort(j));
        } catch (Exception e) {
            System.out.println(e);
        }
    }
}
