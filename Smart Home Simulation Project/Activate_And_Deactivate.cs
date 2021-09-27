using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

// Script created by: Brent Alexander

/* The purpose of this script is to hide and unhide elements of the HUB Menu
 * from the game view.
*/

namespace MB
{
    public class Activate_And_Deactivate : MonoBehaviour
    {
        public GameObject text4_object;
        public GameObject text7_object;
        public GameObject text9_object;
        public GameObject text10_object;
        public GameObject text11_object;
        public GameObject text12_object;
        public GameObject text13_object;
        public GameObject text14_object;

        public GameObject tabOne_buttons;
        public GameObject tabTwo_buttons;
        public GameObject tabThree_buttons;

        public GameObject display1;
        public GameObject display2;
        public Image menu_background;
  
        public Image menu_button7;
        public Image menu_up;
        public Image menu_down;
        public Image tab1;
        public Image tab2;
        public Image tab3;

        InteractiveHubSwitch hubSwitch;

        public Image close;
        bool UI_Toggle = false;
        bool is_tab1 = false;
        bool is_tab2 = false;
        bool is_tab3 = false;


        public void Tab1()
        {
                tabOne_buttons.gameObject.SetActive(true);
                tabTwo_buttons.gameObject.SetActive(false);
                tabThree_buttons.gameObject.SetActive(false);
        }


        public void Tab2()
        {
                tabOne_buttons.gameObject.SetActive(false);
                tabTwo_buttons.gameObject.SetActive(true);
                tabThree_buttons.gameObject.SetActive(false);
        }


        public void Tab3()
        {
                tabOne_buttons.gameObject.SetActive(false);
                tabTwo_buttons.gameObject.SetActive(false);
                tabThree_buttons.gameObject.SetActive(true);
        }


        void Start()
        {
            text4_object.gameObject.SetActive(false);
            text7_object.gameObject.SetActive(false);
            text9_object.gameObject.SetActive(false);
            text10_object.gameObject.SetActive(false);
            text11_object.gameObject.SetActive(false);
            text12_object.gameObject.SetActive(false);
            text13_object.gameObject.SetActive(false);
            text14_object.gameObject.SetActive(false);
            tabOne_buttons.gameObject.SetActive(false);
            tabTwo_buttons.gameObject.SetActive(false);
            tabThree_buttons.gameObject.SetActive(false);

            display1.gameObject.SetActive(false);
            display2.gameObject.SetActive(false);

            hubSwitch = GameObject.Find("Hubswitch").GetComponent<InteractiveHubSwitch>();

            var tempColor = menu_background.color;
            tempColor.a = 0f;
            menu_background.color = tempColor;

            var tempColor4 = close.color;
            tempColor4.a = 0f;
            close.color = tempColor4;

            var tempColor7 = menu_up.color;
            tempColor7.a = 0f;
            menu_up.color = tempColor7;

            var tempColor8 = menu_down.color;
            tempColor8.a = 0f;
            menu_down.color = tempColor8;

            var tempColor10 = menu_button7.color;
            tempColor10.a = 0f;
            menu_button7.color = tempColor10;

            var tempColor11 = tab1.color;
            tempColor11.a = 0f;
            tab1.color = tempColor11;

            var tempColor12 = tab2.color;
            tempColor12.a = 0f;
            tab2.color = tempColor12;

            var tempColor13 = tab3.color;
            tempColor13.a = 0f;
            tab3.color = tempColor13;
        }


        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                UI_Toggle = !UI_Toggle;

                if (UI_Toggle)
                {
                    Debug.Log("user pressed open menu");
                    
                    var tempColor = menu_background.color;
                    tempColor.a = 100f;
                    menu_background.color = tempColor;

                    var tempColor4 = close.color;
                    tempColor4.a = 100f;
                    close.color = tempColor4;

                    var tempColor7 = menu_up.color;
                    tempColor7.a = 100f;
                    menu_up.color = tempColor7;

                    var tempColor8 = menu_down.color;
                    tempColor8.a = 100f;
                    menu_down.color = tempColor8;

                    var tempColor10 = menu_button7.color;
                    tempColor10.a = 100f;
                    menu_button7.color = tempColor10;

                    // 11 and 12 are for tab 2
                    var tempColor11 = tab1.color;
                    tempColor11.a = 100f;
                    tab1.color = tempColor11;

                    var tempColor12 = tab2.color;
                    tempColor12.a = 100f;
                    tab2.color = tempColor12;

                    var tempColor13 = tab3.color;
                    tempColor13.a = 100f;
                    tab3.color = tempColor13;

                    text4_object.gameObject.SetActive(true);
                    text7_object.gameObject.SetActive(true);
                    text9_object.gameObject.SetActive(true);
                    text10_object.gameObject.SetActive(true);
                    text11_object.gameObject.SetActive(true);
                    text12_object.gameObject.SetActive(true);
                    text13_object.gameObject.SetActive(true);
                    text14_object.gameObject.SetActive(true);

                    if (is_tab1)
                    {
                        tabOne_buttons.gameObject.SetActive(true);
                        tabTwo_buttons.gameObject.SetActive(false);
                        tabThree_buttons.gameObject.SetActive(false);
                    }
                    else if (is_tab2)
                    {
                        tabOne_buttons.gameObject.SetActive(false);
                        tabTwo_buttons.gameObject.SetActive(true);
                        tabThree_buttons.gameObject.SetActive(false);
                    }
                    else if (is_tab3)
                    {
                        tabOne_buttons.gameObject.SetActive(false);
                        tabTwo_buttons.gameObject.SetActive(false);
                        tabThree_buttons.gameObject.SetActive(true);
                    }
                    else
                    {
                        tabOne_buttons.gameObject.SetActive(true);
                        tabTwo_buttons.gameObject.SetActive(false);
                        tabThree_buttons.gameObject.SetActive(false);
                    }

                    display1.gameObject.SetActive(true);
                    display2.gameObject.SetActive(true);

                    hubSwitch.UserCoordsToDataBase();
                }
                else
                {
                    Debug.Log("user pressed close menu");
                    tabOne_buttons.gameObject.SetActive(false);
                    tabTwo_buttons.gameObject.SetActive(false);
                    tabThree_buttons.gameObject.SetActive(false);

                    var tempColor = menu_background.color;
                    tempColor.a = 0f;
                    menu_background.color = tempColor;

                    var tempColor4 = close.color;
                    tempColor4.a = 0f;
                    close.color = tempColor4;

                    var tempColor7 = menu_up.color;
                    tempColor7.a = 0f;
                    menu_up.color = tempColor7;

                    var tempColor8 = menu_down.color;
                    tempColor8.a = 0f;
                    menu_down.color = tempColor8;

                    var tempColor10 = menu_button7.color;
                    tempColor10.a = 0f;
                    menu_button7.color = tempColor10;

                    var tempColor11 = tab1.color;
                    tempColor11.a = 0f;
                    tab1.color = tempColor11;

                    var tempColor12 = tab2.color;
                    tempColor12.a = 0f;
                    tab2.color = tempColor12;

                    var tempColor13 = tab3.color;
                    tempColor13.a = 0f;
                    tab3.color = tempColor13;

                    text4_object.gameObject.SetActive(false);
                    text7_object.gameObject.SetActive(false);
                    text9_object.gameObject.SetActive(false);
                    text10_object.gameObject.SetActive(false);
                    text11_object.gameObject.SetActive(false);
                    text12_object.gameObject.SetActive(false);
                    text13_object.gameObject.SetActive(false);
                    text14_object.gameObject.SetActive(false);

                    display1.gameObject.SetActive(false);
                    display2.gameObject.SetActive(false);
                }
            }
        }
    }
}
