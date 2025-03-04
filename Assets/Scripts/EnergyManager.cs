using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class EnergyManager : MonoBehaviour
{
    public static EnergyManager instance;

    

    [Header("Energy Variables")]
    [SerializeField] float idleRate = 0.005f;

    [SerializeField] float moveRate = 0.0075f;
    public bool isMoving = false;

    [SerializeField] float swimRate = 0.009f;
    public bool isSwimming = false;

    [SerializeField] float fishingRate = 0.5f;
    public bool hasFished = false;

    [SerializeField] float curEnergy;
    float maxEnergy = 100;
    [Space(10)]

    [Header("Energy UI")]
    public GameObject sliderGO;
    Slider slider;

    [Header("Life")]
    public bool dead = false;

    private bool endGame;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        curEnergy = maxEnergy;
        slider = sliderGO.GetComponent<Slider>();
        slider.maxValue = maxEnergy;
        slider.value = curEnergy;
        endGame = false;
    }

    void UpdateSlider()
    {
        slider.value = curEnergy;
    }

    void IdleDrain()
    {
        if(curEnergy > 0)
        {
            curEnergy -= idleRate;
            UpdateSlider();
        }
        else
        {
            dead = true;
            curEnergy = 0;
            UpdateSlider();
        }
    }

    void SwimDrain()
    {
        if (curEnergy > 0)
        {
            curEnergy -= swimRate;
            UpdateSlider();
        }
        else
        {
            dead = true;
            curEnergy = 0;
            UpdateSlider();
        }
    }

    void MoveDrain()
    {
        if (curEnergy > 0)
        {
            curEnergy -= moveRate;
            UpdateSlider();
        }
        else
        {
            dead = true;
            curEnergy = 0;
            UpdateSlider();
        }
    }

    IEnumerator GainEnergy()
    {
        while(curEnergy < maxEnergy)
        {
            curEnergy += fishingRate;
            UpdateSlider();
            yield return new WaitForSeconds(.1f);
        }
        hasFished = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            IdleDrain();

            if (isMoving)
            {
                MoveDrain();
            }

            if (isSwimming)
            {
                SwimDrain();
            }

            if (hasFished)
            {
                StartCoroutine(nameof(GainEnergy));
            }
        }
        else
        {
            if (!endGame)
            {
                endGame = true;

                LocalPlayerDataManager.Singleton.playerScore = ScoreManager.instance.GetCurScore();
                SceneManager.LoadScene("Leaderboard");
            }
        }
    }
}
