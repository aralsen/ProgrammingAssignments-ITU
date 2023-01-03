Generating Certificates in Java: This section explains the steps I followed for generating certificates
generate certificates for the client and the server:

Server Certificate:

	First, I generated the server key store:

	keytool -genkey -alias serverkey -keyalg RSA -keysize 2048 -sigalg SHA256withRSA -keystore serverkeystore.p12 -storepass password

	Next,  export the certificate to the file server-certificate.pem:

	keytool -exportcert -keystore serverkeystore.p12 -alias serverkey -storepass password -rfc -file server-certificate.pem

	Finally,  add the server certificate to the client's trust store:

	keytool -import -trustcacerts -file server-certificate.pem -keypass password -storepass password -keystore clienttruststore.jks


Client Certificate:

	Similarly,  generate the client key store and export its certificate:

	keytool -genkey -alias clientkey -keyalg RSA -keysize 2048 -sigalg SHA256withRSA -keystore clientkeystore.p12 -storepass password

	keytool -exportcert -keystore clientkeystore.p12 -alias clientkey -storepass password -rfc -file client-certificate.pem

	keytool -import -trustcacerts -file client-certificate.pem -keypass password -storepass password -keystore servertruststore.jks

	In the last command, I added the client's certificate to the server trust store.



HOW TO COMPILE AND EXECUTE THE PROGRAM:
I created two subdirectories named Client and Server and create two seperate Makefile for both of them

Firstly, go to Server directory:
run the command `make` or `javac Server.java`

How to execute Server:
For Server we have two execution option:

	First:
	
	java -Djavax.net.ssl.keyStore=../serverkeystore.p12  -Djavax.net.ssl.keyStorePassword=password -Djavax.net.ssl.trustStore=../servertruststore.jks  -Djavax.net.ssl.trustStorePassword=password Server <server_port>
	
		For example:

		java -Djavax.net.ssl.keyStore=../serverkeystore.p12  -Djavax.net.ssl.keyStorePassword=password -Djavax.net.ssl.trustStore=../servertruststore.jks  -Djavax.net.ssl.trustStorePassword=password Server 8081
		
		
	Second:

	!!!simply execute the command `make run` in the Server Directory!!! It will execute the above command with server_port 8081


Secondly, go to Client directory:
run the command `make` or `javac Client.java`

How to execute Client:
For Client we have two execution option:
	First:
	
	java -Djavax.net.ssl.keyStore=../clientkeystore.p12 -Djavax.net.ssl.keyStorePassword=password -Djavax.net.ssl.trustStore=../clienttruststore.jks -Djavax.net.ssl.trustStorePassword=password Client <server_domain> <server_port>
	
		For example:

		java -Djavax.net.ssl.keyStore=../clientkeystore.p12 -Djavax.net.ssl.keyStorePassword=password -Djavax.net.ssl.trustStore=../clienttruststore.jks -Djavax.net.ssl.trustStorePassword=password Client localhost 8081


		!!! If you want, or if any problems might occured , before execute the above code you can simply write `hostname` command in the terminal and change the `localhost` to the output.!!!


Finally
you can execute the commands `ls` `pwd` `exit` in the Client







