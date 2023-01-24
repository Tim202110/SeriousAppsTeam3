using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundswitcher : MonoBehaviour
{
    //Calling GameObjects
    public GameObject casinobackground;
    public GameObject vegasbackground;
    public GameObject nederlandbackground;

    //Making true or false statements
    public bool iscasinobackground = false;
    public bool isvegasbackground = false;
    public bool isnederlandbackground = false;

    //Backgroundswitching
    void Test()
    {
        if (iscasinobackground == true) //Casino background
        {
            casinobackground.SetActive(true);
            vegasbackground.SetActive(false);
            nederlandbackground.SetActive(false);

            iscasinobackground = true;
            isvegasbackground = false;
            isnederlandbackground = false;
        }
        else if (isvegasbackground == true) //Vegas background
        {
            casinobackground.SetActive(false);
            vegasbackground.SetActive(true);
            nederlandbackground.SetActive(false);

            iscasinobackground = false;
            isvegasbackground = true;
            isnederlandbackground = false;
        }
        else if (isnederlandbackground == true) //Nederland background
        {
            casinobackground.SetActive(false);
            vegasbackground.SetActive(false);
            nederlandbackground.SetActive(true);

            iscasinobackground = false;
            isvegasbackground = false;
            isnederlandbackground = true;
        }
    }    
}
