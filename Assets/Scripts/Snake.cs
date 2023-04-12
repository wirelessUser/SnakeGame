using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum SnakeState
{
    Alive,Dead,Win,Loose
}

public enum SnakeId
{
    Snake1, Snake2
}

public enum Moving
{
    Up,Down,Left,Right
}
public class Snake : MonoBehaviour
{
    private Vector2 gridMoveDirection;  // where the snak eis moving
    private Vector2 gridPosition;
    private float gridMoveTimer;
    private float gridfMoveTimerMax = 1f; // contain the amount of time between moves



    public GameObject foodref1;
    public GameObject foodref2;
    public GameObject PowerUP;
    public int snakeBodySize;
    public List<Vector2> snakeMovementPositionList;

    public List<Transform> snakeBodyTransformList;

    public SnakeState state;

    public GameObject snakeBodyObject;


    public GameObject OtherSnake;

    int bodyCount=0;

    public bool Boosted;
    public int boostedSpeed=1;
    
    // Food Obejct passing.......

    public SnakeId CurrentSnakeId;

    public Moving snakeMOve;
    public float movingBoostedTimer;

    public Vector2 BoundryLImitLeftDown= new Vector2(0.5f,0.5f);
    public Vector2 BoundryUpRight = new Vector2(9.5f,17.5f);
    private void Awake()
    {

        //Gamemanager.instance.GoodFoodPrefab = foodref1;
        //Gamemanager.instance.BadFoodPrefab = foodref2;
        //  Debug.Log("Awake called from ==" + this.gameObject.name);
        //foodref1 = GameObject.Find("Good Food 1(Clone)");
        //foodref2 = GameObject.Find("Bad Food 1(Clone)");

        // Previously refernce was taken awake but snake swas intanited in Awake in the GamManager  , So i think refrnece wa snot
        // able to assign to the sankes to runtime also 
        // the prefabs hwne isnatnting they have name folowed by (Clne) so that;s why to get the Componet we need to wirte their clone with their name
        // while finding the obejct with name.

        // Also an erro is coming as"error the prefab destroyed but you are still trying to acces it-".. so in sake we need to werite if food prefab !=null
    }

    private void Start()
    {
        foodref1 = GameObject.Find("Good Food 1(Clone)");
        foodref2 = GameObject.Find("Bad Food 1(Clone)");
        PowerUP = GameObject.Find("PowerUp(Clone)");
        state = SnakeState.Alive;

        if (this.gameObject.CompareTag("Player1"))
        {
            gridPosition = new Vector2(0.5f, 0.5f);
        }
        else if (this.gameObject.CompareTag("Player2"))
        {
            gridPosition = new Vector2(17.5f, 0.5f);
        }

        gridfMoveTimerMax = 1f;
        gridMoveTimer = gridfMoveTimerMax;

        gridMoveDirection = new Vector2(0, 1);

        snakeMovementPositionList = new List<Vector2>();
        snakeBodyTransformList = new List<Transform>();
    }



    private void Update()
    {
        if (state == SnakeState.Alive )
        {
            TakingInput();
            HandlegridMovemet();
        }
        else
        {
            UiManager.instance.loosePanel.SetActive(true);
        }

        MatchPositionsWith();


        if (Boosted)
        {
            boostedSpeed = 4;
          //  Debug.Log(" Hey" + this.gameObject.name + " " + "You are boosted" + "Now your speed is " + boostedSpeed);
            movingBoostedTimer += Time.deltaTime;
            if (movingBoostedTimer>=55)
            {
               
                Boosted = false;
                boostedSpeed = 1;
             //   Debug.Log(" Hey" + this.gameObject.name + " " + "Cooldown From Power Up" + "Now your speed is " + boostedSpeed);
                movingBoostedTimer = 0;
            }
        }



        //...............Checking Boundry Limts ....................
         //public Vector2 BoundryLImitLeftDown = new Vector2(0.5f, 0.5f);
   // public Vector2 BoundryUpRight = new Vector2(9.5f, 17.5f);
        if (this.transform.position.x <BoundryLImitLeftDown.x || this.transform.position.x>BoundryUpRight.y || this.transform.position.y< BoundryLImitLeftDown.x || this.transform.position.y>BoundryUpRight.x)
        {
            if (CurrentSnakeId==SnakeId.Snake1)
            {
                state = SnakeState.Dead;
            }
            if (CurrentSnakeId == SnakeId.Snake2)
            {
                state = SnakeState.Dead;
            }
        }

    }

    private void HandlegridMovemet()
    {
        gridMoveTimer += Time.deltaTime * (boostedSpeed);
        if (gridMoveTimer >= gridfMoveTimerMax)
        {
            snakeMovementPositionList.Insert(0, gridPosition);
            gridMoveTimer -= gridfMoveTimerMax;

          


            gridPosition += gridMoveDirection ;

        }


        //...........Boosted.......

        //if (Boosted/*&&this.CurrentSnakeId==SnakeId.Snake1*/)
        //{
        //    switch (snakeMOve)
        //    {
        //        case Moving.Up:
        //            gridMoveDirection = new Vector2(0, boostedSpeed);
        //            break;
        //        case Moving.Down:
        //            gridMoveDirection =   new Vector2(0, -boostedSpeed);
        //            break;
        //        case Moving.Left:
        //            gridMoveDirection =   new Vector2(-boostedSpeed,0 );
        //            break;
        //        case Moving.Right:
        //            gridMoveDirection =   new Vector2(boostedSpeed,0 );
        //            break;
             
        //    }
            
        //}

        //if (!Boosted && this.CurrentSnakeId == SnakeId.Snake2)
        //{

        //}




        this.transform.position = new Vector3(gridPosition.x, gridPosition.y);

        if (foodref1!=null &&foodref2!=null && PowerUP!=null)
        {
            bool snakeAteFood1 = foodref1.GetComponent<Foodgen>().TrySnakeEatFood(this.transform.position);
            bool snakeAteFood2 = foodref2.GetComponent<Foodgen>().TrySnakeEatFood(this.transform.position);
            bool Power = PowerUP.GetComponent<Foodgen>().TrySnakeEatFood(this.transform.position);


            if (Power)
            {
                if (CurrentSnakeId == SnakeId.Snake1)
                {
                    Boosted = true;
                    UiManager.instance.scoreSnake1 += 5;
                    UiManager.instance.Boost(this.gameObject);
                    UiManager.instance.boostSnake[0] = true;
                }
                if (CurrentSnakeId == SnakeId.Snake2)
                {
                    Boosted = true;
                    UiManager.instance.boostSnake[0] = true;
                    UiManager.instance.scoreSnake2 += 5;
                    UiManager.instance.Boost(this.gameObject);
                }
            }
                //   Debug.Log("retun value boolean =="+ snakeAteFood1+" "+this.name);
                //Debug.Log("retun value boolean ==" + snakeAteFood2 + " " + this.name);
      if (snakeAteFood1)
        {
                if (CurrentSnakeId== SnakeId.Snake1)
                {
                    Debug.Log("Snake 1 Ate *GoodFood* grow Body");
                    snakeBodySize+=1;
                    // Debug.Log("Size from Foodref_1snakeBodySize>>" + snakeBodySize);
                    CreatingSnakeBody();
                    UiManager.instance.scoreSnake1 += 1;
                    if (UiManager.instance.scoreSnake1 == 20)
                    {
                        state = SnakeState.Win;
                        UiManager.instance.WinPanel.gameObject.SetActive(true);

                    }
                }
                if (CurrentSnakeId == SnakeId.Snake2)
                {
                    Debug.Log("Snake 2 Ate *GoodFood* grow Body");
                    snakeBodySize++;
                   
                    CreatingSnakeBody();

                    UiManager.instance.scoreSnake2 += 1;
                    if (UiManager.instance.scoreSnake2 == 20)
                    {
                        state = SnakeState.Win;
                        UiManager.instance.WinPanel.gameObject.SetActive(true);

                    }
                }


            }
       else  if (snakeAteFood2)
        {

               // foodref2 = GameObject.Find("Bad Food 1(Clone)");
                Debug.Log("Snake Ate *BadFood* remove Body");
                if (CurrentSnakeId == SnakeId.Snake1)
                {
                   // snakeBodySize--;
                    RemovingSnakeBody();
                    // Debug.Log("Size from Bad Food>>" + snakeBodySize);
                    UiManager.instance.scoreSnake1 -= 1;
                    if (UiManager.instance.scoreSnake1 < 0)
                    {
                        // state = SnakeState.Loose;
                        UiManager.instance.loosePanel.gameObject.SetActive(true);
                        UiManager.instance.scoreSnake1 = 0;
                    }
                    

                }
                if (CurrentSnakeId == SnakeId.Snake2)
                {
                    RemovingSnakeBody();
                    // Debug.Log("Size from Bad Food>>" + snakeBodySize);
                    UiManager.instance.scoreSnake1 -= 1;
                    if (UiManager.instance.scoreSnake1 < 0)
                    {
                        // state = SnakeState.Loose;
                        UiManager.instance.loosePanel.gameObject.SetActive(true);
                        UiManager.instance.scoreSnake1 = 0;
                    }
                   

                }
            }// edn else....

        }


        for (int i = 0; i < snakeBodyTransformList.Count; i++)
        {
            Vector3 snakeBodyPosition = new Vector3(snakeMovementPositionList[i].x, snakeMovementPositionList[i].y);
            snakeBodyTransformList[i].position = snakeBodyPosition;

        }
       

        foreach (Transform snakeBodypartsTransfrom in snakeBodyTransformList)
        {
            Vector2 snakeBodyPartsgridPosition = snakeBodypartsTransfrom.position;
          //  Debug.Log("snakeBodyPartsgridPosition>>" + snakeBodyPartsgridPosition);
            if (gridPosition == snakeBodyPartsgridPosition)
            {
               //    Debug.Log("gameOver");
                //state = SnakeState.Dead;
            }
        }
    }

    private void RemovingSnakeBody()
    {
       // Debug.Log("Insdie remoe sanke body fucntion>>");
        //int lastIndex = snakeBodyTransformList.Count - 1; // moving that line isndie 
        if (snakeBodySize >= 0 /*|| snakeBodySize <= 0*/ )
        {
            
                snakeBodySize--;
            if (snakeBodySize < 0)
            {
                snakeBodySize = 0;
                state = SnakeState.Dead;
                return;
            }
            int lastIndex = snakeBodyTransformList.Count - 1;
            Debug.Log("Last idnex removing body>>" + lastIndex);
            Transform lastBodyPart = snakeBodyTransformList[lastIndex];
            snakeBodyTransformList.RemoveAt(lastIndex);
            DestroyImmediate(lastBodyPart.gameObject);

            
        }
        //else if (snakeBodySize == 0)
        //{
           
            
        //        state = SnakeState.Dead;
            
        //    snakeBodySize = 0;
        //    //  Debug.Log("Else Situation Size is set to zero>> ");
        //}

    }


    private void CreatingSnakeBody()
    {
        bodyCount++;
        snakeBodyObject = new GameObject("SnakeBody" + bodyCount, typeof(SpriteRenderer));
        snakeBodyObject.transform.localScale = new Vector3(0.8f, 0.8f, 0);
        if (CurrentSnakeId== SnakeId.Snake1)
        {
            snakeBodyObject.GetComponent<SpriteRenderer>().sprite = SpriteRefer.instance.snakeBodySprite1;
        }
        else if (CurrentSnakeId == SnakeId.Snake2)
        {
            snakeBodyObject.GetComponent<SpriteRenderer>().sprite = SpriteRefer.instance.snakeBodySprite2;
        }
        snakeBodyObject.GetComponent<SpriteRenderer>().sortingLayerName = "Player";

        snakeBodyObject.GetComponent<SpriteRenderer>().sortingOrder = 4;
        snakeBodyObject.transform.position = snakeMovementPositionList[1];
        snakeBodyTransformList.Add(snakeBodyObject.transform);


       
    }

    #region
    //private void CreatingSnakeBody()
    //{
    //    snakeBodyObject = new GameObject("SnakeBody", typeof(SpriteRenderer));
    //    snakeBodyObject.GetComponent<SpriteRenderer>().sprite = SpriteRefer.instance.snakeBodySprite;
    //    snakeBodyTransformList.Add(snakeBodyObject.transform); // why wrote that fucntion?
    //    snakeBodyObject.GetComponent<SpriteRenderer>().sortingLayerName = "Player";
    //    snakeBodyObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
    //    snakeBodyObject.GetComponent<SpriteRenderer>().sortingOrder = -snakeBodyTransformList.Count; // added sorting ordrr tothe body parts

    //    for (int i = 0; i < snakeBodyTransformList.Count; i++)
    //    {
    //        Debug.Log("snakeBodyTransformList[i]>> " + snakeBodyTransformList[i]);
    //    }
    //}

    #endregion
    public void TakingInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && gameObject.CompareTag("Player1") ||(Input.GetKeyDown(KeyCode.W) && gameObject.CompareTag("Player2")) )
        {
           
                // gridPos.y += 10;
                if (gridMoveDirection.y != -1)
                {
                snakeMOve = Moving.Up;
                gridMoveDirection = new Vector2(0, 1);
                

                }

            this.transform.eulerAngles = new Vector3(0, 0, gridMoveDirection.x );
        }
        


        if (Input.GetKeyDown(KeyCode.DownArrow) && gameObject.CompareTag("Player1") || (Input.GetKeyDown(KeyCode.S) && gameObject.CompareTag("Player2")))
        {
            if (gridMoveDirection.y != 1)
                {
                snakeMOve = Moving.Down;
                    gridMoveDirection = new Vector2(0, -1);
                    this.transform.eulerAngles = new Vector3(0, 0, gridMoveDirection.y * 180);
                }
           
        }
       
       
        if (Input.GetKeyDown(KeyCode.LeftArrow) && gameObject.CompareTag("Player1") || (Input.GetKeyDown(KeyCode.A) && gameObject.CompareTag("Player2")))
        {
           
                if (gridMoveDirection.x != 1)
                {
                snakeMOve = Moving.Left;
                gridMoveDirection = new Vector2(-1, 0);
                    this.transform.eulerAngles = new Vector3(0, 0, -gridMoveDirection.x * 90);
                }
            
        }


        if (Input.GetKeyDown(KeyCode.RightArrow) && gameObject.CompareTag("Player1") || (Input.GetKeyDown(KeyCode.D) && gameObject.CompareTag("Player2")))
        {
            if (gridMoveDirection.x != -1)
            {
                snakeMOve = Moving.Right;
                gridMoveDirection = new Vector2(1, 0);
                this.transform.eulerAngles = new Vector3(0, 0, -gridMoveDirection.x * 90);
            }

        }





    }// Taking Input bracket





    private float GetAngleFromVector(Vector2 dir)
    {
        float angle = Mathf.Atan(dir.y / dir.x) * Mathf.Rad2Deg;

        if (angle < 0) angle += 360;
        return angle;
    }




    public Vector2 ReturnSnakePos()
    {
        return this.transform.position;
    }



    public List<Vector2> ReturningListOfAllSnakeBodyParts()
    {
        List<Vector2> gridPositionList = new List<Vector2>() {  };
        gridPositionList.AddRange(snakeMovementPositionList);
        return gridPositionList;
    }


    public void MatchPositionsWith()
    {

       // Debug.Log("Above Misatm,atcjh checking " + this.gameObject.name);
      //  Debug.Log("from current snake id snake  " + CurrentSnakeId);
        if (this.transform.position == OtherSnake.transform.position)
        {
          //  Debug.Log("this Pos == " + transform.position + "Other Snake Pos==" + OtherSnake.transform.position + "Name==" + this.gameObject.name);
            state = SnakeState.Loose;
            OtherSnake.transform.GetComponent<Snake>().state = SnakeState.Loose;
          // Debug.Log("State==" + state + this.gameObject.name);
        }

        if (CurrentSnakeId == SnakeId.Snake1)

        {
           // Debug.Log("Above Misatm,atcjh checking " + this.gameObject.name);
           // Debug.Log("from current snake id snake  " + CurrentSnakeId);
            int count1 = OtherSnake.GetComponent<Snake>().snakeBodyTransformList.Count;
            // int count1 = Mathf.Min(snakeBodyTransformList.Count > OtherSnake.GetComponent<Snake>().snakeBodyTransformList.Count ? snakeBodyTransformList.Count : OtherSnake.GetComponent<Snake>().snakeBodyTransformList.Count);
            for (int i = 0; i < count1; i++)
            {
               // Debug.Log("Count from snake 1 >>" + count1);
                // Debug.Log("Isnide Misatm,atcjh checking " + this.gameObject.name);
                if (this.transform.position == OtherSnake.GetComponent<Snake>().snakeBodyTransformList[i].position)
                {
                //    Debug.Log("Position mismatch at index " + i + this.gameObject.name);
                    state = SnakeState.Loose;
                    OtherSnake.GetComponent<Snake>().state = SnakeState.Win;
                   // Debug.Log("i loose note my name == " + this.gameObject.name);

                }
            }


        }

            if (CurrentSnakeId == SnakeId.Snake2)

            {
               // Debug.Log("from current snake id snake  " + SnakeId.Snake2);
           // Debug.Log("from current snake id snake  " + CurrentSnakeId);
            int count2 = OtherSnake.GetComponent<Snake>().snakeBodyTransformList.Count;
                for (int i = 0; i < count2; i++)
                {
               //    Debug.Log("Count from snake 2 >>" + count2);
                    //Debug.Log("Isnide Misatm,atcjh checking " + this.gameObject.name);
                    if (this.transform.position == OtherSnake.GetComponent<Snake>().snakeBodyTransformList[i].position)
                    {
                     //   Debug.Log("Position mismatch at index " + i + this.gameObject.name);
                        state = SnakeState.Loose;
                       // Debug.Log("i loose note my name == " + this.gameObject.name);
                        OtherSnake.GetComponent<Snake>().state = SnakeState.Win;
                    }
                }


         }


        

    }// Match position.............

}


//int count = Mathf.Min(snakeBodyTransformList.Count > OtherSnake.GetComponent<Snake>().snakeBodyTransformList.Count ? snakeBodyTransformList.Count : OtherSnake.GetComponent<Snake>().snakeBodyTransformList.Count);
//for (int i = 0; i < count; i++)
//{
//    Debug.Log("Count >>" + count);
//    Debug.Log("Isnide Misatm,atcjh checking " + this.gameObject.name);
//    if (snakeBodyTransformList[i].position == OtherSnake.GetComponent<Snake>().snakeBodyTransformList[i].position)
//    {
//        Debug.Log("Position mismatch at index " + i + this.gameObject.name);
//        state = SnakeState.Loose;
//    }