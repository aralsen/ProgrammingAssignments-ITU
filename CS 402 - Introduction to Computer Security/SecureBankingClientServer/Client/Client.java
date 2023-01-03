import javax.crypto.BadPaddingException;
import javax.crypto.Cipher;
import javax.crypto.IllegalBlockSizeException;
import javax.crypto.NoSuchPaddingException;
import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.File;
import java.io.IOException;
import java.net.Socket;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.security.InvalidKeyException;
import java.security.KeyFactory;
import java.security.NoSuchAlgorithmException;
import java.security.PublicKey;
import java.security.spec.X509EncodedKeySpec;
import java.util.Base64;
import java.util.Scanner;

public class Client {
    private static PublicKey getPublicKey() throws Exception
    {
        byte[] keyBytes = Files.readAllBytes(new File("public.key").toPath());
        X509EncodedKeySpec spec = new X509EncodedKeySpec(keyBytes);
        KeyFactory kf = KeyFactory.getInstance("RSA");

        return kf.generatePublic(spec);
    }

    private static String encryptText(String msg, PublicKey key)
            throws IllegalBlockSizeException, BadPaddingException, NoSuchPaddingException,
            NoSuchAlgorithmException, InvalidKeyException
    {
        Cipher cipher = Cipher.getInstance("RSA");
        cipher.init(Cipher.ENCRYPT_MODE, key);

        return Base64.getEncoder().encodeToString(cipher.doFinal(msg.getBytes(StandardCharsets.UTF_8)));
    }

    private static String getUsernamePasswordAndEncrypt() throws Exception
    {
        PublicKey publicKey = getPublicKey();
        Scanner sc = new Scanner(System.in);

        String username;
        String password;

        // prevent empty username
        do {
            System.out.print("Username: ");
            username = sc.nextLine();
        } while (username.isBlank());

        // prevent empty password
        do {
            System.out.print("Password: ");
            password = sc.nextLine();
        } while (password.isBlank());

        String usernamePassword = username + " " + password;

        // encrypt username and password and return it
        return encryptText(usernamePassword, publicKey);
    }

    private static void sendMessage(Socket socket, String message) throws IOException
    {
        DataOutputStream out = new DataOutputStream(socket.getOutputStream());
        out.writeUTF(message);
    }

    private static String receiveMessage(Socket socket) throws IOException
    {
        DataInputStream in = new DataInputStream(socket.getInputStream());
        return in.readUTF();
    }

    private static void displayUserBalanceAndOptions(String str)
    {
        System.out.println("Your account balance is " + str
                + ". Please select one of the following actions:" + "\n" + "1. Deposit" + "\n" + "2. Exit");

        System.out.println("Please enter your choice: ");
    }

    private static void depositMoney(Socket socket) throws IOException
    {
        Scanner sc = new Scanner(System.in);
        System.out.print("Enter the amount you want to deposit: ");
        String amount = sc.nextLine();
        sendMessage(socket, amount);
    }

    private static void takeAction(String str, Socket socket) throws IOException
    {
        if (str.equals("1"))
        {
            sendMessage(socket, "1");
            depositMoney(socket);
            if (receiveMessage(socket).equals("1"))
            {
                displayUserBalanceAndOptions(receiveMessage(socket));
            }
            else
            {
                System.out.println("Deposit failed!");
            }
        }
        else if (str.equals("2"))
        {
            sendMessage(socket, "2");
            socket.close();
            System.exit(0);
        }
        else
        {
            System.out.println("Invalid selection.");
        }
    }

    private static String login(Socket socket) throws Exception
    {
        String encryptedUsernamePassword = getUsernamePasswordAndEncrypt();
        sendMessage(socket, encryptedUsernamePassword);

        return receiveMessage(socket);
    }

    public static void main(String[] args)
    {
        String host = args[0];
        int port = Integer.parseInt(args[1]);

        try (Socket socket = new Socket(host, port)) {
            String loginStatus = login(socket);

            while (loginStatus.equals("0"))
            {
                System.out.println("Invalid username or password. Please try again.");
                loginStatus = login(socket);
            }

            System.out.println("Login successful!");

            displayUserBalanceAndOptions(receiveMessage(socket));

            try (Scanner sc = new Scanner(System.in)) {
                for (;;) {
                    String str = sc.nextLine();
                    takeAction(str, socket);
                }
            }
        }
        catch (Exception e) {
            throw new RuntimeException(e);
        }
    }
}
