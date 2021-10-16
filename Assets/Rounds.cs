using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rounds : MonoBehaviour
{
	public int rounds = 3;
	public static float choice;
	public static int question;
	Text output;
    // Start is called before the first frame update
    void Start()
    {
		output = GetComponent<Text>();
        initiate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	void initiate()
	{
		output.text = "Round: " + rounds.ToString();
		choice = (Random.value);
		question = Mathf.RoundToInt(Random.value * 2);
		Debug.Log(choice + " " + question);
		/*if (rounds == 0)
		{
			return;
		} else {
			rounds = rounds - 1;
			initiate();
		}*/
	}
}
