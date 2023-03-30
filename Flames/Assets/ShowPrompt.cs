using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowPrompt : MonoBehaviour
{

    public TextMeshProUGUI PromptText;


    private void OnTriggerEnter(Collider Inside)
    {
        if(Inside.tag == "Player")
        {
            PromptText.enabled = true;
        }
    }

    private void OnTriggerExit(Collider Inside)
    {
        if (Inside.tag == "Player")
        {
            PromptText.enabled = false ;
        }
    }
}

