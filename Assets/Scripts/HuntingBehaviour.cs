using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;


public class FishingBehaviour : BaseBehaviour
{
    //Debug Things
    [Header("Debug Things")]
    public TextMeshProUGUI debugActionsText;
    [Space(10)]

    [Header("Fishing Variables")]
    
    public bool isFishing = false;

    [SerializeField]InputAction[] actionKeys;

    [SerializeField]InputAction[] curActions;
    [SerializeField]int curIndex = 0;

    InputAction[] actionKeysSet = new InputAction[4];

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        actionKeysSet[0] = InputSystem.actions.FindAction("FishUp");
        actionKeysSet[1] = InputSystem.actions.FindAction("FishDown");
        actionKeysSet[2] = InputSystem.actions.FindAction("FishLeft");
        actionKeysSet[3] = InputSystem.actions.FindAction("FishRight");

        StartFishing(4);
    }

    // Update is called once per frame
    void Update()
    {
        if (isFishing)
        {
            if (actionKeys[curIndex].IsPressed())
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
        EnergyManager.instance.hasFished = true;
    }

    void GenerateRandomActions(int totActions)
    {
        actionKeys = new InputAction[totActions];
        curActions = new InputAction[totActions];
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
        foreach(InputAction action in actionKeys)
        {
            debugActionsText.text += action.bindings[0].ToString() + " ";
        }
    }
}
