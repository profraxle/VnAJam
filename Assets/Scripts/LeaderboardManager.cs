using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using TMPro;
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
   
   [SerializeField]
   GameObject spielText;

   public static LeaderboardManager Singleton;
   
   private async void Awake()
   {
      Singleton = this;
      await UnityServices.InitializeAsync();
      AuthenticationService.Instance.ClearSessionToken();
      await AuthenticationService.Instance.SignInAnonymouslyAsync();
 
   }

   private void Start()
   {
      spielText.GetComponent<TextMeshProUGUI>().text =
         "The melting ice caps are making it harder for Polar Bears to find food.\n \nTogether we can save them, adopt a Polar Bear like " +
         LocalPlayerDataManager.Singleton.bearName + " today with the WWF.";
      AddScore(LocalPlayerDataManager.Singleton.playerScore, LocalPlayerDataManager.Singleton.bearName);
      FetchLeaderboardDelay();
   }


   public async void AddScore(int score,string nPlayerName)
   {
      ScoreData scoreData = new ScoreData{playerName = nPlayerName};
      var playerEntry = await LeaderboardsService.Instance.AddPlayerScoreAsync("High_Scores", score, new AddPlayerScoreOptions{Metadata = scoreData});
   }

   async void FetchLeaderboard()
   { 
      LeaderboardScoresPage leaderboardEntries = await LeaderboardsService.Instance.GetScoresAsync("High_Scores",new GetScoresOptions{IncludeMetadata = true});

      //titleText.SetActive(true);
      
      int count = 0;
      foreach (var entry in leaderboardEntries.Results)
      {
         ScoreData scoreData = JsonUtility.FromJson<ScoreData>(entry.Metadata);
         
         GameObject entryVisual = Instantiate(entryPrefab,canvas.transform);
         entryVisual.GetComponent<RectTransform>().anchoredPosition = new Vector2(-400,-150-count*90);
         entryVisual.GetComponent<LeaderboardEntryVisual>().SetText((entry.Rank+1).ToString(),scoreData.playerName,entry.Score.ToString());
         count++;
      }
      
   }

   public void FetchLeaderboardDelay()
   {
      StartCoroutine(FetchLeaderboardCoroutine());
   }

   private IEnumerator FetchLeaderboardCoroutine()
   {
      yield return new WaitForSeconds(3f);
      FetchLeaderboard();
   }

}

[Serializable]
public class ScoreData
{
   public string playerName;
}