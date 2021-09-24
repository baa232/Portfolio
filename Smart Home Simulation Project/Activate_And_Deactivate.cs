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
        //public GameObject text_object;
        //public GameObject text2_object;
        //public GameObject text3_object;
        public GameObject text4_object;
        //public GameObject text5_object;
        //public GameObject text6_object;
        public GameObject text7_object;
        //public GameObject text8_object;
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
        //public Image menu_button1;
        //public Image menu_button2;
        //public Image menu_button3;
        //public Image menu_button4;
        //public Image menu_button5;
        //public Image menu_button6;
        public Image menu_button7;
        public Image menu_up;
        public Image menu_down;
        public Image tab1;
        public Image tab2;
        public Image tab3;
        //public Image a;
        //public Image b;

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
            //text_object.gameObject.SetActive(false);
            //text2_object.gameObject.SetActive(false);
            //text3_object.gameObject.SetActive(false);
            text4_object.gameObject.SetActive(false);
            //text5_object.gameObject.SetActive(false);
            //text6_object.gameObject.SetActive(false);
            text7_object.gameObject.SetActive(false);
            //text8_object.gameObject.SetActive(false);
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

            //var tempColor1 = menu_button1.color;
            //tempColor1.a = 0f;
            //menu_button1.color = tempColor1;

            //var tempColor2 = menu_button2.color;
            //tempColor2.a = 0f;
            //menu_button2.color = tempColor2;

            //var tempColor3 = menu_button3.color;
            //tempColor3.a = 0f;
            //menu_button3.color = tempColor3;

            var tempColor4 = close.color;
            tempColor4.a = 0f;
            close.color = tempColor4;

            //var tempColor5 = menu_button4.color;
            //tempColor5.a = 0f;
            //menu_button4.color = tempColor5;

            //var tempColor6 = menu_button5.color;
            //tempColor6.a = 0f;
            //menu_button5.color = tempColor6;

            var tempColor7 = menu_up.color;
            tempColor7.a = 0f;
            menu_up.color = tempColor7;

            var tempColor8 = menu_down.color;
            tempColor8.a = 0f;
            menu_down.color = tempColor8;

            //var tempColor9 = menu_button6.color;
            //tempColor9.a = 0f;
            //menu_button6.color = tempColor9;

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
            //var tempColor13 = a.color;
            //tempColor13.a = 0f;
            //a.color = tempColor13;

            //var tempColor14 = b.color;
            //tempColor14.a = 0f;
            //b.color = tempColor14;
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

                    //var tempColor1 = menu_button1.color;
                    //tempColor1.a = 100f;
                    //menu_button1.color = tempColor1;

                    //var tempColor2 = menu_button2.color;
                    //tempColor2.a = 100f;
                    //menu_button2.color = tempColor2;

                    //var tempColor3 = menu_button3.color;
                    //tempColor3.a = 100f;
                    //menu_button3.color = tempColor3;

                    var tempColor4 = close.color;
                    tempColor4.a = 100f;
                    close.color = tempColor4;

                    //var tempColor5 = menu_button4.color;
                    //tempColor5.a = 100f;
                    //menu_button4.color = tempColor5;

                    //var tempColor6 = menu_button5.color;
                    //tempColor6.a = 100f;
                    //menu_button5.color = tempColor6;

                    var tempColor7 = menu_up.color;
                    tempColor7.a = 100f;
                    menu_up.color = tempColor7;

                    var tempColor8 = menu_down.color;
                    tempColor8.a = 100f;
                    menu_down.color = tempColor8;

                    //var tempColor9 = menu_button6.color;
                    //tempColor9.a = 100f;
                    //menu_button6.color = tempColor9;

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

                    // 13 and 14 are the tab buttons
                    //var tempColor13 = a.color;
                    //tempColor13.a = 100f;
                    //a.color = tempColor13;

                    //var tempColor14 = b.color;
                    //tempColor14.a = 100f;
                    //b.color = tempColor14;

                    //text_object.gameObject.SetActive(true);
                    //text2_object.gameObject.SetActive(true);
                    //text3_object.gameObject.SetActive(true);
                    text4_object.gameObject.SetActive(true);
                    //text5_object.gameObject.SetActive(true);
                    //text6_object.gameObject.SetActive(true);
                    text7_object.gameObject.SetActive(true);
                    //text8_object.gameObject.SetActive(true);
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
                    //Debug.Log("Enabled!");

                    hubSwitch.UserCoordsToDataBase();
                }
                else
                {
                    //THIS IS A SIMPLE FIX TO THE ISSUE
                    Debug.Log("user pressed close menu");
                    tabOne_buttons.gameObject.SetActive(false);
                    tabTwo_buttons.gameObject.SetActive(false);
                    tabThree_buttons.gameObject.SetActive(false);

                    var tempColor = menu_background.color;
                    tempColor.a = 0f;
                    menu_background.color = tempColor;

                    //var tempColor1 = menu_button1.color;
                    //tempColor1.a = 0f;
                    //menu_button1.color = tempColor1;

                    //var tempColor2 = menu_button2.color;
                    //tempColor2.a = 0f;
                    //menu_button2.color = tempColor2;

                    //var tempColor3 = menu_button3.color;
                    //tempColor3.a = 0f;
                    //menu_button3.color = tempColor3;

                    var tempColor4 = close.color;
                    tempColor4.a = 0f;
                    close.color = tempColor4;

                    //var tempColor5 = menu_button4.color;
                    //tempColor5.a = 0f;
                    //menu_button4.color = tempColor5;

                    //var tempColor6 = menu_button5.color;
                    //tempColor6.a = 0f;
                    //menu_button5.color = tempColor6;

                    var tempColor7 = menu_up.color;
                    tempColor7.a = 0f;
                    menu_up.color = tempColor7;

                    var tempColor8 = menu_down.color;
                    tempColor8.a = 0f;
                    menu_down.color = tempColor8;

                    //var tempColor9 = menu_button6.color;
                    //tempColor9.a = 0f;
                    //menu_button6.color = tempColor9;

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

                    //var tempColor13 = a.color;
                    //tempColor13.a = 0f;
                    //a.color = tempColor13;

                    //var tempColor14 = b.color;
                    //tempColor14.a = 0f;
                    //b.color = tempColor14;

                    //text_object.gameObject.SetActive(false);
                    //text2_object.gameObject.SetActive(false);
                    //text3_object.gameObject.SetActive(false);
                    text4_object.gameObject.SetActive(false);
                    //text5_object.gameObject.SetActive(false);
                    //text6_object.gameObject.SetActive(false);
                    text7_object.gameObject.SetActive(false);
                    //text8_object.gameObject.SetActive(false);
                    text9_object.gameObject.SetActive(false);
                    text10_object.gameObject.SetActive(false);
                    text11_object.gameObject.SetActive(false);
                    text12_object.gameObject.SetActive(false);
                    text13_object.gameObject.SetActive(false);
                    text14_object.gameObject.SetActive(false);

                    //if (is_tab1)
                    //{

                    //    tabOne_buttons.gameObject.SetActive(false);
                    //    tabTwo_buttons.gameObject.SetActive(false);
                    //    tabThree_buttons.gameObject.SetActive(false);

                    //}
                    //if (is_tab2)
                    //{
                    //    tabOne_buttons.gameObject.SetActive(false);
                    //    tabTwo_buttons.gameObject.SetActive(false);
                    //    tabThree_buttons.gameObject.SetActive(false);
                    //}
                    //if (is_tab3)
                    //{
                    //    tabOne_buttons.gameObject.SetActive(false);
                    //    tabTwo_buttons.gameObject.SetActive(false);
                    //    tabThree_buttons.gameObject.SetActive(false);
                    //}

                    display1.gameObject.SetActive(false);
                    display2.gameObject.SetActive(false);
                    //Debug.Log("Disabled!");
                }
            }
        }
    }
}
