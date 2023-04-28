using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class TimerStart : Timer
{
    private bool start = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !start)
        {
            UnityEngine.Debug.Log("Start time: " + DateTime.Now);
            start = true;
            //sw.Start();
            //start = true;
            //stop = false;
            //printed = false;
        }
    }
}
