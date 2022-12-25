FLAGS = -Wall -Wextra -g

CA = 5
GROUP_NAME = RedBlack3
GITHUB_USERID = redblack3
EXECUTABLE = spotify_lite

$(EXECUTABLE):Library.o Song.o Timestamp.o main.o SpotifyLikeApp.o System.o Duration.o User.o
		g++ Library.o Song.o Timestamp.o main.o SpotifyLikeApp.o System.o Duration.o User.o -o $(EXECUTABLE)

replaceme:
	echo "Did you remember to set the variables in the makefile?!"

tar: clean
	cd .. && tar -cvzf CA$(CA)_$(GROUP_NAME).tar.gz cs240-spring21-ca$(CA)-$(GITHUB_USERID) && cd -

scrub: clean
	rm ~* *.swp *\#

run: $(EXECUTABLE)
	./$(EXECUTABLE) $(inputdir) $(workdir)

Library.o:	Library.cpp
	g++ Library.cpp -c

Song.o: Song.cpp
	g++ Song.cpp -c

Timestamp.o:	Timestamp.cpp
	g++  Timestamp.cpp -c	

SpotifyLikeApp.o: SpotifyLikeApp.cpp
	g++  SpotifyLikeApp.cpp -c
	
System.o: System.cpp
	g++  System.cpp -c

Duration.o: Duration.cpp
	g++  Duration.cpp -c

User.o:	User.cpp
	g++  User.cpp -c
		
main.o:	main.cpp
	g++  main.cpp -c


memcheck: $(EXECUTABLE)
	valgrind ./$(EXECUTABLE) $(inputdir) $(workdir)


clean:
	rm -f *.o $(EXECUTABLE)
