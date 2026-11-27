using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Text;
using Unity.VisualScripting;
using System.Linq;
public class PythonBridge : MonoBehaviour
{
    private string to_substract_from_answer = "{\"message\":";
    public string fixed_state = "";
    public GameObject state_0;
    public GameObject state_1;
    /*
    public void SendStringToPython(string message)
    {
        StartCoroutine(PostMessage(message));
    }
    */
    public void Get_Quantum_State_From_Python()
    {
        StartCoroutine(Get_Message());
    }

    /*
    IEnumerator PostMessage(string message)
    {
        string url = "http://127.0.0.1:5000/send";
        string json = "{\"message\": \""+ message + "\"}";

        using UnityWebRequest request = new UnityWebRequest(url, "POST");
        byte[] body_raw = Encoding.UTF8.GetBytes(json);

        request.uploadHandler = new UploadHandlerRaw(body_raw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Python replied: " + request.downloadHandler.text);
        }
        else
        {
            Debug.Log(request.error);
        }
    }
    */

    IEnumerator Get_Message()
    {
        string url = "http://127.0.0.1:5000/quantum";
        using UnityWebRequest request = new UnityWebRequest(url, "GET");

        request.downloadHandler = new DownloadHandlerBuffer();
        
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            fixed_state = "";
            string temp;
            
            for (int i = to_substract_from_answer.Length+1; i < request.downloadHandler.text.Length-3; i++)
            {
                temp = request.downloadHandler.text[i].ToString();
                fixed_state += temp;    
            }

            
            Debug.Log("Python replied: " + request.downloadHandler.text);

            State_Manager();
        }
        else
        {
            Debug.Log(request.error);
        }
    }

    //Decide who gets to appear after the quantum state has been fixed
    public void State_Manager()
    {
        if (fixed_state[0] == '0')
        {
            state_1.GetComponent<MeshRenderer>().enabled = false;
        }
        else if (fixed_state[0] == '1')
        {
            state_0.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
