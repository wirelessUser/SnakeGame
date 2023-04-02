using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 gridMoveDirection;  // where the snak eis moving
    private Vector2 gridPosition;
    private float gridMoveTimer;
    private float gridfMoveTimerMax = 1f; // contain the amount of time between moves

    // differnce of initializibng the variable in the class or inside the Awake or Start

    public Foodgen foodref;


    // Food Obejct passing.......
    public void FoodObj(Foodgen _Foodref)
    {
        foodref = _Foodref;
    }




    private void Start()
    {
        gridPosition = new Vector2(0.5f, 0.5f);
        gridfMoveTimerMax = 1f;
        gridMoveTimer = gridfMoveTimerMax;

        gridMoveDirection = new Vector2(0, 1);
    }



    private void Update()
    {

        TakingInput();
        gridMoveTimer += Time.deltaTime;
        if (gridMoveTimer >= gridfMoveTimerMax)
        {
            gridPosition += gridMoveDirection;  // increasing grid Postion By gridMoveDirection
            gridMoveTimer -= gridfMoveTimerMax;  // Reseting the timer to zero to calcute from beginning
        }



        this.transform.position = new Vector3(gridPosition.x, gridPosition.y);
    }



    public void TakingInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // gridPos.y += 10;
            if (gridMoveDirection.y != -1)
            {
                gridMoveDirection = new Vector2(0, 1);
                
            }


        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (gridMoveDirection.y != 1)
            {
                gridMoveDirection = new Vector2(0, -1);
                this.transform.eulerAngles = new Vector3(0, 0, gridMoveDirection.y * 180);
            }


        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (gridMoveDirection.x != 1)
            {
                gridMoveDirection = new Vector2(-1, 0);
                this.transform.eulerAngles = new Vector3(0, 0, -gridMoveDirection.x * 90);
            }


        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
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
}
