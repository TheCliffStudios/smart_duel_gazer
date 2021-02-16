using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTextInput : MonoBehaviour
{
    
    //public static string userAddedIP;
    //public static string userAddedPort;
    public GameObject inputIP = null;
    public GameObject inputPort = null;

    public NetworkInfo networkInfo;    

    public void StoreInput() {
        

        networkInfo.userAddedIP = inputIP.GetComponent<Text>().text;
        networkInfo.userAddedPort = inputPort.GetComponent<Text>().text;
    }
}
