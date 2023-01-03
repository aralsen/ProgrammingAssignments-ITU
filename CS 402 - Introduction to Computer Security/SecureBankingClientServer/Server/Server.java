import javax.crypto.BadPaddingException;
import javax.crypto.Cipher;
import javax.crypto.IllegalBlockSizeException;
import javax.crypto.NoSuchPaddingException;
import java.io.*;
import java.net.ServerSocket;
import java.net.Socket;
import java.net.SocketException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.security.*;
import java.security.spec.PKCS8EncodedKeySpec;
import java.util.Arrays;
import java.util.Base64;
import java.util.Objects;

public class Server {
    private static PrivateKey getPrivateKey() throws Exception
    {
        byte[] keyBytes = Files.readAllBytes(new File("private.key").toPath());
        PKCS8EncodedKeySpec spec = new PKCS8EncodedKeySpec(keyBytes);
        KeyFactory kf = KeyFactory.getInstance("RSA");

        return kf.generatePrivate(spec);
    }

    private static String decryptText(String msg, PrivateKey key)
            throws NoSuchAlgorithmException, InvalidKeyException, IllegalBlockSizeException,
            BadPaddingException, NoSuchPaddingException
    {
        Cipher cipher = Cipher.getInstance("RSA");
        cipher.init(Cipher.DECRYPT_MODE, key);

        return new String(cipher.doFinal(Base64.getDecoder().decode(msg)), StandardCharsets.UTF_8);
    }

    private static String getHash(String str)
    {
        try {
            MessageDigest md = MessageDigest.getInstance("MD5");
            byte[] array = md.digest(str.getBytes());
            StringBuilder sb = new StringBuilder();

            for (byte b : array)
                sb.append(Integer.toHexString((b & 0xFF) | 0x100), 1, 3);

            return sb.toString();
        }
        catch (NoSuchAlgorithmException ignored) {
            ignored.printStackTrace();
        }

        return null;
    }

    private static boolean validatePassword(String password, String hash)
    {
        return Objects.equals(getHash(password), hash);
    }

    private static String receiveMessage(Socket socket) throws IOException
    {
        DataInputStream in = new DataInputStream(socket.getInputStream());

        return in.readUTF();
    }

    private static void sendMessage(Socket socket, String message) throws IOException
    {
        DataOutputStream out = new DataOutputStream(socket.getOutputStream());
        out.writeUTF(message);
    }

    private static boolean searchForUser(String file, String username) throws IOException
    {
        String[] lines = Files.readAllLines(new File(file).toPath()).toArray(new String[0]);
        for (String line : lines) {
            String[] parts = line.split("\\s+");
            if (parts[0].equals(username))
                return true;
        }

        return false;
    }

    private static String getInfoByUsername(String file, String username) throws IOException
    {
        String[] lines = Files.readAllLines(new File(file).toPath()).toArray(new String[0]);
        for (String line : lines) {
            String[] parts = line.split("\\s+");
            if (parts[0].equals(username))
                return parts[1];
        }

        return null;
    }

    private static void updateBalance(String username, String balance) throws IOException
    {
        String[] lines = Files.readAllLines(new File("balance.txt").toPath()).toArray(new String[0]);
        lines = Arrays.stream(lines).map(line -> {
            String[] parts = line.split(" ");
            if (parts[0].equals(username))
                return username + " " + balance;
            return line;
        }).toArray(String[]::new);

        Files.write(new File("balance.txt").toPath(), String.join("\r", lines).getBytes());
    }

    private static String loginAuthentication(Socket socket) throws Exception
    {
        String usernamePassword = receiveMessage(socket);
        String decryptedUsernamePassword = decryptText(usernamePassword, getPrivateKey());
        String[] parts = decryptedUsernamePassword.split("\\s+");
        String username = parts[0];
        String password = parts[1];

        if (searchForUser("balance.txt", username)) {
            String hash = getInfoByUsername("passwd.txt", username);
            if (validatePassword(password, hash)) {
                sendMessage(socket, "1");
                return username;
            }
            else {
                sendMessage(socket, "0");
                return "0";
            }
        }

        sendMessage(socket, "0");
        return "0";
    }

    public static void main(String[] args)
    {
        int port = Integer.parseInt(args[0]);

        try (ServerSocket serverSocket = new ServerSocket(port)) {
            while (true) {
                Socket socket = serverSocket.accept();

                while (true) {
                    String username = loginAuthentication(socket);

                    while (username.equals("0")) {
                        username = loginAuthentication(socket);
                    }

                    String balance = getInfoByUsername("balance.txt", username);
                    sendMessage(socket, balance);

                    for (;;) {
                        String action = receiveMessage(socket);
                        if (action.equals("1")) {
                            String amount = receiveMessage(socket);
                            int newBalance = Integer.parseInt(balance) + Integer.parseInt(amount);
                            updateBalance(username, String.valueOf(newBalance));
                            sendMessage(socket, "1");
                            balance = getInfoByUsername("balance.txt", username);
                            sendMessage(socket, balance);
                        }

                        if (action.equals("2"))
                            break;
                    }

                    try {
                        socket.close();
                        break;
                    }
                    catch (SocketException ignored) {
                        ignored.printStackTrace();
                    }
                }
            }
        }
        catch (Exception e) {
            throw new RuntimeException(e);
        }
    }
}
