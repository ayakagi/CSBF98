using UnityEngine;

// Class for initializing player and player movement
public class Player : MonoBehaviour
{
    public bool isDoneRolling1;         // did player roll the dice1?
    public bool isDoneRolling2;         // did player roll the dice2?
    public bool inJail;                 // is player in jail?
    public int salary;                  // salary that player owns
    public int count;                   // determine the player's turn

    public GameTile StartPosition;
    public GameTile CurrentPosition;
    public GameTile FinalPosition;
    public GameTile freeparking;
    public GameTile jail;
    public GameTile goToJail;
    public GameTile incomeTax;
    public GameTile superTax;
    
    private int totalMove;              // the number of player's move in turn
    
    int MoveQueueIndex;                 // ***
    float SmoothTime;                   // animation speed
    DiceNumberTextScript player_dice;
    Vector3 TargetPosition;
    Vector3 Velocity;
    GameTile[] MoveQueue;    
    FreeParking fp;
    CamEvent cam;

    // Use this for initialization
    void Start()
    {
        player_dice = GameObject.FindObjectOfType<DiceNumberTextScript>();
        fp = GameObject.FindObjectOfType<FreeParking>();
        cam = GameObject.FindObjectOfType<CamEvent>();   
        TargetPosition = this.transform.position;
        CurrentPosition = StartPosition;
        isDoneRolling1 = false;
        isDoneRolling2 = false;
        salary = 1500;
        count = 1;
        MoveQueueIndex = 9999;
        float SmoothTime = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        SwitchBackCam();
        TokenAnimation();
    }

    // ***
    public void SetNewPosition(Vector3 pos)
    {
        TargetPosition = pos;
        Velocity = Vector3.zero;
          
    }

    // ***
    public void TokenAnimation()
    {
        if (this.transform.position != TargetPosition && inJail != true)
        {
            this.transform.position = Vector3.SmoothDamp(this.transform.position, TargetPosition, ref Velocity, SmoothTime);       
        }
        else
        {
            if (MoveQueue != null && MoveQueueIndex < MoveQueue.Length)
            {
                SetNewPosition(MoveQueue[MoveQueueIndex].transform.position);
                MoveQueueIndex++;
            }         
        }
    }

    // When the dice1&2 are rolled, player will move and the camera will zoom in and focus on it
    // If the player pass the "GO" tile, it can get bonus salary(£200)
    public void PlayerMovement()
    {       
        if (CheckRollingStatus())
        {
            cam.CamToken();
            totalMove = player_dice.GetDiceTotal();
            if (totalMove != 0)
            {
                MoveQueue = new GameTile[totalMove];
                FinalPosition = CurrentPosition;
                
                // move token
                for (int m = 0; m < totalMove; m++)
                {  
                    FinalPosition = FinalPosition.GoNextTile[0];
                    MoveQueue[m] = FinalPosition;
                    
                    if (m == totalMove - 1 && FinalPosition == goToJail)
                    {
                        MoveQueue[m] = jail;
                        CurrentPosition = jail;
                        FinalPosition = jail;
                        inJail = true;
                    }                   
                    // collect salary
                    if (FinalPosition == StartPosition)
                    {
                        salary += 200;
                    }
                    
                }         
                MoveQueueIndex = 0;
                CurrentPosition = FinalPosition;
            }
            IncomeTax();
            SuperTax();
            CollectFreeParking();
        }
    }

    // When player steps on "Go To Jail" tile, it will move to jail instantly
    public void TeleportToJail()
    {
        this.transform.position = jail.transform.position;
        for (int m = 0; m < MoveQueue.Length; m++) {
            MoveQueue[m] = jail;
        }
        MoveQueueIndex = 0;
        CurrentPosition = jail;
        FinalPosition = jail;
        inJail = true;
    }

    // When player steps on "Income Tax" tile, its salry will be decreased £200 instantly
    public void IncomeTax()
    {
        if (this.transform.position == incomeTax.transform.position)
        {
            salary -= 200;
        }
      
    }

    // When player steps on "Super Tax" tile, its salry will be decreased £100 instantly
    public void SuperTax()
    {
        if (this.transform.position == superTax.transform.position)
        {
            salary -= 100;
        }
 
    }

    // When player steps on "Free Parking" tile, it can get all the tax that stored in this tile
    public void CollectFreeParking()
    {

        if (this.transform.position == freeparking.transform.position)
        {
            salary += fp.GetTax();
            fp.ResetTax();
        }

    }

    // Switch back from other camera to game board camera
    public void SwitchBackCam()
    {
        if (CurrentPosition.transform.position == transform.position)
        {
            cam.CamMain();
        }
    }

    // Check if dice1&2 both finished rolling
    public bool CheckRollingStatus()
    {
        if (isDoneRolling1 == true && isDoneRolling2 == true)
            return true;
        else
            return false;
    }
}
