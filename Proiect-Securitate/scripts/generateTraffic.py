import argparse
from scapy.all import *

def generate_traffic(ip_address, num_packets):
    packets = []
    for i in range(num_packets):
        packets.append(IP(dst=ip_address)/ICMP())

    wrpcap("D:\\Facultate\\Proiect-Securitate\\Proiect-Securitate\\scripts\\output\\GenerateTrafficOutput\\generateTrafficOutput.pcap", packets)

if __name__ == "__main__":
    parser = argparse.ArgumentParser(description="Generate traffic by pinging a target IP address")
    parser.add_argument("-i", "--ip", type=str, help="IP address to ping", required=True)
    parser.add_argument("-n", "--num_packets", type=int, help="Number of packets to send", required=True)
    args = parser.parse_args()

    generate_traffic(args.ip, args.num_packets)
