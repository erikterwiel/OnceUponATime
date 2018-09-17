using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class DisplayText : MonoBehaviour
{

	public Text displayText;
	// Use this for initialization
	void Start ()
	{
		displayText.text = "BLORP BLORP";
	}
	
	// Update is called once per frame
	void Update ()
	{
		{
			displayText.text = "Text has changed.";
		}
	}
}

