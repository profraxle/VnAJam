using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerName : MonoBehaviour
{
    public void SetBearName(string name)
    {
        LocalPlayerDataManager.Singleton.SetBearName(name);
    }
}
