# Create a text file with some dummy data in it

import os
import sys

# Get the path to the current directory
path = os.path.dirname(os.path.realpath(__file__))
# print(f"The path is: {path}")

# Create a text file with some dummy data in it
with open(path + "/output/testOutput.txt", "w") as f: # this will create a file called test.txt in the current directory
    # generate all numbers from 1 to 10000
    for i in range(1, 10001):
        f.write(str(i) + " This is a test line")


# Path: testScript.py