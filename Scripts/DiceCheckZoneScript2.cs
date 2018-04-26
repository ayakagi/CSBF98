using UnityEngine;
using UnityEngine.UI;

// Class for checking and updating the value of dice 2
public class DiceCheckZoneScript2 : MonoBehaviour
{
    public Sprite[] DiceImage2;
    public bool startRolling2;          // dice2 is rolled once?
    public bool diceOnBoard2;           // dice2 is being rolled or landing on board?

    Vector3 diceVelocity;

    private void Start()
    {
        startRolling2 = false;          // no one should have rolled dice2 before the game starts
    }

    // Update is called once per frame
    void Update()
    {
        diceVelocity = DiceScript2.diceVelocity;
    }

    // Check the side and update the value of dice2
    // Dice2 has value only if someone rolls it
    // Value of dice2 will only be checked and updated when it perfectly lands on the board
    void OnTriggerStay(Collider col)
    {
        diceOnBoard2 = false;       // the dice2 should be on air when it is being rolled

        if (startRolling2 == true)
        {
            if (diceVelocity.x == 0f && diceVelocity.y == 0f && diceVelocity.z == 0f)
            {
                switch (col.gameObject.name)
                {
                    case "Side2.1":
                        DiceNumberTextScript.diceNumber2 = 6;
                        GameObject.Find("DiceIcon2").GetComponent<Image>().sprite = DiceImage2[5];
                        break;
                    case "Side2.2":
                        DiceNumberTextScript.diceNumber2 = 5;
                        GameObject.Find("DiceIcon2").GetComponent<Image>().sprite = DiceImage2[4];
                        break;
                    case "Side2.3":
                        DiceNumberTextScript.diceNumber2 = 4;
                        GameObject.Find("DiceIcon2").GetComponent<Image>().sprite = DiceImage2[3];
                        break;
                    case "Side2.4":
                        DiceNumberTextScript.diceNumber2 = 3;
                        GameObject.Find("DiceIcon2").GetComponent<Image>().sprite = DiceImage2[2];
                        break;
                    case "Side2.5":
                        DiceNumberTextScript.diceNumber2 = 2;
                        GameObject.Find("DiceIcon2").GetComponent<Image>().sprite = DiceImage2[1];
                        break;
                    case "Side2.6":
                        DiceNumberTextScript.diceNumber2 = 1;
                        GameObject.Find("DiceIcon2").GetComponent<Image>().sprite = DiceImage2[0];
                        break;
                }
                diceOnBoard2 = true;        // confirm dice2 is on board after rolling
            }
        }
    }
}
