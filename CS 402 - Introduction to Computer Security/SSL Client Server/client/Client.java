import javax.net.ssl.SSLSocket;
import javax.net.ssl.SSLSocketFactory;
import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.util.Scanner;

public class Client {
    public static void main(String[] args)
    {
        try {
            // Create a SSL socket
            SSLSocketFactory sslSocketFactory = (SSLSocketFactory) SSLSocketFactory.getDefault();
            SSLSocket sslSocket = (SSLSocket) sslSocketFactory.createSocket(args[0], Integer.parseInt(args[1]));

            // Create data input and output streams
            DataInputStream inputFromServer = new DataInputStream(sslSocket.getInputStream());
            DataOutputStream outputToServer = new DataOutputStream(sslSocket.getOutputStream());

            // Continuously send the command to the server and read the result
            while (true) {
                // Create a Scanner
                Scanner scanner = new Scanner(System.in);

                System.out.print("ssh > ");

                // Read a command from the keyboard
                String command = scanner.nextLine();

                // check if the command is pwd, ls, or exit if not print "Invalid Command"
                if (command.equals("pwd") || command.equals("ls") || command.equals("exit")) {
                    //exit is used to close the socket
                    if (command.equals("exit")) {
                        // Send the command to the server
                    	outputToServer.writeUTF(command);
                        sslSocket.close();
                        break;
                    }

                    // Send the command to the server
                    outputToServer.writeUTF(command);

                    // Get the result from the server
                    String result = inputFromServer.readUTF();

                    // Display the result
                    System.out.println(result);
                } else {
                    System.out.println("Invalid Command");
                }
            }
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
}
