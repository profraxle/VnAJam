using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingBehaviour : BaseBehaviour
{
    KeyCode[] actionKeysSet = { 
        KeyCode.W,
        KeyCode.A,
        KeyCode.S,
        KeyCode.D
    };

    KeyCode[] actionKeys;

    KeyCode[] curActions;
    int curIndex = 0;

    public bool isFishing = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFishing)
        {
            if (Input.GetKeyDown(actionKeys[curIndex]))
            {
                if(curIndex == actionKeys.Length - 1)
                {
                    isFishing = false;
                    FishingDoneSuccess();
                }
                else
                {
                    curActions[curIndex] = actionKeys[curIndex];
                    curIndex++;
                }
            }
        }
    }

    void FishingDoneSuccess()
    {
        Debug.LogError("Fishing was Successful");
    }

    void GenerateRandomActions(int totActions)
    {
        actionKeys = new KeyCode[totActions];
        for (int i=0; i < totActions; i++)
        {
            int index = Random.Range(0, actionKeysSet.Length);
            actionKeys[i] = actionKeysSet[index];
        }
    }

    public void StartFishing(int totActions)
    {
        isFishing = true;
        GenerateRandomActions(totActions);

        PrintActions();
    }

    void PrintActions()
    {
        foreach (KeyCode action in actionKeys)
        {
            Debug.Log("Press: " + action);
        }
    }
}
