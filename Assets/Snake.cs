using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum SnakeState
{
    Alive,
    Dead,
   Win,
   Loose
}
public class Snake : MonoBehaviour
{
    private Vector2 gridMoveDirection;  // where the snak eis moving
    private Vector2 gridPosition;
    private float gridMoveTimer;
    private float gridfMoveTimerMax = 1f; // contain the amount of time between moves

    // differnce of initializibng the variable in the class or inside the Awake or Start

    public Foodgen foodref1;
    public Foodgen foodref2;
    public int snakeBodySize;
    public List<Vector2> snakeMovementPositionList;

    public List<Transform> snakeBodyTransformList;

    public SnakeState state;

    public GameObject snakeBodyObject;

   // public GameObject OtherSnake;
    // Food Obejct passing.......
    public void RefToOther1(Foodgen _Foodref1)
    {
        foodref1 = _Foodref1;
        Debug.Log("RefToOther1>>Called for The snake >>" + name);
    }
    public void RefToOther2(Foodgen _Foodref2)
    {
        foodref2 = _Foodref2;
        Debug.Log("RefToOther2>>Called for The snake >>" + name);
    }



    private void Start()
    {
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
        if (state == SnakeState.Alive || state == SnakeState.Win || state == SnakeState.Loose)
        {
            TakingInput();
            HandlegridMovemet();
        }

       // CheckCollison();


    }

    private void HandlegridMovemet()
    {
        gridMoveTimer += Time.deltaTime;
        if (gridMoveTimer >= gridfMoveTimerMax)
        {
            gridMoveTimer -= gridfMoveTimerMax;  
        
            snakeMovementPositionList.Insert(0, gridPosition);

            if (snakeMovementPositionList.Count >= snakeBodySize + 1)
            {
                //snakeMovementPositionList.RemoveAt(snakeMovementPositionList.Count - 1); // hwy only RemoveShowing Errro
            }
            gridPosition += gridMoveDirection; 

        }



        this.transform.position = new Vector3(gridPosition.x, gridPosition.y);
        //if (foodref1 != null && foodref2 != null)
        //{

            bool snakeAteFood1 = foodref1.TrySnakeEatFood(gridPosition);
        bool snakeAteFood2 = foodref2.TrySnakeEatFood(this.transform.position);
       
            if (snakeAteFood1)
            {

                Debug.Log("Snake Ate *GoodFood* grow Body");
                snakeBodySize++;
                Debug.Log("Size from Foodref_1snakeBodySize>>" + snakeBodySize);
                CreatingSnakeBody();
                UiManager.instance.score += 1;
                if (UiManager.instance.score == 2)
                {
                    state = SnakeState.Win;
                    UiManager.instance.WinPanel.gameObject.SetActive(true);
                }


            }

            else if (snakeAteFood2)
            {


                Debug.Log("Snake Ate *BadFood* grow Body");

                snakeBodySize--;
                Debug.Log("Size from Bad Food>>" + snakeBodySize);
                UiManager.instance.score -= 1;
                if (UiManager.instance.score < 0)
                {
                    state = SnakeState.Loose;
                    UiManager.instance.loosePanel.gameObject.SetActive(true);
                    UiManager.instance.score = 0;
                }
                RemovingSnakeBody();


            }
        //}
   


        for (int i = 0; i < snakeBodyTransformList.Count; i++)
        {
            Vector3 snakeBodyPosition = new Vector3(snakeMovementPositionList[i].x, snakeMovementPositionList[i].y);
            snakeBodyTransformList[i].position = snakeBodyPosition;

        }


        foreach (Transform snakeBodypartsTransfrom in snakeBodyTransformList)
        {
            Vector2 snakeBodyPartsgridPosition = snakeBodypartsTransfrom.position;

            if (gridPosition==snakeBodyPartsgridPosition)
            {
                Debug.Log("gameOver");
                state = SnakeState.Dead;
            }
        }
    }

    private void RemovingSnakeBody()
    {
       
        int lastIndex = snakeBodyTransformList.Count - 1;
        if (snakeBodySize != 0 || lastIndex!=0)
        {
            Transform lastBodyPart = snakeBodyTransformList[lastIndex];
            snakeBodyTransformList.RemoveAt(lastIndex);
            Destroy(lastBodyPart.gameObject);
        }
        else
        {
            snakeBodySize = 0;
            Debug.Log("Else Situation Size is set to zero>> " );
        }
        
    }



    private void CreatingSnakeBody()
    {
         snakeBodyObject = new GameObject("SnakeBody", typeof(SpriteRenderer));
        snakeBodyObject.GetComponent<SpriteRenderer>().sprite = SpriteRefer.instance.snakeBodySprite;
        snakeBodyTransformList.Add(snakeBodyObject.transform); // why wrote that fucntion?
        snakeBodyObject.GetComponent<SpriteRenderer>().sortingLayerName = "Player";
        snakeBodyObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
        snakeBodyObject.GetComponent<SpriteRenderer>().sortingOrder = -snakeBodyTransformList.Count; // added sorting ordrr tothe body parts

        for (int i = 0; i < snakeBodyTransformList.Count; i++)
        {
           Debug.Log("snakeBodyTransformList[i]>> "+snakeBodyTransformList[i]);
        }
    }
    public void TakingInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && gameObject.CompareTag("Player1") ||(Input.GetKeyDown(KeyCode.W) && gameObject.CompareTag("Player2")) )
        {
           
                // gridPos.y += 10;
                if (gridMoveDirection.y != -1)
                {
                    gridMoveDirection = new Vector2(0, 1);

                }

            this.transform.eulerAngles = new Vector3(0, 0, gridMoveDirection.x );
        }
        


        if (Input.GetKeyDown(KeyCode.DownArrow) && gameObject.CompareTag("Player1") || (Input.GetKeyDown(KeyCode.S) && gameObject.CompareTag("Player2")))
        {
            if (gridMoveDirection.y != 1)
                {
                    gridMoveDirection = new Vector2(0, -1);
                    this.transform.eulerAngles = new Vector3(0, 0, gridMoveDirection.y * 180);
                }
           
        }
       
       
        if (Input.GetKeyDown(KeyCode.LeftArrow) && gameObject.CompareTag("Player1") || (Input.GetKeyDown(KeyCode.A) && gameObject.CompareTag("Player2")))
        {
           
                if (gridMoveDirection.x != 1)
                {
                    gridMoveDirection = new Vector2(-1, 0);
                    this.transform.eulerAngles = new Vector3(0, 0, -gridMoveDirection.x * 90);
                }
            
        }


        if (Input.GetKeyDown(KeyCode.RightArrow) && gameObject.CompareTag("Player1") || (Input.GetKeyDown(KeyCode.D) && gameObject.CompareTag("Player2")))
        {
            if (gridMoveDirection.x != -1)
            {
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
        List<Vector2> gridPositionList = new List<Vector2>() { gridPosition };
        gridPositionList.AddRange(snakeMovementPositionList);
        return gridPositionList;
    }




   
       

   
}
