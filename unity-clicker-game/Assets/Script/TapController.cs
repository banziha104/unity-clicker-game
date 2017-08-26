using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapController : MonoBehaviour
{
	public GameObject Tap1, Tap2, Tap3, Tap4;

	public int currentTapNumber = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void OnClikcTap(int tapNumber)
	{
		if (tapNumber == currentTapNumber)
		{
			Tap1.SetActive(false); //탭을 닫음
			currentTapNumber = 0; 
		}
		else
		{
			Tap1.SetActive(true);
			Tap2.SetActive(false);
			Tap3.SetActive(false);
			Tap4.SetActive(false);
			currentTapNumber = 1;
		}
	}
}
