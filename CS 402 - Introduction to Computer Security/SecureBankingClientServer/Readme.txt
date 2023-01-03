Encryption code (Client.java):

private static String encryptText(String msg, PublicKey key)
            throws IllegalBlockSizeException, BadPaddingException, NoSuchPaddingException,
            NoSuchAlgorithmException, InvalidKeyException
    {
        Cipher cipher = Cipher.getInstance("RSA");
        cipher.init(Cipher.ENCRYPT_MODE, key);

        return Base64.getEncoder().encodeToString(cipher.doFinal(msg.getBytes(StandardCharsets.UTF_8)));
    }


Decryption code (Server.java):

 private static String decryptText(String msg, PrivateKey key)
            throws NoSuchAlgorithmException, InvalidKeyException, IllegalBlockSizeException,
            BadPaddingException, NoSuchPaddingException
    {
        Cipher cipher = Cipher.getInstance("RSA");
        cipher.init(Cipher.DECRYPT_MODE, key);

        return new String(cipher.doFinal(Base64.getDecoder().decode(msg)), StandardCharsets.UTF_8);
    }
	

My code was tested on remote.cs.binghamton.edu OpenJDK 64-Bit Server VM Zulu18.32+13-CA (build 18.0.2.1+1, mixed mode, sharing)

How to execute:

1- This is optional because I already created public.key and private.key (Client file include public.key, and Server file include both public and private keys),
but if you want to generate both the keys, you have to open PublicPrivateKeyGenerator file, open the console, and write "make", and "make run", running this will create,
public.key and private.key. After created the keys, you have to copy both keys and paste Server file, and copy the public.key and paste it to the Client file.
If you don't want to use Makefile, open the console and write "javac GenerateKey.java", and then "java GenerateKey".

2- Open Server file and first run "make" (it will create Server.class), and later run "make run" (make run automatically 
run with 50507 port). If you don't want to use Makefile, you can directly execute with "javac Server.java" and right after "java Server 50507".

3- After run the Server, you have to go Client file, and first run "make" (it will create Client.class), and later 
run "make run" (make run automatically run with localhost and 50507 port). If you don't want to use Makefile, you can 
directly execute with "javac Client.java" and right after "java Client localhost 50507".
