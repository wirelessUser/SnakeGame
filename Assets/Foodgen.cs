using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Foodgen /*: MonoBehaviour*/ 
{
    private Vector2 FoodPos;

    private int width, height;
    public GameObject foodGameObj1;
    private Snake snakeref;
    public Grid gridref;


 
    public string name_Food = "";
    public float timeToDestroy = 2;
    public float destroy = 0;
    Color color ;
    private void Update()
    {
            
    }

    public Foodgen(int _width, int _height, Grid _gridref, string _name)
    {
        width = _width;
        height = _height;
        gridref = _gridref;
        name_Food = _name;

        color = new Color(244 / 255f, 196 / 255f, 48 / 255f);

    }

    public void RefToOtherGrid(Grid _gridref)
    {
        gridref = _gridref;
    
    }
    public void RefToOther(Snake _snakeref)
    {
        snakeref = _snakeref;
        FoodSpawn();// check for null
    }
    private void  FoodSpawn()
    {
        do
        {
            FoodPos = GridPosFood(); 
        } while (snakeref.ReturningListOfAllSnakeBodyParts().IndexOf(FoodPos)!= -1);  

     

        foodGameObj1 = new GameObject(name_Food, typeof(SpriteRenderer));  

        if (name_Food == "BadFood")
        {
            if (snakeref.gameObject.tag=="Player2")
            {
                foodGameObj1.GetComponent<SpriteRenderer>().sprite = SpriteRefer.instance.FoodSprite2;
                foodGameObj1.GetComponent<SpriteRenderer>().tag = "ForPlayer2";
                foodGameObj1.GetComponent<SpriteRenderer>().material.color = Color.black;

            }
            else if(snakeref.gameObject.tag == "Player1")
            {
                foodGameObj1.GetComponent<SpriteRenderer>().sprite = SpriteRefer.instance.FoodSprite2;
                foodGameObj1.GetComponent<SpriteRenderer>().tag = "ForPlayer1";
              


            }

            // Set differtn color  ...
        }
        else if (name_Food == "GoodFood")
        {

            if (snakeref.gameObject.tag == "Player2")
            {

                foodGameObj1.GetComponent<SpriteRenderer>().sprite = SpriteRefer.instance.FoodSprite;
                foodGameObj1.GetComponent<SpriteRenderer>().tag = "ForPlayer2";
                foodGameObj1.GetComponent<SpriteRenderer>().material.color = Color.black; ;

            }
            else
            if (snakeref.gameObject.tag == "Player1")
            {

                foodGameObj1.GetComponent<SpriteRenderer>().sprite = SpriteRefer.instance.FoodSprite;
                foodGameObj1.GetComponent<SpriteRenderer>().tag = "ForPlayer1";

            }
        }

        foodGameObj1.transform.position = FoodPos;
        foodGameObj1.transform.localScale = new Vector3(0.25f, 0.25f);
        foodGameObj1.GetComponent<SpriteRenderer>().sortingLayerName= "Player";
        foodGameObj1.GetComponent<SpriteRenderer>().sortingOrder = 5;
    }


    public bool  TrySnakeEatFood(Vector2 snakeGridPos)
    {

        if (snakeGridPos ==FoodPos)
        {
            Debug.Log("true Get called called for >>" + this.foodGameObj1.name + ">>" + snakeref.gameObject.name);
                Object.Destroy(foodGameObj1);
                FoodSpawn();
                return true;
           
        }
        else
        {
            Debug.Log("False  Get called called for >>" + this.foodGameObj1.name + ">>" + snakeref.gameObject.name);
            return false;
        }
    }



    public Vector2 GridPosFood()
    {
        Vector2 findrandPos = Vector2.zero;
   
        Vector2 posTileFood = new Vector2(17.5f, 9.5f);
                float RandomPosX = Random.Range(0.5f, posTileFood.x);
                float RandomPosY = Random.Range(0.5f, posTileFood.y);
      
        Vector2 initalPos = new Vector2(0.5f, 0.5f);
        
               findrandPos = initalPos + new  Vector2((int)RandomPosX, (int)RandomPosY);
       
        //    }// end For inner 
        //}// end For outer 
        return findrandPos;
    }// end gridposFood



}
