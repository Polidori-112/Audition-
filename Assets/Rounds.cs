//Main chunk of code for game
//Changes to be made:
//add start screen and start button
//add reset button




using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rounds : MonoBehaviour
{
	public int rounds = 10;
	public static float choice;
	public static int question;
	public static bool over;
	Text output;
	float interval;
	
	string[] q = {"How do you do in front of the camera?", "What is your approach to acting in general?", "How do you work with other actors, as well as crew and directors?", "How do you feel about being included in promotional materials?", "How would you describe your work ethic?", "Do you know how to sing?", "How many languages can you speak?  Your character may need to speak non-English languages.", "How athletic/healthy is your lifestyle?  We want our actors as physically fit as possible.", "You may need to dance for your role.  How experienced are you at dancing?"};
	string[] yes = {"I do takes consistently well, but am able to take director’s notes!", "I try to get into the headspace of my character, through mental, emotional, and physical methods", "I can be pretty shy between takes, but I treat coworkers with respect and get my job done well", "I would like to discuss them with my lawyer!", "I work hard and always show up to work on time.  Whenever I am on set, I am giving 100% effort.  I only call off work when there’s an emergency.", "No, I cannot sing.  I am eager to learn how and am willing to spend my free time practicing.", "I am fluent in English and can speak a little bit of German.", "I spend a lot of time at my computer studying film and theater.  Every morning, I manage to find time to go for a quick run.", "I have been dancing since I was 8 years old.  I took a break for several years during university, but now I have been practicing again."};
	string[] no = {"I get shy in front of cameras and often miss my marks for staging", "I often go off script or improvise based on what I feel I would do in the character’s situation.", "I’m very outgoing and sociable, but shoots take longer as its harder to get me refocused after we cut", "Anything goes, no matter how I’m portrayed!", "I work hard!  Typically, I’m only a few minutes late to work.  I may require more breaks than my co-workers, but I do put in effort during the work day.", "Yes, I can sing.  I am a sub-par singer and have little passion for music.", "I am fluent in English and can fluently understand Spanish and Chinese.", "I exercise for 30 minutes every day.  I run around the neighborhood, do push ups, and lift weights.  After every workout, I consume a fast food meal fit for three people.  Who knows why I keep gaining weight…", "I really love dancing, and I have been practicing for the last year.  I am a rather casual dancer and my skills are far from professional level."};


    // Start is called before the first frame update
    void Start()
    {
		output = GetComponent<Text>();
        output.text = "Round: " + rounds.ToString();
		choice = (Random.value);
		question = Mathf.RoundToInt(Random.value * 8);
		Debug.Log(choice + " " + question);
		over = false;
		interval = SC_CountdownTimer.countdownTime / (rounds);
		MainText.output.text = "";
		
    }


    // Update is called once per frame
    void Update()
    {
        if (rounds == 0)
		{
			Question.output.text = " ";
			ChoiceA.output.text = "";
			ChoiceB.output.text = "";
			Score.output.text = "";
			SC_CountdownTimer.countdownInternal = 0f;
			MainText.output.text = "Game Over: " + Score.score + " points";
			return;
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			if (Rounds.choice > .5)
			{
				updateScore(-1);
			} else {
				updateScore(2);
			}
			newRound();
			Debug.Log("a");
		}
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			if (Rounds.choice > .5)
			{
				updateScore(2);
			} else {
				updateScore(-1);
			}
			newRound();
			Debug.Log("a");
		}
		if (over)
		{
			SC_CountdownTimer.countdownOver = false;
			newRound();
			Debug.Log("over");
		}
    }
	void newRound()
	{
		rounds = rounds - 1;
		choice = (Random.value);
		question = Mathf.RoundToInt(Random.value * 8);
		pickText();
		Score.output.text = "Score: " + Score.score.ToString();
		output.text = "Round: " + rounds.ToString();
		
		if (SC_CountdownTimer.countdownOver == false) {
			SC_CountdownTimer.countdownTime -= interval;
			SC_CountdownTimer.countdownInternal = SC_CountdownTimer.countdownTime;
			if (SC_CountdownTimer.countdownInternal < 0) {
				SC_CountdownTimer.countdownInternal = 0.01f;
			}
		}
		
	}
	void pickText()
	{
		Question.output.text = q[question];
		if (Rounds.choice > .5)
		{
			ChoiceB.output.text = no[Rounds.question];
			ChoiceA.output.text = yes[Rounds.question];
		} else {
			ChoiceB.output.text = yes[Rounds.question];
			ChoiceA.output.text = no[Rounds.question];
		}
	}
	void updateScore(int mult)
	{
		Score.score += mult*100*Mathf.RoundToInt(SC_CountdownTimer.countdownInternal) / Mathf.RoundToInt(SC_CountdownTimer.countdownTime);
		Debug.Log(Score.score);
	}

}
