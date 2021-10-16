using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceA : MonoBehaviour
{
	Text output;
	
	string[] no = {"hi", "bye", "not much, hbu"};
	string[] yes = {"wut", "no", "idk"};

	
    // Start is called before the first frame update
    void Start()
    {
        output = GetComponent<Text>();
		pickText();
    }

    // Update is called once per frame
    void pickText()
	{
		Debug.Log(Rounds.question);
		
		if (Rounds.choice <= .5)
		{
			output.text = no[Rounds.question];
		} else {
			output.text = yes[Rounds.question];
		}
	}
	void update()
	{
		
	}
	
}
