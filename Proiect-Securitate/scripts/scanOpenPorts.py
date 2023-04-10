# use scapy to scan open ports
from scapy.all import * # import scapy library
import sys # import sys library

# define a function to scan open ports on local machine and store the results in a list
def scanOpenPorts():
    openPorts = []
    for port in range(1, 1024):
        response = sr1(IP(dst="" + sys.argv[1] + "")/TCP(dport=port, flags="S"), timeout=1, verbose=0)

    




