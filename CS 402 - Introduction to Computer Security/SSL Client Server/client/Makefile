JFLAGS = -g
JC = javac

.SUFFIXES: .java .class

.java.class:
	$(JC) $(JFLAGS) $*.java

CLASSES = Client.java

default: classes

classes: $(CLASSES:.java=.class)

clean:
	$(RM) *.class
	
run:
	java -Djavax.net.ssl.keyStore=../clientkeystore.p12 -Djavax.net.ssl.keyStorePassword=password -Djavax.net.ssl.trustStore=../clienttruststore.jks -Djavax.net.ssl.trustStorePassword=password Client localhost 8081
