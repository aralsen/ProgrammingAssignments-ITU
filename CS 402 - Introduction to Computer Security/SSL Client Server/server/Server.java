import javax.net.ssl.SSLServerSocket;
import javax.net.ssl.SSLServerSocketFactory;
import java.io.*;
import java.net.Socket;

/*
* SSH Server that using Secure Socket Layer (SSL) to encrypt the data
* */
public class Server {
    public static void main(String[] args)
    {
        try
        {
            // Create a SSL server socket with host name and port number
            SSLServerSocketFactory sslServerSocketFactory = (SSLServerSocketFactory) SSLServerSocketFactory.getDefault();
            SSLServerSocket sslServerSocket = (SSLServerSocket) sslServerSocketFactory.createServerSocket(Integer.parseInt(args[0]));

            while (true) {
                // Listen for a connection request
                Socket socket = sslServerSocket.accept();

                // Create data input and output streams
                DataInputStream inputFromClient = new DataInputStream(socket.getInputStream());
                DataOutputStream outputToClient = new DataOutputStream(socket.getOutputStream());

                // Continuously serve the client
                while (true)
                {
                    // Receive the String from the client
                    String command = inputFromClient.readUTF();
                    
                    if (command.equals("exit")) {
                    socket.close(); 
                    break;
                    }

                    // Execute the command with executeCommand method and get the result
                    String result = executeCommand(command);

                    // Send the result back to the client
                    outputToClient.writeUTF(result);
                }
            }
        }
        catch (IOException e) {
            throw new RuntimeException(e);
        }
    }

    // Method to execute a command in the server with ProcessBuilder class and return the result as a string
    private static String executeCommand(String command)
    {
        try
        {
            // Create a ProcessBuilder object
            ProcessBuilder processBuilder = new ProcessBuilder(command);

            // Start the process
            Process process = processBuilder.start();

            BufferedReader input = new BufferedReader(new InputStreamReader(process.getInputStream()));
            String line;
            StringBuilder result = new StringBuilder();
            while ((line = input.readLine()) != null)
            {
                result.append(line);
            }
            input.close();
            
            return result.toString();
        }
        catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
}
