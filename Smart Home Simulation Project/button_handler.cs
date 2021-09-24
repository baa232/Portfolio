/*
 * PLEASE READ EULA LICENSE DOCUMNET FOR TERMS OF USE BY END USERS.
 * This Project is not covered by GNU GPL and therefore may not be
 * distributed to anyone without a EULA specific to this project.
 * See the EULA document for more details.
 * You should have received a copy of the EULA along with this program. 
 * If not, see <https://unity3d.com/legal/as_terms?_ga=2.10484016.489677900.1619541417-851981439.1611271094>
*/

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
