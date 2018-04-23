using UnityEngine;

public class Player : MonoBehaviour
{
    public Tile StartPosition;
    public bool isDoneRolling1;
    public bool isDoneRolling2;
    public bool canReroll;
    private int totalMove;
    private int moveTimeCount;
    
    Tile CurrentPosition;
    Tile FinalPosition;
    DiceNumberTextScript player_dice;     

    // Use this for initialization
    void Start()
    {
        player_dice = GameObject.FindObjectOfType<DiceNumberTextScript>();
        CurrentPosition = StartPosition;
        isDoneRolling1 = false;
        isDoneRolling2 = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player_dice.GetDiceTotal() != 0)
            PlayerMovement();
    }

    public void PlayerMovement()
    {
        if (isDoneRolling1 == true && isDoneRolling2 == true)
        {
            totalMove = player_dice.GetDiceTotal();
            if (totalMove != 0)
            {
                FinalPosition = CurrentPosition;
                // move token
                for (int m = 0; m < totalMove; m++)
                {
                    FinalPosition = FinalPosition.GoNextTile[0];
                }
                // teleport the token
                this.transform.position = FinalPosition.transform.position;
                CurrentPosition = FinalPosition;
                // finished moving token, change the boolean for next rolling
                isDoneRolling1 = false;
                isDoneRolling2 = false;
            }
        }
        
    }
}
