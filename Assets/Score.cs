using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text output;
	double score;
	
    void Start()
    {
        output = GetComponent<Text>();
		score = 0;
		updateScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	void updateScore()
	{
		if (Rounds.choice > .5) //& choice B
		{
			score += 100*SC_CountdownTimer.countdownTime;
		} else if (Rounds.choice < .5) //& choice A 
		{
			score += 100*SC_CountdownTimer.countdownTime;
		} /*else if (Rounds.choice < .5) //& choice B
		{
			score += -50*SC_CountdownTimer.countdownTime;
		}else if (Rounds.choice > .5) //& choice A 
		{
			score += -50*SC_CountdownTimer.countdownTime;
		}*/
		output.text = "Score: " + score.ToString();
	}
}
