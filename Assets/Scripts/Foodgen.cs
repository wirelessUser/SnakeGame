using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FoodName
{
    Good,
    Bad,
    PowerBooster
}
public class Foodgen : MonoBehaviour
{
    public Vector3 FoodPos;

    private int width, height;
    //public GameObject foodGameObj1;
   

    //public Snake snakeref2;
    public Grid gridref;

    public GameObject[] snakeref = new GameObject[2];

    public string name_Food = "";
    public float timeToDestroy = 2;
    public float destroy = 0;
    Color color ;
    public FoodName foodname;
    private void Update()
    {

        //Debug.Log("Time.time" + Time.time);
    }

    private void Start()
    {
        
       
    }
    private void Awake()
    {
        InvokeRepeating("Ativatecalling", 0f,Random.Range(3,8));
      
        FoodSpawn();
      
    }
    public void RefToOtherGrid(Grid _gridref)
    {

        gridref = _gridref;
    
    }
  
    private void  FoodSpawn()
    {
        for (int i = 0; i < snakeref.Length; i++)
        {
            do
            {
                FoodPos = GridPosFood();
            } while (snakeref[i].GetComponent<Snake>().ReturningListOfAllSnakeBodyParts().IndexOf(FoodPos) != -1);
        }
        

  

        this.transform.position = FoodPos;
        this.transform.localScale = new Vector3(0.25f, 0.25f);
        this.GetComponent<SpriteRenderer>().sortingLayerName= "Player";
        this.GetComponent<SpriteRenderer>().sortingOrder = 5;
    }


    public bool TrySnakeEatFood(Vector3 snakeGridPos)
    {
       
     
        if (snakeGridPos == this.gameObject.transform.position)
        {
     
           this.gameObject.SetActive(false);
            
            this.transform.position = GridPosFood();
        
            return true;

        }
        else
        {
         
            return false;
        }
    }



    public Vector3 GridPosFood()
    {
        Vector3 findrandPos = Vector3.zero;
   
        Vector3 posTileFood = new Vector3(17.5f, 9.5f);
                float RandomPosX = Random.Range(0.5f, posTileFood.x);
                float RandomPosY = Random.Range(0.5f, posTileFood.y);
      
        Vector3 initalPos = new Vector2(0.5f, 0.5f);
        
               findrandPos = initalPos + new  Vector3((int)RandomPosX, (int)RandomPosY);
       
        //    }// end For inner 
        //}// end For outer 
        return findrandPos;
    }// end gridposFood


    public void Ativatecalling()
    {
       
       
       
        this.gameObject.SetActive(true);
       


    }

    public void Detivatecalling()
    {
        this.transform.position = GridPosFood();
    
        gameObject.SetActive(false);
      
    }

   

    public IEnumerator DeactivatePrefabAfterSeconds()
    {
       
        yield return new WaitForSeconds(8);

        gameObject.SetActive(false);
     


    }

}
