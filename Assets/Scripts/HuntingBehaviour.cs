using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FishingBehaviour : BaseBehaviour
{
    //Debug Things
    [Header("Debug Things")]
    public TextMeshProUGUI debugActionsText;
    [Space(10)]

    [Header("Fishing Variables")]
    
    public bool isFishing = false;

    [SerializeField]KeyCode[] actionKeys;

    [SerializeField]KeyCode[] curActions;
    [SerializeField]int curIndex = 0;

    KeyCode[] actionKeysSet = {
        KeyCode.W,
        KeyCode.A,
        KeyCode.S,
        KeyCode.D
    };


    // Start is called before the first frame update
    void Start()
    {
        StartFishing(4);    
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
        debugActionsText.text = "Fishing Done!";
    }

    void GenerateRandomActions(int totActions)
    {
        actionKeys = new KeyCode[totActions];
        curActions = new KeyCode[totActions];
        curIndex = 0;
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
            debugActionsText.text += action.ToString() + " ";
        }
    }
}
