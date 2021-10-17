//Main chunk of code for game
//Changes to be made:
//add start screen and start button
//add reset button
//skips round 9





using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rounds : MonoBehaviour
{
	public int rounds;
	public static float choice;
	public static int question;
	public static bool over;
	Text output;
	float interval;
	bool end;
	
string[] q = {
"How do you do in front of the camera?", 
"What is your approach to acting in general?", 
"How do you work with other actors, as well as crew and directors?", 
"How do you feel about being included in promotional materials?", 
"How would you describe your work ethic?", 
"Do you know how to sing?", 
"How many languages can you speak?  Your character may need to speak non-English languages.", 
"How athletic/healthy is your lifestyle?  We want our actors as physically fit as possible.", 
"You may need to dance for your role.  How experienced are you at dancing?",
"What is your favorite part of acting?",
"How long have you been acting for?",
"We may need you to be flexible in terms of where you are working.  Every so often, you may have to travel around the country or even to other countries.",
"How far away do you live from the place where we are filming?",
"Depending on how much budget we have, we might get a cameo from a big-name actor, like Merly Streep or Dwayne the Rock Johnson. How do you act around big names?",
"Do you feel frustrated that you are not a famous star?",
"How do you research and approach a new role?",
"Your character may have a foreign accent.  How experienced are you in imitating foreign accents?"
};

string[] yes = {"I do takes consistently well, but am able to take director’s notes!", 
"I try to get into the headspace of my character, through mental, emotional, and physical methods", 
"I can be pretty shy between takes, but I treat coworkers with respect and get my job done well",
"Anything goes, no matter how I’m portrayed!",
"I work hard and always show up to work on time.  Whenever I am on set, I am giving 100% effort.  I only call off work when there’s an emergency.", 
"No, I cannot sing.  I am eager to learn how and am willing to spend my free time practicing.", 
"I am fluent in English and can speak a little bit of German.", 
"Every morning, I manage to find time to go for a good run.", 
"I have been dancing since I was 8 years old.  I took a break for several years during university, but now I have been practicing again.",
"I really enjoy the freedom that comes with acting.  I can be whomever I want to be, as long as there’s a role for it.  The escape from reality has fascinated me… ever since I was a young child.",
"I hope to continuously improve my acting career.  Over the next 5 years, I want to gain as much acting experience and knowledge as possible.  While I may not become the most famous actor, I want to have a very successful career in this field.",
"I have been acting for my whole life.  I have been doing it ever since I can remember, and my passion for it is still going strong.  I still enjoy it as much as I did when I started.",
"Yes, I can be flexible.  I love visiting new places and this sounds like a perfect opportunity for me to do so.",
"I live about 10 miles away, but I have access to a car, so it should take 15 minutes and I can help with any other transportation",
"I try to act as professionally as possible, on and off camera, even if my mind is going into overdrive!",
"I am not famous… yet!  I hope to have a successful career and we’ll see where that takes me.",
"If this character was a real person, I typically do some online research about their history.  If the character is fictitious, I read the script more than once, attempting to internalize their personality.  After that, I take a walk to clear my head and put myself in the right mental state for acting.",
"Accents are something that I have to work very hard at.  After years of work with my accent coach, I have perfected 2 different English accents and 5 different non-English accents."
};

string[] no = {
"I get shy in front of cameras and often miss my marks for staging", 
"I often go off script or improvise based on what I feel I would do in the character’s situation.", 
"I’m very outgoing and sociable, but shoots take longer as its harder to get me refocused after we cut",
"I won’t do it unless I discuss with my lawyer!", 
"I work hard!  Typically, I’m only a few minutes late to work.  I may require more breaks than my co-workers, but I do put in effort during the work day.", 
"Yes, I can sing.  I am a sub-par singer and have little passion for music.", 
"I am fluent in English and can fluently understand Spanish and Chinese.", 
"I exercise for 30 minutes every day.  I run around the neighborhood, do push ups, and lift weights.  After every workout, I consume a fast food meal fit for three people.  Who knows why I keep gaining weight…", 
"I really love dancing, and I have been practicing for the last year.  I am a rather casual dancer and my skills are far from professional level.",
"Acting is the only thing that I have ever been good at.  How else will I pay the bills?",
"I have been acting all of my life.  It is something that I enjoy, and have been enjoying ever since I could remember.  However, I also have been doing other activities like animation and music production on the side.  I like acting, but in 5 years I may move on with my career.",
"Yes, going to new places sounds great!  Is this like a vacation?  Will I be able to work less after I’ve travelled there?",
"I live 3 miles away, but I have to walk over/need to be picked up in order to arrive on set.",
"I drool at the mouth and hound them for an autograph. I mean, c’mon, they’re stars!",
"Yeah, it can be frustrating.  Everyone hopes to make it big and I’m no exception.  Man what I would do for that…",
"I jump right into the role.  Researching takes time, and that time is better spent with practice in my opinion.  I may not be able to perfect the role, but I’m a bit quicker when we get started without preparation.",
"Foreign accents are something that come naturally to me.  I can speak in an Australian accent quite easily, but I’ve never tried to imitate anything else."
};



    // Start is called before the first frame update
    void Start()
    {
		initiate();
		
    }
	void initiate()
	{
		rounds = 10;
		SC_CountdownTimer.countdownInternal = 20;
		Score.score = 0;
		end = false;
		SC_CountdownTimer.countdownOver = false;
		output = GetComponent<Text>();
        output.text = "Round: " + rounds.ToString();
		choice = (Random.value);
		question = Mathf.RoundToInt(Random.value * 16);
		Debug.Log(choice + " " + question);
		over = false;
		interval = SC_CountdownTimer.countdownTime / (rounds);
		MainText.output.text = "";
		newRound();
	}


    // Update is called once per frame
    void Update()
    {
        Debug.Log(choice);
		if (rounds == 0)
		{
			endstate();
			return;
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			if (choice > .5)
			{
				updateScore(2);
			} else {
				updateScore(-1);
			}
			newRound();
			Debug.Log("a");
		}
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			if (choice > .5)
			{
				updateScore(-1);
			} else {
				updateScore(2);
			}
			newRound();
			Debug.Log("a");
		}
		if (over)
		{
			SC_CountdownTimer.countdownOver = false;
			Debug.Log("over");
		}
    }
	void newRound()
	{
		
		rounds = rounds - 1;
		choice = (Random.value);
		question = Mathf.RoundToInt(Random.value * 16);
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
		if (choice > .5)
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
	void endstate()
	{
		Question.output.text = " ";
		ChoiceA.output.text = "";
		ChoiceB.output.text = "";
		Score.output.text = "";
		SC_CountdownTimer.countdownInternal = 0f;
		MainText.output.text = "Game Over: " + Score.score + " points";
		end = true;
	}

}
