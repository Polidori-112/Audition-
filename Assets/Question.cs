using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Question : MonoBehaviour
{
	Text output;

	
	string[] q = {"hello", "goodbye", "wazzzzzzzup"};
	

	
    // Start is called before the first frame update
    void Start()
    {
        output = GetComponent<Text>();
		pickText();
    }
	
    // Update is called once per frame
    void pickText()
	{
		output.text = q[Rounds.question];
	}
	void update()
	{
		
	}
	
}