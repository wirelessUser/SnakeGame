using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    [SerializeField] 
    private Snake snakref;
    [SerializeField]
    private  Foodgen foodGenObj;
    public Grid gridref;
   
    private void Start()
    {
        
    //    GameObject snakeHead = new GameObject();
       // SpriteRenderer snakeheadSprite = snakeHead.AddComponent<SpriteRenderer>();
       // snakeheadSprite.sprite = SpriteRefer.instance.SnakeHeadSprite;
        //snakeHead.transform.localScale = new Vector2(2.5f, 2.5f);

     

        foodGenObj = new Foodgen(20, 20, gridref);
        
     
       snakref.RefToOther(foodGenObj);
        foodGenObj.RefToOther(snakref);
       foodGenObj.RefToOtherGrid(gridref);
    }


    private void Update()
    {

     
        //  Destroy(foodGenObj.foodGameObj1, 10);   //  if we are destroy foodGameObj1  then becuasde it's a refernce only then how the obejct from memeory will
                                                   // get deleted ? 
                                                  // Answer: grabage colector will automatyiclly detsroy it if referbnce count=0;
      
    }
}
