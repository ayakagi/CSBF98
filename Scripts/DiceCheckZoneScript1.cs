using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceCheckZoneScript1 : MonoBehaviour {

	Vector3 diceVelocity;
    bool dice1Rolled = false;
    public Sprite[] DiceImage1;


    // Update is called once per frame
    void FixedUpdate () {
		diceVelocity = DiceScript1.diceVelocity;
	}

	void OnTriggerStay(Collider col)
	{
        if (diceVelocity.x == 0f && diceVelocity.y == 0f && diceVelocity.z == 0f)
		{
			switch (col.gameObject.name) {
			case "Side1.1":
                DiceNumberTextScript.diceNumber1 = 6;
                GameObject.Find("DiceIcon1").GetComponent<Image>().sprite = DiceImage1[5];
                    break;
			case "Side1.2":
				DiceNumberTextScript.diceNumber1 = 5;
                GameObject.Find("DiceIcon1").GetComponent<Image>().sprite = DiceImage1[4];
                    break;
			case "Side1.3":
				DiceNumberTextScript.diceNumber1 = 4;
                GameObject.Find("DiceIcon1").GetComponent<Image>().sprite = DiceImage1[3];
                    break;
			case "Side1.4":
				DiceNumberTextScript.diceNumber1 = 3;
                GameObject.Find("DiceIcon1").GetComponent<Image>().sprite = DiceImage1[2];
                    break;
			case "Side1.5":
				DiceNumberTextScript.diceNumber1 = 2;
                GameObject.Find("DiceIcon1").GetComponent<Image>().sprite = DiceImage1[1];
                    break;
			case "Side1.6":
				DiceNumberTextScript.diceNumber1 = 1;
                GameObject.Find("DiceIcon1").GetComponent<Image>().sprite = DiceImage1[0];
                    break;
			}
		}
        SetClickedRoll1();
	}

    public void SetClickedRoll1()
    {
        dice1Rolled = true;
    }

    public void SetNotClickedRoll1()
    {
        dice1Rolled = false;
    }

    public bool GetDiceRolled1()
    {
        return dice1Rolled;
    }
}
