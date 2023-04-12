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

        Debug.Log("Time.time" + Time.time);
    }

    private void Start()
    {
        
       
    }
    private void Awake()
    {
        InvokeRepeating("Ativatecalling", 0f,3);
        InvokeRepeating("Detivatecalling", 0f, 8);
       // StartCoroutine(ActivateePrefabAfterSeconds());
        FoodSpawn();
      
    }
    public void RefToOtherGrid(Grid _gridref)
    {

        gridref = _gridref;
    
    }
    public void RefToOther(Snake _snakeref)
    {

        // snakeref = _snakeref;
        //FoodSpawn();// check for null
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
     //  Debug.Log("transfrom.posiomn>>" + transform.position + "Name==" + this.gameObject.name);
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
       // Debug.Log("fcunion isndie coruotine called Abob=ve line hit");
       
        Debug.Log("Above Time At Activation  call >>" + Time.time);
        this.gameObject.SetActive(true);
        Debug.Log("Below Time At Activation call >>" + Time.time);
       // Debug.Log("fcunion isndie coruotine called Below line hit");

       //StartCoroutine(DeactivatePrefabAfterSeconds());

    }

    public void Detivatecalling()
    {
       // Debug.Log("Above Deativateion Yield Above Line ");
        this.transform.position = GridPosFood();
        Debug.Log("Above Time At Detivatecalling  call >>" + Time.time);
        gameObject.SetActive(false);
        Debug.Log("Below Time At Detivatecalling call >>" + Time.time);
       // Debug.Log("Above Deativateion Yield Bewlo line ");
    }

    //public IEnumerator ActivateePrefabAfterSeconds()
    //{

    //    Debug.Log("Above yiled");
    //    yield return new WaitForSeconds(0);
    //    Ativatecalling();
    //    Debug.Log("Below yiled");
    //    StartCoroutine(DeactivatePrefabAfterSeconds());

    //   StartCoroutine(ActivateePrefabAfterSeconds());

    //}

    public IEnumerator DeactivatePrefabAfterSeconds()
    {
        Debug.Log("Above Time At deatcivation call >>" + Time.time);
        Debug.Log("Above Deativateion Yield ");
        yield return new WaitForSeconds(8);

        gameObject.SetActive(false);
        Debug.Log(" Below Time At deatcivation call >>" + Time.time);
        Debug.Log("Below  Deativateion Yield");


        //StartCoroutine(DeactivatePrefabAfterSeconds());
    }

}
