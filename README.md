# IMAC3-S5-APP-SCI

## 1. Installation Requirements
- UNITY VERSION 6000.0.59f2
- flask (to run a python server)
- an IBM QUANTUM PLATFORM account to get an apikey

## 2. Setting Up
- put apikey.json in the Quantum_server folder
- in quantum_computing.py, in quantum_state(), replace open("apikey.json", "r") by open("your_absolute_path/apikey.json","r") where your_absolute_path is the path from your disk to your apikey file.

### 3. How to use
- Start server.py (necessary for quantic computation)
- Launch the unity project and experiment with the UI