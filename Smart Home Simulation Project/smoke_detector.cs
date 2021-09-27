using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Script created by: Brent Alexander

/* The purpose of this script is to detect when smoke particles are present within the game scene
 * and to update Heads Up Display (HUD) to reflect the change.
*/

public class smoke_detector : MonoBehaviour
{
    public Text changing_text;
    public GameObject smoke;

    void Update()
    {
        smoke = GameObject.Find("Smoke(Clone)");
    }

    void Start()
    {
        //Start the coroutine we define below named ExampleCoroutine.
        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {
        if (smoke != null)
        {
            changing_text = GameObject.Find("HUD/Smoke Detector Text").GetComponent<Text>();
            changing_text.text = "Smoke Detected!";
            yield return new WaitForSeconds(5);
            smoke = null;
        }
        else
        {
            changing_text = GameObject.Find("HUD/Smoke Detector Text").GetComponent<Text>();
            changing_text.text = "No Smoke Detected";
        }

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        Start();
    }
}
