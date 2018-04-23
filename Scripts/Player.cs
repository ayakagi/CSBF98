using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    //public int rollCount;
    public Tile StartPosition;
    Tile CurrentPosition;
    Tile FinalPosition;
    DiceNumberTextScript dice;

	// Use this for initialization
	void Start () {
        dice = GameObject.FindObjectOfType<DiceNumberTextScript>();
        CurrentPosition = StartPosition;
        //rollCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (dice.isStopped == true)
        {
            PlayerMovement();
        }

    }
    
    void PlayerMovement()
    {
        //do
        //{
            int move = dice.GetDiceTotal();
            FinalPosition = CurrentPosition;
            for (int m = 0; m < move; m++)
            {
                FinalPosition = FinalPosition.GoNextTile[0];
            }
            //rollCount++;
        //}
        //while (dice.getDice1() == dice.getDice2() && rollCount < 3);
        //rollCount = 0;
        this.transform.position = FinalPosition.transform.position;

        CurrentPosition = FinalPosition;
    }
}
