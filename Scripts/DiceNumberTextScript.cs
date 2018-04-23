using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceNumberTextScript : MonoBehaviour {

	Text text;
	public static int diceNumber1;
    public static int diceNumber2;
    public int diceTotal = 0;
    public bool isStopped = false;
    DiceCheckZoneScript1 checkRolled1;
    DiceCheckZoneScript2 checkRolled2;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
        if (isStopped == false && checkRolled1.GetDiceRolled1() == false && checkRolled2.GetDiceRolled2() == false)
        {
            diceTotal = 0;
            diceTotal = diceNumber1 + diceNumber2;
            text.text = diceTotal.ToString();
            DiceRolled();
            checkRolled1.SetNotClickedRoll1();
            checkRolled2.SetNotClickedRoll2();
        }
    }

    public int GetDice1()
    {
        return diceNumber1;
    }

    public int GetDice2()
    {
        return diceNumber2;
    }

    public int GetDiceTotal()
    {
        return diceTotal;
    }

    public void DiceRolled()
    {
        isStopped = true;
    }

    public void DiceReadyToBeRolled()
    {
        isStopped = false;
    }
}
