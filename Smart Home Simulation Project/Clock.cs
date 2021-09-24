/*
 * PLEASE READ EULA LICENSE DOCUMNET FOR TERMS OF USE BY END USERS.
 * This Project is not covered by GNU GPL and therefore may not be
 * distributed to anyone without a EULA specific to this project.
 * See the EULA document for more details.
 * You should have received a copy of the EULA along with this program. 
 * If not, see <https://unity3d.com/legal/as_terms?_ga=2.10484016.489677900.1619541417-851981439.1611271094>
*/


using UnityEngine;
using UnityEngine.UI;


public class Clock : MonoBehaviour
{
    public Temperatures temperatures;
    public MB.InteractiveHubSwitch interactiveHubSwitch;

    //-- set start time 00:00
    public int minutes = 0;
    public int hour = 0;
    public int seconds = 0;
    // Overriden by script values
    public string time = "0";

    //-- time speed factor
    //public float clockSpeed = 1.0f; // 1.0f = realtime, < 1.0f = slower, > 1.0f = faster
    public float clockSpeed = 2.0f;

    //-- internal vars
    // int seconds;
    float msecs;
    GameObject pointerSeconds;
    GameObject pointerMinutes;
    GameObject pointerHours;


    void Start()
    {
        //Time.captureFramerate = 10;
        Application.targetFrameRate = 75;

        pointerSeconds = transform.Find("rotation_axis_pointer_seconds").gameObject;
        pointerMinutes = transform.Find("rotation_axis_pointer_minutes").gameObject;
        pointerHours = transform.Find("rotation_axis_pointer_hour").gameObject;

        msecs = 0.0f;
        seconds = 0;
    }


    void FixedUpdate()
    {
        //-- calculate time
        msecs += Time.deltaTime * clockSpeed;

        if (msecs >= 1.0f)
        {
            msecs -= 1.0f;
            seconds++;

            if (seconds >= 60) //change this to determine how fast a minute should happen... (0-60)
            {
                temperatures.ChangeTemps(minutes, hour); //changes temps
                seconds = 0;
                minutes++;

                if (minutes > 60)
                {
                    minutes = 0;
                    hour++;
                    if (hour >= 24)
                        hour = 0;
                }

                GetCurrentTime();
            }
        }

        //-- calculate pointer angles
        float rotationSeconds = (360.0f / 60.0f) * seconds;
        float rotationMinutes = (360.0f / 60.0f) * minutes;
        float rotationHours = ((360.0f / 12.0f) * hour) + ((360.0f / (60.0f * 12.0f)) * minutes);

        //-- draw pointers
        pointerSeconds.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationSeconds);
        pointerMinutes.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationMinutes);
        pointerHours.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationHours);
    }


    public void GetCurrentTime()
    {
        string sHour = hour.ToString();
        string sMin = minutes.ToString();

        time = "'" + sHour + ":" + sMin + "'";
    }
}
