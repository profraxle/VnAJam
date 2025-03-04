using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderboardEntryVisual : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField]
    GameObject rankText;
    
    [SerializeField]
    GameObject nameText;
    
    [SerializeField]
    GameObject scoreText;

    public void SetText(string rank, string name, string score)
    {
        rankText.GetComponent<TextMeshProUGUI>().text = rank;
        nameText.GetComponent<TextMeshProUGUI>().text = name;
        scoreText.GetComponent<TextMeshProUGUI>().text = score;
    }
}
