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


   
    private void Start()
    {
 
        foodGenObj1 = new Foodgen(20, 20, gridref, "GoodFood");//GoodFood

        foodGenObj2 = new Foodgen(20, 20, gridref, "BadFood");

        snakref1.RefToOther1(foodGenObj1);
        foodGenObj1.RefToOther(snakref1);
       foodGenObj1.RefToOtherGrid(gridref);

        // For Bad Food..........
        snakref2.RefToOther2(foodGenObj2);
        foodGenObj2.RefToOther(snakref1);
        foodGenObj2.RefToOtherGrid(gridref);
    }


    private void Update()
    {


        Destroy(foodGenObj1.foodGameObj1, 30);   //  if we are destroy foodGameObj1  then becuasde it's a refernce only then how the obejct from memeory will
        Destroy(foodGenObj2.foodGameObj1, 30);                                           // get deleted ? 
                                                                                         // Answer: grabage colector will automatyiclly detsroy it if referbnce count=0;

    }
}
