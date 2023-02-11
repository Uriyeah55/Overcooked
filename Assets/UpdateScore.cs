using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UpdateScore : MonoBehaviour
{
    public Text scoreText;
    void Update(){
        scoreText.text=General.totalScore.ToString();
    }
   
    public void AddScore(int amount){
        General.totalScore+=amount;
    }
}
