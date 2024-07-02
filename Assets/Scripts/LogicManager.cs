using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicManager : MonoBehaviour
{
   public int playerScore;
   public Text scoreText;
   public Text HighScoreText;
   public int highScore;
   public GameObject gameOverScreen;
   


     void Start()
     {
        if(PlayerPrefs.HasKey("highScore"))
        {
          highScore = PlayerPrefs.GetInt("highScore");
          try // use this to catch unecessay exceptions which are in red
          {
            HighScoreText.text = "High Score:" + highScore.ToString();
          }
      
         catch(Exception e)
        {
          Debug.Log(e, this);
         }  
    }  
  }

   // We need to give power to the Unity
   [ContextMenu("Increase Score")]
   public void addScore(int scoreToAdd)
   { 
     if(!gameOverScreen.activeSelf) // if the gameover screen is not active
     {
     playerScore = playerScore + scoreToAdd;
     Debug.Log(playerScore);
     scoreText.text = playerScore.ToString(); 
     }
   }
  
   // It is the Start Menu 
   public void Menu()
   {
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(1);
   }

   public void Restart()
   {
      int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
      SceneManager.LoadScene(currentSceneIndex);
   }

   public void Exit()
   {
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(0);
   }


   public void gameOver()
   {
    gameOverScreen.SetActive(true);

    if(playerScore > highScore)
    {
      highScore = playerScore;
      HighScoreText.text = "High Score:" + highScore.ToString();
      PlayerPrefs.SetInt("highScore", highScore);
      PlayerPrefs.Save();
    }
   }
  
   // Button to clear the High Score
   public void clearHighScore()
   {
     PlayerPrefs.DeleteKey("highScore");
     PlayerPrefs.Save();
   }
}

