using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This file contains global variables to the project.
/// Values that need to be passed between scenes for example
/// </summary>
public class GlobalVars : MonoBehaviour
{
    static GlobalVars _instance;
    
    public int a = 1;

    void Start()
    {
       // Instance = this;
    }
}
