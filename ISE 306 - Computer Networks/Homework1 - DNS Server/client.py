import socket
import sys

with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
    if len(sys.argv) != 4:
        print("Usage: $python client.py <ip_address> <port_number> <host_name>")
        sys.exit(1)

    # connect to primary_server
    ip_address = sys.argv[1]
    port_number = int(sys.argv[2])
    s.connect((ip_address, port_number))

    HOST_NAME = sys.argv[3]
    packet = 'GET' + ' ' + HOST_NAME
    # ask for the IP address of the host
    s.sendall(packet.encode('utf-8'))
    data = s.recv(1024).decode('utf-8')
    status = data.split(' ')[0]  # get the status code
    if status == 'FOUND':
        print('The IP address of the host {} is {}'.format(data.split(' ')[1], data.split(' ')[2]))
        s.close()
        sys.exit(0)
    elif status == 'REDIR':
        # close the current connection and connect to the secondary server
        s.close()
        with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
            s.connect((data.split(' ')[2], int(data.split(' ')[3])))
            s.sendall(packet.encode('utf-8'))
            data = s.recv(1024).decode('utf-8')
            status = data.split(' ')[0]
            if status == 'FOUND':
                print('The IP address of the host {} is {}'.format(data.split(' ')[1], data.split(' ')[2]))
                # terminate the connection and program
                s.close()
                sys.exit(0)
            elif status == 'ERROR':
                print('The IP address of the host {} could not be found, sorry!'.format(data.split(' ')[1]))
                # terminate the connection and program
                s.close()
                sys.exit(1)
