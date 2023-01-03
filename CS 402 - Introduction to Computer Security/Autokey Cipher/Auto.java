/*
* Assignment 1 (CS458) - Undergraduate
* Student Name: Aral Sen
* Student ID: B00840458
* */

import java.io.*;

public class Auto {
    private static final String alphabetEN = "abcdefghijklmnopqrstuvwxyz";
    private static final String key = "security";

    private static String encrypt(String plainText)
    {
        StringBuilder cipherText = new StringBuilder();
        String shiftKey = key.concat(plainText);
        shiftKey = shiftKey.substring(0, shiftKey.length() - key.length());

        for (int i = 0; i < plainText.length(); i++) {
            int charPosition1 = alphabetEN.indexOf(plainText.charAt(i));
            int charPosition2 = alphabetEN.indexOf(shiftKey.charAt(i));
            int keyVal = (charPosition1 + charPosition2) % 26;
            char replaceVal = alphabetEN.charAt(keyVal);
            cipherText.append(replaceVal);
        }

        return cipherText.toString();
    }

    private static String decrypt(String cipherText)
    {
        StringBuilder plainText = new StringBuilder();
        StringBuilder curKey = new StringBuilder(key);

        for (int i = 0; i < cipherText.length(); i++) {
            int charPosition1 = alphabetEN.indexOf(cipherText.charAt(i));
            int charPosition2 = alphabetEN.indexOf(curKey.toString().charAt(i));
            int keyVal = (charPosition1 - charPosition2) % 26;
            if (keyVal < 0) {
                keyVal = alphabetEN.length() + keyVal;
            }
            char replaceVal = alphabetEN.charAt(keyVal);
            plainText.append(replaceVal);
            curKey.append(replaceVal);
        }

        return plainText.toString();
    }

    private static void autoKeyRunner(String inputFileName, String outputFileName, boolean encrypt)
    {
        try {
            BufferedReader bufferedReader = new BufferedReader(new FileReader(inputFileName));
            BufferedWriter bufferedWriter = new BufferedWriter(new FileWriter(outputFileName));
            String line;

            if ((line = bufferedReader.readLine()) != null) {
                String outputText = encrypt ? encrypt(line) : decrypt(line);
                bufferedWriter.write(outputText);
            }

            bufferedWriter.flush();
            bufferedReader.close();
            bufferedWriter.close();
        }
        catch (FileNotFoundException e) {
            e.printStackTrace();
        }
        catch (IOException e) {
            throw new RuntimeException(e);
        }
    }

    public static void main(String[] args)
    {
        String inputFileName = args[0];
        String outputFileName = args[1];
        int option = Integer.parseInt(args[2]);

        if (option != 0 && option != 1) {
            System.out.println("Invalid option! 1 for encrypt and 0 for decrypt");
            return;
        }

        switch (option) {
            case 0 -> autoKeyRunner(inputFileName, outputFileName, false);
            case 1 -> autoKeyRunner(inputFileName, outputFileName, true);
        }
    }
}