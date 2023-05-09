using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake2 : Snake
{

    private void Update()
    {

        if (state == SnakeState.Alive)
        {
            TakingInput();
           
            HandlegridMovemet();
        }
        else
        {
            UiManager.instance.loosePanel.SetActive(true);
        }
      

        CheckingBoundry();


    }




    public void TakingInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {

            // gridPos.y += 10;
            if (gridMoveDirection.y != -1)
            {
                snakeMOve = Moving.Up;
                gridMoveDirection = new Vector2(0, 1);


            }

            this.transform.eulerAngles = new Vector3(0, 0, gridMoveDirection.x);
        }



        if (Input.GetKeyDown(KeyCode.S))
        {
            if (gridMoveDirection.y != 1)
            {
                snakeMOve = Moving.Down;
                gridMoveDirection = new Vector2(0, -1);
                this.transform.eulerAngles = new Vector3(0, 0, gridMoveDirection.y * 180);
            }

        }


        if (Input.GetKeyDown(KeyCode.A))
        {

            if (gridMoveDirection.x != 1)
            {
                snakeMOve = Moving.Left;
                gridMoveDirection = new Vector2(-1, 0);
                this.transform.eulerAngles = new Vector3(0, 0, -gridMoveDirection.x * 90);
            }

        }


        if (Input.GetKeyDown(KeyCode.D))
        {
            if (gridMoveDirection.x != -1)
            {
                snakeMOve = Moving.Right;
                gridMoveDirection = new Vector2(1, 0);
                this.transform.eulerAngles = new Vector3(0, 0, -gridMoveDirection.x * 90);
            }

        }


    }






















}// End class.....
