using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;


public class FishingBehaviour : BaseBehaviour
{
    [Space(10)]

    [Header("Fishing Variables")]
    
    public bool isFishing = false;

    [SerializeField]InputAction[] actionKeys;

    [SerializeField]InputAction[] curActions;
    [SerializeField]int curIndex = 0;

    InputAction[] actionKeysSet = new InputAction[4];

    [SerializeField]
    private float fishDelayMax;
    private float fishDelay;

    [SerializeField]
    public GameObject arrowHUD;

    private Dictionary<InputAction, int> arrowDict = new Dictionary<InputAction, int>();
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        actionKeysSet[0] = InputSystem.actions.FindAction("FishUp");
        actionKeysSet[1] = InputSystem.actions.FindAction("FishDown");
        actionKeysSet[2] = InputSystem.actions.FindAction("FishLeft");
        actionKeysSet[3] = InputSystem.actions.FindAction("FishRight");

        for (int i = 0; i < actionKeysSet.Length; i++)
        {
            arrowDict.Add(actionKeysSet[i], i);
        }
        
        fishDelay = 0;
        // StartFishing(4);
    }

    // Update is called once per frame
    public override void BehaviourUpdate()
    {
        if (isFishing)
        {
            if (!arrowHUD.gameObject.activeInHierarchy)
            {
                arrowHUD.gameObject.SetActive(true);
            }
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
        else
        {
            if (fishDelay > 0)
            {
                fishDelay -= Time.deltaTime;
            }
            else
            {
                StartFishing(4);
            }
        }
    }

    void FishingDoneSuccess()
    {
        fishDelay = fishDelayMax;
        isFishing = false;
        ScoreManager.instance.AddHuntingBonus();
        
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

       
        int counter = 0;
        foreach(InputAction action in actionKeys)
        {
            
            //use dict to find arrow index and feed to the arrowHUD;
            arrowHUD.GetComponent<ArrowHUD>().UpdateImage(counter,arrowDict[action]);
            counter++;
        }
    }
}
