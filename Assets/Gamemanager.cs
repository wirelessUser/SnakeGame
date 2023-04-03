using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    
    [SerializeField] 
    private Snake snakref1;
    [SerializeField]
    private Snake snakref2;
    public Foodgen foodGenObj1;
   
    public Foodgen foodGenObj2;
    public Grid gridref;
    public GameObject snakeBodySprite;
 

    private void Awake()
    {
   
        foodGenObj1 = new Foodgen(20, 20, gridref, "GoodFood");//GoodFood
      
       foodGenObj2 = new Foodgen(20, 20, gridref, "BadFood");

        foodGenObj1.RefToOtherGrid(gridref);
    }

    private void Start()
    {
 

        // FSnake reference .......
        //For Snake 2..
        snakref2.RefToOther2(foodGenObj2);
        foodGenObj2.RefToOther(snakref2);

        snakref2.RefToOther1(foodGenObj1);
        foodGenObj1.RefToOther(snakref2);
        // For Snake 1....
        snakref1.RefToOther1(foodGenObj1);
        foodGenObj1.RefToOther(snakref1);
        snakref1.RefToOther2(foodGenObj2);
        foodGenObj2.RefToOther(snakref1);
        // FSnake reference .......


        //...Food Object refrence .......
        // Food Ovbejct 1




        // Food Ovbejct 2.....




        foodGenObj1.RefToOtherGrid(gridref);
        foodGenObj2.RefToOtherGrid(gridref);
    }


    private void Update()
    {


        Destroy(foodGenObj1.foodGameObj1, 30);   
        Destroy(foodGenObj2.foodGameObj1, 30);                                          
                                                                                         

    }
}
