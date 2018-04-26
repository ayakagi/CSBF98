using UnityEngine;
using UnityEngine.UI;

// Class for calculating and updating the dice value
// Moving the player tokens
public class DiceNumberTextScript : MonoBehaviour
{
    public static int diceNumber1;      // value of dice1
    public static int diceNumber2;      // value of dice2
    public bool rolledDb;               // rolled same value of dice1&2?
    public GameTile jail;                  
    private int diceTotal;              // total value of dice1&2

    Text diceValueDisplay;
    DiceCheckZoneScript1 diceCheck1;
    DiceCheckZoneScript2 diceCheck2;
    CamEvent camEv;
    Player playerToken1;
    Player playerToken2;
    Action action;
    Counter c;   

    // Use this for initialization
    void Start()
    {
        c = GameObject.FindObjectOfType<Counter>();
        diceValueDisplay = GetComponent<Text>();
        diceCheck1 = GameObject.FindObjectOfType<DiceCheckZoneScript1>();
        diceCheck2 = GameObject.FindObjectOfType<DiceCheckZoneScript2>();
        camEv = GameObject.FindObjectOfType<CamEvent>();
        playerToken1 = GameObject.FindWithTag("Player1").GetComponent<Player>();
        playerToken2 = GameObject.FindWithTag("Player2").GetComponent<Player>();
        action = GameObject.FindObjectOfType<Action>();
        diceValueDisplay.text = "?";
        diceTotal = 0;
        playerToken1.count = 0;
    }

    // Update is called once per frame
    // Show the total value of dice1&2 if player rolls the dice and both dice land on board
    // Move the player token if it is its turn
    void Update()
    {
        diceValueDisplay.text = "?";        // hide the total value of dice1&2 before player rolls it

        if (diceCheck1.diceOnBoard1 == true && diceCheck1.startRolling1 == true &&
            diceCheck2.diceOnBoard2 == true && diceCheck2.startRolling2 == true)
        {
            diceTotal = 0;
            diceTotal = diceNumber1 + diceNumber2;
            diceValueDisplay.text = diceTotal.ToString();
        }
        if (diceTotal != 0)
        {
            if (playerToken1.count == 0)
            {
                RunPlayer1();
            }
            else if (playerToken2.count == 0)
            {
                RunPlayer2();
            }
        }
    }

    // Return true if player roll the same value of dice1&2, else false
    public bool RolledDouble()
    {
        rolledDb = false;
        if (diceNumber1 == diceNumber2)
        {
            rolledDb = true;
        }
        return rolledDb;
    }

    // Get the value of dice1
    public int GetDice1()
    {
        return diceNumber1;
    }

    // Get the value of dice2
    public int GetDice2()
    {
        return diceNumber2;
    }

    // Get the total value of dice1&2
    public int GetDiceTotal()
    {
        return diceTotal;
    }

    // Set the total value of dice1&2
    public void SetDiceTotal(int diceValue)
    {
        diceTotal = diceValue;
    }

    // Movement of player 1
    // Player 1 will move to jail if it rolls 3 times double value
    // After player 1 rolls the dice, action bar will pop up
    // If Player 1 choose to end its turn, next player will be able to roll the dice
    public void RunPlayer1()
    {
        if (RolledDouble() == true && c.doubleCounter == 2)
        {
            playerToken1.TeleportToJail();
            c.doubleCounter = 0;
        }
        else
        {
            if (RolledDouble() == false)
            {
                c.doubleCounter = 0;

            }
            playerToken1.PlayerMovement();

        }
        if (playerToken1.CheckRollingStatus())
        {
            action.Open();
        }
        playerToken1.isDoneRolling1 = false;
        playerToken1.isDoneRolling2 = false;
    }

    // Movement of player 2, basically same as RunPlayer1()
    // Player 2 will move to jail if it rolls 3 times double value
    // After player 2 rolls the dice, action bar will pop up
    // If Player 2 choose to end its turn, next player will be able to roll the dice
    public void RunPlayer2()
    {
        if (RolledDouble() == true && c.doubleCounter == 2)
        {
            playerToken2.TeleportToJail();
            c.doubleCounter = 0;
        }
        else
        {
            if (RolledDouble() == false)
            {
                c.doubleCounter = 0;
            }
            playerToken2.PlayerMovement();
        }   
        if (playerToken2.CheckRollingStatus())
        {
            action.Open();
        }
        playerToken2.isDoneRolling1 = false;
        playerToken2.isDoneRolling2 = false;
    }
}
