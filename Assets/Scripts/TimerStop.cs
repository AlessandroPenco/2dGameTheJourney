using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class TimerStop : Timer
{
    private bool stop = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !stop)
        {
            UnityEngine.Debug.Log("Stop time: " + DateTime.Now);
            stop = true;
            //sw.Stop();
            //if (!printed)
            //{
            //    printed = true;
            //    UnityEngine.Debug.Log(sw.Elapsed);
            //}
            //stop = true;
            //start = false;
        }
    }
}
