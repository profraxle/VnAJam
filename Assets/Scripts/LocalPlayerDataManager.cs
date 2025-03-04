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
        if (LocalPlayerDataManager.Singleton == null)
        {
            Singleton = this;
        }
        else
        {
            Destroy(this);
        }

        DontDestroyOnLoad(this);
    }
    
    public void SetBearName(string name)
    {
        bearName = name;
    }

    public void SetPlayerScore(int score)
    {
        playerScore = score;
    }

}
