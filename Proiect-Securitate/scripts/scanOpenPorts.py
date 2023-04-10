import argparse
import socket
import threading

def scan_port(host, port, open_ports, closed_ports, timeout):
    try:
        with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
            s.settimeout(timeout)
            s.connect((host, port))
            open_ports.append(port)
    except:
        closed_ports.append(port)

def scan_open_ports(output_file):
    open_ports = []
    closed_ports = []

    threads = []
    host = "localhost"
    timeout = 0.1

    for port in range(1, 65536):
        thread = threading.Thread(target=scan_port, args=(host, port, open_ports, closed_ports, timeout))
        threads.append(thread)
        thread.start()

    for thread in threads:
        thread.join()

    # Write the open and closed ports to the output file
    with open(output_file, "w") as f:
        f.write("Open ports:\n")
        for port in open_ports:
            f.write(f"{port} - Open\n")
        f.write("\nClosed ports:\n")
        for port in closed_ports:
            f.write(f"{port} - Closed\n")

if __name__ == "__main__":
    parser = argparse.ArgumentParser(description="Scan for open ports")
    parser.add_argument("output_file", type=str, help="Output file path")
    args = parser.parse_args()

    scan_open_ports(args.output_file)
