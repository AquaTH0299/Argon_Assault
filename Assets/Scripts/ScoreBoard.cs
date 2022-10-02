using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    int score;
    TMP_Text scoretext;
    void Start() 
    {
        scoretext = GetComponent<TMP_Text>();
        scoretext.text = "START";
    }
    public void IncreaseScore(int amountToIncrease)
    {
        score += amountToIncrease;
        scoretext.text = score.ToString();
    }
}