using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalPlayerDataManager : MonoBehaviour
{
    
    static LocalPlayerDataManager Singleton;
    public string bearName;
    public int playerScore;

    private void Awake()
    {
        Singleton = this;
        DontDestroyOnLoad(this);
    }
    
    public void SetBearName(string name)
    {
        bearName = name;
    }

}
