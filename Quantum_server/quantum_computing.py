import json

def quantum_state():
    with open("apikey.json", "r") as file:
        data = json.load(file)
    
    from qiskit_ibm_runtime import QiskitRuntimeService

    QiskitRuntimeService.save_account(
        # For `token`, use the 44-character API_KEY you created
        # and saved from the IBM Quantum Platform Home dashboard
        overwrite=True,
        token=data["apikey"],
        instance='auto' # Optional
    )

    from qiskit_ibm_runtime import (
        QiskitRuntimeService,
        SamplerV2 as Sampler
    )
    from qiskit import QuantumCircuit
    from qiskit.transpiler.preset_passmanagers import generate_preset_pass_manager

    #Connect
    service = QiskitRuntimeService()

    #Choose least occupied backend
    backend = service.least_busy(
        operational=True,
        simulator=False,
        min_num_qubits=2
    )

    print(f"Backend selected: {backend.name}")
    print(f"Number of qubits: {backend.num_qubits}")

    # Create circuit
    circuit = QuantumCircuit(2, 2)
    circuit.h(0)
    circuit.cx(0, 1)
    circuit.measure([0, 1], [0, 1])

    print(circuit.draw())


    # Transpile for backend
    pm = generate_preset_pass_manager(
        backend=backend,
        optimization_level=3
    )
    transpiled_qc = pm.run(circuit)

    # Create a job
    sampler = Sampler(backend)
    job = sampler.run([transpiled_qc], shots=1024)

    print(f"Job ID: {job.job_id()}")
    print("Job soumis ! En attente...")

    # Wait and get result
    result = job.result()

    #Extract counts of results
    pub_result = result[0]
    counts = pub_result.data.c.get_counts()

    #get the one who appeared the most
    temp = "test"
    most = 0
    for key in counts:
        if most < counts[key]:
            temp = key
            most = counts[key]
    

    print("Done")
    return temp