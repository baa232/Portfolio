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
using static System.Math;


// Script created by: Lucas Cardoza
// Script modified by: Andrew McFarland, Brent Alexander

public class Temperatures : MonoBehaviour
{
    public UserState userState;
    public UserPosition userPosition;
    public Clock clock;

    // Private objects used to display HUD information
    private Text _AmbientTemperatureText;
    private Text _UserTemperatureText;
    private Text _OutdoorTemperatureText;
    private Text Menu_OutdoorTemperatureText;
    private Text _DisplayTimeTextOne;
    private Text Menu_textClock;
    private Text textClock;

    // Class variables
    // Be careful, these temps do not update to the inspector window. The inspector will overwrite these values.
    public float ambTemp = 0f;
    public float outDoorTemp = 60.0f;

    //userTemp will now represent the user's surface/skin temperature
    //We can use a range 60 to 110 (F) and 90 is "good" or average surface skin temperature
    //This should make the user's temperature much more usable when it comes to policy gen
    public float userTemp = 90.0f;      

    public float livingRoomTemp = 70.0f;
    public float kitchenTemp = 70.0f;
    public float bedRoomOneTemp = 70.0f;
    public float bedRoomTwoTemp = 70.0f;
    public float bathRoomTemp = 70.0f;
    public bool frontDoor = false;
    public bool bedRoomTwoDoor = false;
    public bool bedRoomOneDoor = false;
    public bool bathDoor = false;
    public bool kitchen = false;

    public float decimalHours = 0f;
    public float minutes_as_hours = 0f;
    public float dailyMaxTemp = 60.0f;
    public float dailyMinTemp = 30.0f;

    //Number in front of the sine function
    public float amplitude = 0f;    
    public float temperatureVerticalShift = 0f;
    public const float PI = 3.1415926535f;

    //(In seconds)
    private int temperature_refresh_rate = 1;

    // A variable to control how quickly the user's temperature increases/decreases
    // (This value can eventually be affected by ambient temperature...
    // i.e. if the user is in a very hot room, their temperature velocity would be fairly high).
    // We would have to set bounds on this though because while a person may become hot very quickly,
    // their internal temp shouldn't exceed normal levels because of this.
    public float userTemperatureVelocity = 0f;  
                                                

    // Function called to set starting values to variables
    private void Start()
    {
        userState = GameObject.FindGameObjectWithTag("UserStateClass").GetComponent<UserState>();
        userPosition = GameObject.FindGameObjectWithTag("UserPositionClass").GetComponent<UserPosition>();
        clock = GameObject.FindGameObjectWithTag("ClockClass").GetComponent<Clock>();
        userState.userTemperature = 90.0f;
        userTemp = userState.userTemperature;
        temperatureVerticalShift = (dailyMaxTemp + dailyMinTemp) / 2;
        SetAmbTemp();
    }


    void Update()
    {
        // Called once per frame.
        // Run once every position_refresh_rate (5 second(s) currently).
        // This is NOT clock time, just system time for incremental use.
        if (Time.time >= temperature_refresh_rate)
        {   
            temperature_refresh_rate = Mathf.FloorToInt(Time.time) + 1;
            SimulateOutdoorTemp();
            DisplayTemps();
            SetAmbTemp();
        }

        textClock.text = "Time: " + clock.hour + ":" + clock.minutes;
        Menu_textClock.text = "Time: " + clock.hour + ":" + clock.minutes;
        Menu_OutdoorTemperatureText.text = "Simulated Outdoor Temperature: " + outDoorTemp.ToString();
    }


    void Awake()
    {
        textClock = GameObject.Find("HUD/Display Time TextOne").GetComponent<Text>();
        Menu_OutdoorTemperatureText = GameObject.Find("HUD/Menu Text1").GetComponent<Text>();
        Menu_textClock = GameObject.Find("HUD/Menu Text2").GetComponent<Text>();
    }


    string LeadingZero(int n)
    {
        return n.ToString().PadLeft(2, '0');
    }


    // Function to display the current temperatures
    public void DisplayTemps()
    {
        // Display ambient temperature to HUD
        _AmbientTemperatureText = GameObject.Find("HUD/Ambient Temperature Text").GetComponent<Text>();
        _AmbientTemperatureText.text = "Ambient Temperature: " + ambTemp.ToString("F");

        // Display user temperature to HUD
        _UserTemperatureText = GameObject.Find("HUD/User Temperature Text").GetComponent<Text>();
        _UserTemperatureText.text = "User Body Temperature: " + userTemp.ToString("F");

        _OutdoorTemperatureText = GameObject.Find("HUD/Outdoor Temperature Text").GetComponent<Text>();
        _OutdoorTemperatureText.text = "Simulated Outdoor Temperature: " + outDoorTemp.ToString();

        // Display time information to the HUD:
        _DisplayTimeTextOne = GameObject.Find("HUD/Display Time TextOne").GetComponent<Text>();
        _DisplayTimeTextOne.text = "TIME AND STUFF MINUTES: " + clock.minutes.ToString();
    }


    // Function to calculate the change in temperatures
    public void ChangeTemps(int minutes, int hour)
    {
        float time = minutes % 2;

        // The value of the incremental change the user's temperature experiences over time
        float change = .001f;  
        
        //MODIFIED LOGIC OF THE ABOVE FOR THE UPDATED VERSION OF userTemp:
        if (time == 1 && ambTemp < 70)
        {
            // As the temperature lowers, the user will get colder faster.
            // These are essentially limitations on the user's temperature so that they don't reach an unrealistic/unhealthy/dangerous temperature
            if (userTemp > 80)             
            {
                userTemp -= change;
            }
        }
        // Check to raise user's body temperature
        else if (time == 1 && ambTemp > 70) 
        {
            // As the temperature rises, the user will get warmer faster
            // These are essentially limitations on the user's temperature so that they don't reach an unrealistic/unhealthy/dangerous temperature
            if (userTemp < 100)         
            {
                userTemp += change;
            }
        }

        DisplayTemps();
    }


    // Function to set ambient temperature to the room the user is currently in 
    public void SetAmbTemp()
    {
        if (userPosition.currentRoom == "FRONT_PORCH" || userPosition.currentRoom == "FRONT_PORCH_STAIRS" || userPosition.currentRoom == "BACK_PORCH" || userPosition.currentRoom == "BACK_PORCH_STAIRS")
        {
            ambTemp = outDoorTemp;
        }
        else if (userPosition.currentRoom == "Kitchen")
        {
            ambTemp = kitchenTemp;
        }
        else if (userPosition.currentRoom == "Livingroom")
        {
            ambTemp = livingRoomTemp;
        }
        else if (userPosition.currentRoom == "Bathroom")
        {
            ambTemp = bathRoomTemp;
        }
        else if (userPosition.currentRoom == "BedroomOne")
        {
            ambTemp = bedRoomOneTemp;
        }
        else if (userPosition.currentRoom == "BedroomTwo")
        {
            ambTemp = bedRoomTwoTemp;
        }

        DisplayTemps();
    }


    public void SimulateOutdoorTemp()
    {
        // Added the .001 as a temporary fix for 0 values
        minutes_as_hours = (float)clock.minutes / 60 + (float).001;   
        decimalHours = (float)clock.hour + minutes_as_hours;
        amplitude = (dailyMaxTemp - dailyMinTemp) / 2;
        // TEMPORARILY using minutes until I get clock.hour issue resolved
        outDoorTemp = amplitude * (float)Sin(2 * PI * clock.minutes / 24) + temperatureVerticalShift;
        // TEMPORARILY using minutes until I get clock.hour issue resolved
        outDoorTemp = amplitude * (float)Sin((2 * PI * clock.minutes - 36) / 24) + temperatureVerticalShift; 
    }              
}