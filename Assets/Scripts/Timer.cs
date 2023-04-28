using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DateTime sw = DateTime.Now;
        UnityEngine.Debug.Log("Time Begin Level: " + sw);
    }
}
