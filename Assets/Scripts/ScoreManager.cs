using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    
    [Header("UI")]
    public TextMeshProUGUI scoreText;

    [Header("Score Variables")]
    [SerializeField]int curScore = 0;
    [SerializeField] float standardMultiplier = 0.5f;
    [SerializeField] float huntingBonus = 10f;
    
    bool huntingBonusActive = false;

    float scoreTimer;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        scoreTimer = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        ShowScore();

        if (scoreTimer > 0)
        {
            scoreTimer -= Time.deltaTime;
        }
        else
        {
            IncreaseScoreTime();
            scoreTimer = 2f;
        }
    }

    public void AddHuntingBonus(int bonus = 10)
    {
        curScore += bonus;
        ShowScore();
    }

    void ShowScore()
    {
        scoreText.text = "Score: " + curScore;
    }

    public void IncreaseScoreTime()
    {
        curScore += 1;
        ShowScore();
    }

    public int GetCurScore()
    {
        return curScore;
    }
}
