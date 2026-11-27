using UnityEngine;
using TMPro;
using UnityEditor.Rendering.Universal;
using Unity.VisualScripting;
public class ChatSender : MonoBehaviour
{
    public TMP_InputField input_field;
    public PythonBridge python_bridge;
    /*
    public void Send_chat()
    {
        python_bridge.SendStringToPython(input_field.text);
    }
    */

    // Fixed the quantum state
    public void Fixed_Quantum_State()
    {
        python_bridge.Get_Quantum_State_From_Python();
    } 

}
