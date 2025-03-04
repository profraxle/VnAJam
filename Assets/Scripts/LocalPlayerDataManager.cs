using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalPlayerDataManager : MonoBehaviour
{
    
    public static LocalPlayerDataManager Singleton;
    public string bearName;
    public int playerScore;

    private void Awake()
    {
        Singleton = this;
        DontDestroyOnLoad(this);
    }
    
}
