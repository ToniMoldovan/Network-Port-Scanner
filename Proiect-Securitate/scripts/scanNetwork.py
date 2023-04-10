import os
import sys
from scapy.all import *


def capture_packets(interface_name, output_dir):
    output_path = os.path.join(output_dir, "packets.pcap")
    packets = sniff(iface=interface_name, timeout=10)
    wrpcap(output_path, packets)


if __name__ == '__main__':
    interface_name = sys.argv[1]
    script_dir = os.path.dirname(os.path.realpath(__file__))
    output_dir = os.path.join(script_dir, "output", "NetworkScansOutput")
    capture_packets(interface_name, output_dir)
