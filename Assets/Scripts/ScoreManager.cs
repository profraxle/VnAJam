using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI scoreText;

    [Header("Score Variables")]
    [SerializeField]int curScore = 0;
    [SerializeField] float standardMultiplier = 0.5f;
    [SerializeField] float huntingBonus = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowScore();
    }

    public void AddHuntingBonus(float bonus = 10)
    {
        curScore += (int)bonus;
    }

    void ShowScore()
    {
        curScore = (int) (TimeManager.instance.GetCurTime() * standardMultiplier);
        scoreText.text = "Score: " + curScore;
    }

    public int GetCurScore()
    {
        return curScore;
    }
}
