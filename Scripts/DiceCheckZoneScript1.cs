using UnityEngine;
using UnityEngine.UI;

// Class for checking and updating the value of dice1
public class DiceCheckZoneScript1 : MonoBehaviour
{
    public Sprite[] DiceImage1;
    public bool startRolling1;          // dice1 is rolled once?
    public bool diceOnBoard1;           // dice1 is being rolled or landing on board?

    Vector3 diceVelocity;
    
    private void Start()
    {
        startRolling1 = false;          // no one should have rolled dice1 before the game starts
    }

    // Update is called once per frame
    void Update()
    {
		diceVelocity = DiceScript1.diceVelocity;
	}

    // Check the side and update the value of dice1
    // Dice1 has value only if someone rolls it
    // Value of dice1 will only be checked and updated when it perfectly lands on the board
	void OnTriggerStay(Collider col)
	{
        diceOnBoard1 = false;       // the dice1 should be on air when it is being rolled
        if (startRolling1 == true)
        {
            if (diceVelocity.x == 0f && diceVelocity.y == 0f && diceVelocity.z == 0f)
            {
                switch (col.gameObject.name)
                {
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
                diceOnBoard1 = true;        // confirm dice1 is on board after rolling
            }
        }      
	}
}
