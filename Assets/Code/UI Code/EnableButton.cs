using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableButton : MonoBehaviour
{
    public Button button;
    
    void Start() {
        button.enabled = false;
    }

    public void EnableProceed() {
        button.enabled = true;
    }
}
