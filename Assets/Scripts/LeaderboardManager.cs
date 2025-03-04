using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Unity.Services.Leaderboards;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Leaderboards.Models;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class LeaderboardManager : MonoBehaviour
{
   private int score;

   [SerializeField]
   GameObject canvas;
   
   [SerializeField]
   GameObject entryPrefab;

   [SerializeField] private GameObject titleText;

   public static LeaderboardManager Singleton;
   
   private async void Awake()
   {
      Singleton = this;
      await UnityServices.InitializeAsync();
      await AuthenticationService.Instance.SignInAnonymouslyAsync();
      
   }

   
   
   public async void AddScore(int score,string nPlayerName)
   {
      ScoreData scoreData = new ScoreData{playerName = nPlayerName};
      var playerEntry = await LeaderboardsService.Instance.AddPlayerScoreAsync("High_Scores", score, new AddPlayerScoreOptions{Metadata = scoreData});
   }

   async void FetchLeaderboard()
   { 
      LeaderboardScoresPage leaderboardEntries = await LeaderboardsService.Instance.GetScoresAsync("High_Scores",new GetScoresOptions{IncludeMetadata = true});

      titleText.SetActive(true);
      
      int count = 0;
      foreach (var entry in leaderboardEntries.Results)
      {
         ScoreData scoreData = JsonUtility.FromJson<ScoreData>(entry.Metadata);
         
         GameObject entryVisual = Instantiate(entryPrefab,canvas.transform);
         entryVisual.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,-80-count*40);
         entryVisual.GetComponent<LeaderboardEntryVisual>().SetText((entry.Rank+1).ToString(),scoreData.playerName,entry.Score.ToString());
         
      }
      
   }

   public void FetchLeaderboardDelay()
   {
      StartCoroutine(FetchLeaderboardCoroutine());
   }

   private IEnumerator FetchLeaderboardCoroutine()
   {
      yield return new WaitForSeconds(0.5f);
      FetchLeaderboard();
   }

}

[Serializable]
public class ScoreData
{
   public string playerName;
}