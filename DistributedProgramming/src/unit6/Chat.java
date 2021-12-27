package unit6;

import java.io.*;
import java.util.*;

import unit4.*;
import unit4.Process;

public class Chat extends Process {
    public Chat(Linker initComm) {
        super(initComm);
    }

    public synchronized void handleMsg(Message m, int source, String tag) {
        if (tag.equals("chat")) {
            System.out.println("Message from " + source + ":");
            System.out.println(m.getMessage());
        }
    }

    public String getUserInput(BufferedReader din) throws Exception {
        System.out.println("Please type your message in a single line:");
        String chatMsg = din.readLine();
        return chatMsg;
    }

    public IntLinkedList getDest(BufferedReader din) throws Exception {
        System.out.println("Type in destination pids with -1 at end:");
        IntLinkedList destIds = new IntLinkedList(); // dest for msg
        StringTokenizer st = new StringTokenizer(din.readLine());
        while (st.hasMoreTokens()) {
            int pid = Integer.parseInt(st.nextToken());
            if (pid == -1)
                break;
            else
                destIds.add(pid);
        }
        return destIds;
    }

    public static void main(String[] args) throws Exception {
        String baseName = args[0];
        int myId = Integer.parseInt(args[1]);
        int numProc = Integer.parseInt(args[2]);
        Linker comm = null;
        if (args[3].equals("simple"))
            comm = new Linker(baseName, myId, numProc);
        else if (args[3].equals("causal"))
            comm = new CausalLinker(baseName, myId, numProc);
        else if (args[3].equals("synch"))
            comm = new SynchLinker(baseName, myId, numProc);
        Chat c = new Chat(comm);
        for (int i = 0; i < numProc; i++)
            if (i != myId)
                (new ListenerThread(i, c)).start();
        BufferedReader din = new BufferedReader(
                new InputStreamReader(System.in));
        while (true) {
            String chatMsg = c.getUserInput(din);
            if (chatMsg.equals("quit"))
                break;
            IntLinkedList destIds = c.getDest(din);
            comm.multicast(destIds, "chat", chatMsg);
        }
    }    
}
