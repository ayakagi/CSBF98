using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DiceNumberTextScript : MonoBehaviour
{
    public static int diceNumber1;
    public static int diceNumber2;
    public int diceTotal;
    Text diceValueDisplay;
    DiceCheckZoneScript1 diceCheck1;
    DiceCheckZoneScript2 diceCheck2;
    CamEvent camEv;
    Player playerToken;

    private void LateUpdate()
    {
        if (diceTotal != 0)
        {
            playerToken.PlayerMovement();
            playerToken.TeleportToJail();
            playerToken.IncomeTax();
            playerToken.SuperTax();
            switchBackToMainCam();
            // finished moving token, change the boolean for next rolling
            playerToken.isDoneRolling1 = false;
            playerToken.isDoneRolling2 = false;

        }

    }

    void switchBackToMainCam()
    {
        if (playerToken.isDoneRolling1 == true && playerToken.isDoneRolling2 == true)
        {
            camEv.camMain();
        }
    }

    // Use this for initialization
    void Start()
    {
        diceValueDisplay = GetComponent<Text>();
        diceCheck1 = GameObject.FindObjectOfType<DiceCheckZoneScript1>();
        diceCheck2 = GameObject.FindObjectOfType<DiceCheckZoneScript2>();
        //diceScript1 = GameObject.FindObjectOfType<DiceScript1>();
        camEv = GameObject.FindObjectOfType<CamEvent>();
        playerToken = GameObject.FindObjectOfType<Player>();
        diceValueDisplay.text = "?";
        diceTotal = 0;
    }

    // Update is called once per frame
    void Update()
    {
        diceValueDisplay.text = "?";
        if (diceCheck1.diceOnBoard1 == true && diceCheck1.startRolling1 == true &&
            diceCheck2.diceOnBoard2 == true && diceCheck2.startRolling2 == true)
        {
            diceTotal = 0;
            diceTotal = diceNumber1 + diceNumber2;
            diceValueDisplay.text = diceTotal.ToString();
            
            
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

}
