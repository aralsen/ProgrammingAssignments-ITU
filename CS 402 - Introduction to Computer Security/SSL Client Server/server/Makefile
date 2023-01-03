JFLAGS = -g
JC = javac

.SUFFIXES: .java .class

.java.class:
	$(JC) $(JFLAGS) $*.java

CLASSES = Server.java

default: classes

classes: $(CLASSES:.java=.class)

clean:
	$(RM) *.class
	
run:
	java -Djavax.net.ssl.keyStore=../serverkeystore.p12  -Djavax.net.ssl.keyStorePassword=password -Djavax.net.ssl.trustStore=../servertruststore.jks  -Djavax.net.ssl.trustStorePassword=password Server 8081
