using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Snake : MonoBehaviour
{
    public Vector2 gridMoveDirection;  
    public Vector2 gridPosition;
    public float gridMoveTimer;
    public float gridfMoveTimerMax = 1f; 



    public GameObject foodref1;
    public GameObject foodref2;
    public GameObject PowerUP;
    public int snakeBodySize;
    public List<Vector2> snakeMovementPositionList;

    public List<Transform> snakeBodyTransformList;

    public SnakeState state;

    public SnakeId CurrentSnakeId;
    public GameObject snakeBodyObject;


   

    int bodyCount=0;

    public bool Boosted;
    public int boostedSpeed=1;
    
    // Food Obejct passing.......


    public Moving snakeMOve;
    public float movingBoostedTimer;

    public Vector2 BoundryLImitLeftDown= new Vector2(0.5f,0.5f);
    public Vector2 BoundryUpRight = new Vector2(9.5f,17.5f);
   

      void Start()
    {
        foodref1 = GameObject.Find("Good Food 1(Clone)");
        foodref2 = GameObject.Find("Bad Food 1(Clone)");
        PowerUP = GameObject.Find("PowerUp(Clone)");
        state = SnakeState.Alive;

        if (CurrentSnakeId ==  SnakeId.Snake1)
        {
            gridPosition = new Vector2(0.5f, 0.5f);
        }
        else if (CurrentSnakeId == SnakeId.Snake2)
        {
            gridPosition = new Vector2(17.5f, 0.5f);
        }

        gridfMoveTimerMax = 1f;
        gridMoveTimer = gridfMoveTimerMax;

        gridMoveDirection = new Vector2(0, 1);

        snakeMovementPositionList = new List<Vector2>();
        snakeBodyTransformList = new List<Transform>();
    }



   
    public void CheckingBoundry()
    {

       

        if (this.transform.position.x < BoundryLImitLeftDown.x || this.transform.position.x > BoundryUpRight.y || this.transform.position.y < BoundryLImitLeftDown.x || this.transform.position.y > BoundryUpRight.x)
        {
            if (CurrentSnakeId == SnakeId.Snake1)
            {
                state = SnakeState.Dead;
            }
            if (CurrentSnakeId == SnakeId.Snake2)
            {
                state = SnakeState.Dead;
            }
        }

    }
    public void HandlegridMovemet()
    {
        Debug.Log("Running update parent..");
        gridMoveTimer += Time.deltaTime * (boostedSpeed);
        if (gridMoveTimer >= gridfMoveTimerMax)
        {
            snakeMovementPositionList.Insert(0, gridPosition);
            gridMoveTimer -= gridfMoveTimerMax;

          


            gridPosition += gridMoveDirection ;

        }





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
            
      if (snakeAteFood1)
        {
                if (CurrentSnakeId== SnakeId.Snake1)
                {
                    Debug.Log("Snake 1 Ate *GoodFood* grow Body");
                    snakeBodySize+=1;
                  
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

              
                Debug.Log("Snake Ate *BadFood* remove Body");
                if (CurrentSnakeId == SnakeId.Snake1)
                {
                   // snakeBodySize--;
                    RemovingSnakeBody();
                 
                    UiManager.instance.scoreSnake1 -= 1;
                    if (UiManager.instance.scoreSnake1 < 0)
                    {
                     
                        UiManager.instance.loosePanel.gameObject.SetActive(true);
                        UiManager.instance.scoreSnake1 = 0;
                    }
                    

                }
                if (CurrentSnakeId == SnakeId.Snake2)
                {
                    RemovingSnakeBody();
                
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
            if (gridPosition == snakeBodyPartsgridPosition)
            {
            }
        }
    }

    private void RemovingSnakeBody()
    {
        if (snakeBodySize >= 0  )
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
            Destroy(lastBodyPart.gameObject);

            
        }
       

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


   
}

