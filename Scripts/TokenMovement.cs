using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenMovement : MonoBehaviour {
    public int diceValue;
    public int currentPosition = 1;
    DiceNumberTextScript diceScript = new DiceNumberTextScript();
	// Use this for initialization
	void Start () {
        diceValue = diceScript.GetDiceTotal();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
