using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakesDeathScript : MonoBehaviour
{
    public GameObject OtherSnake;
    public SnakeState state;
    public SnakeId CurrentSnakeId;



    private void Update()
    {
        MatchPositionsWith();
    }
    public void MatchPositionsWith()
    {

        if (this.transform.position == OtherSnake.transform.position)
        {
            if (CurrentSnakeId == SnakeId.Snake1)

            {
                state = SnakeState.Loose;
                OtherSnake.transform.GetComponent<Snake2>().state = SnakeState.Loose;
                transform.GetComponent<Snake1>().state = SnakeState.Loose;
            }

        }

        if (CurrentSnakeId == SnakeId.Snake1)

        {
            int count1 = OtherSnake.GetComponent<Snake2>().snakeBodyTransformList.Count;
            for (int i = 0; i < count1; i++)
            {
                if (this.transform.position == OtherSnake.GetComponent<Snake2>().snakeBodyTransformList[i].position)
                {
                    state = SnakeState.Loose;
                    OtherSnake.GetComponent<Snake2>().state = SnakeState.Win;

                }
            }


        }

        if (CurrentSnakeId == SnakeId.Snake2)

        {

            int count2 = OtherSnake.GetComponent<Snake1>().snakeBodyTransformList.Count;
            for (int i = 0; i < count2; i++)
            {

                if (this.transform.position == OtherSnake.GetComponent<Snake1>().snakeBodyTransformList[i].position)
                {

                    state = SnakeState.Loose;

                    OtherSnake.GetComponent<Snake1>().state = SnakeState.Win;
                }
            }


        }




    }// Match position.............


}
