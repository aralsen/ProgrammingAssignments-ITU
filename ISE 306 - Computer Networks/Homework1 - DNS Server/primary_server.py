import socket
import sys

# Create a TCP/IP socket
with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as sock:
    if len(sys.argv) != 5:
        print("Usage: $python primary_server.py <primary_port> <secondary_ip> <secondary_port> <addresses_file_name>")
        sys.exit(1)

    # Read in file
    lines = []
    with open(sys.argv[4], 'r') as f:
        lines = f.readlines()

    # Split out and drop empty rows
    strip_list = [line.replace('\n', '').split(' ') for line in lines if line != '\n']

    # Create a dictionary of host_names and their IPs
    host_and_ip = dict()
    for strip in strip_list:
        host_and_ip[strip[0]] = strip[1]

    # Bind the socket to the port
    primary_port = int(sys.argv[1])
    server_address = ('127.0.0.1', primary_port)
    print('starting up on {} port {}'.format(*server_address))
    sock.bind(server_address)

    # Listen for incoming connections
    sock.listen(1)

    while True:
        # Wait for a connection
        print('waiting for a connection')
        connection, client_address = sock.accept()

        with connection:
            print('connection from', client_address)

            # Receive the data in small chunks and retransmit it
            while True:
                data = connection.recv(1024).decode('utf-8')
                if data:
                    # print('received {!r}'.format(data))
                    data_split = data.split(' ')
                    if data_split[0] == 'GET':
                        HOST_NAME = data_split[1]
                        if HOST_NAME in host_and_ip.keys():
                            # print("Sending {}".format(d[data_split[1]]))
                            IP_ADDRESS = host_and_ip[HOST_NAME]
                            message = 'FOUND' + ' ' + HOST_NAME + ' ' + IP_ADDRESS
                            connection.sendall(message.encode('utf-8'))
                        else:
                            # print("Sending secondary dns server ip {} {} {}".format(data, sys.argv[2], sys.argv[3]))
                            HOST_NAME = data_split[1]
                            SECONDARY_IP = sys.argv[2]
                            SECONDARY_PORT = sys.argv[3]
                            message = 'REDIR' + ' ' + HOST_NAME + ' ' + SECONDARY_IP + ' ' + SECONDARY_PORT
                            connection.sendall(message.encode('utf-8'))

                else:
                    pass

                if not data:
                    break
