using UnityEngine;

// Class for the number of times that player has rolled the dice in turn
public class Counter : MonoBehaviour {
    public int doubleCounter;       // times of rolling same value of dice1&2

    Player player1;
    Player player2;
    DiceNumberTextScript diceText;
    FollowTokens ft;      

	// Use this for initialization
	void Start () {
        doubleCounter = 0;
        player1 = GameObject.FindWithTag("Player1").GetComponent<Player>();
        player2 = GameObject.FindWithTag("Player2").GetComponent<Player>();
        diceText = GameObject.FindObjectOfType<DiceNumberTextScript>();
        ft = GameObject.FindObjectOfType<FollowTokens>();       
    }

    // Run when player hit the "Run the Dice" button
    // If player rolls the same value of dice1&2,
    // increase the value of doubleCounter and roll the dice again 
    // Else switch to next player
    public void OnClick() {
        diceText.enabled = false;
        diceText.SetDiceTotal(0);
        if (player1.count == 0)
        {
            if (diceText.RolledDouble() == true)
            {
                // player 1's turn will be skipped when it's in jail
                if (player1.inJail == true)
                {
                    player1.count = 1;
                    player2.count = 0;
                }
                else
                {
                    doubleCounter++;
                    player1.count = 0;
                    player2.count = 1;
                } 
            }
            else
            {
                doubleCounter = 0;
                player1.count = 1;
                player2.count = 0;
            }
            
        }
        else if (player2.count == 0)
        {
            if (diceText.RolledDouble() == true)
            {
                // player 2's turn will be skipped when it's in jail
                if (player2.inJail == true)
                {
                    player2.count = 1;
                    player1.count = 0;
                }
                else
                {
                    doubleCounter++;
                    player2.count = 0;
                    player1.count = 1;
                }
            }
            else
            {
                doubleCounter = 0;
                player2.count = 1;
                player1.count = 0;
            }
        }
    }
}
