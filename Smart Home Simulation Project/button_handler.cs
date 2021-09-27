using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Script created by: Brent Alexander

/* The purpose of this script is to overwrite text on a button when pressed
 * and adds the ability to quit the application through the HUB Menu.
*/

public class button_handler : MonoBehaviour
{
    public void SetText(string text)
    {
        Text txt = transform.Find("Text").GetComponent<Text>();
        txt.text = text;
    }

    public void QuitSim()
    {
        Application.Quit();
        Debug.Log("Quiting simulation...");
    }
}
