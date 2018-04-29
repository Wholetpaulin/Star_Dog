using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {

    int score;          // our counter for the score
    Text scoreText;     // reference to the score text item (onscreen)

    void Start () {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
	}
	
    public void ScoreHit(int inputScore)
    {
        score = score + inputScore;
        scoreText.text = score.ToString();  // Change the text onscreen to the update score
    }
}
