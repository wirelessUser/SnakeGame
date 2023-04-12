using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;


    public Snake snakref1;
    public Snake snakref2;
    public GameObject GoodFoodPrefab;

    public GameObject BadFoodPrefab;

    public GameObject PowerUpPrefab;
    public Grid gridref;
    public GameObject snakeBodySprite;

    public TextMeshProUGUI textloosePanel;
    public TextMeshProUGUI textwinPanel;
    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }


        CreatePowerUp();
       
        CreateGoodFood();
        CreateBadFood();


        //GoodFoodPrefab = Resources.Load("Good Food 1") as GameObject;

        //BadFoodPrefab = Resources.Load("Bad Food 1") as GameObject;
    }

   
    public void CreatePowerUp()
    {
      
        Instantiate(PowerUpPrefab);

        snakref1.PowerUP = GameObject.Find("PowerUp(Clone)");
        snakref2.PowerUP = GameObject.Find("PowerUp(Clone)");
    }
    public void CreateGoodFood()
    {
        Instantiate(GoodFoodPrefab);
        snakref1.foodref1 = GameObject.Find("Good Food 1(Clone)");
       
        snakref2.foodref1 = GameObject.Find("Good Food 1(Clone)");
        
    }
    public void CreateBadFood()
    {
       
        Instantiate(BadFoodPrefab);
        snakref1.foodref2 = GameObject.Find("Bad Food 1(Clone)");
      
        snakref2.foodref2 = GameObject.Find("Bad Food 1(Clone)");

       
    }
    private void Update()
    {


        //Destroy(GoodFoodPrefab, 10);
        // Destroy(PowerUpPrefab, 10);
        //Destroy(BadFoodPrefab, 10);

       

        //Invoke("CreatePrefabAfterSeconds", Random.Range(15, 25));
        //StartCoroutine(DestroPrefabAfterSeconds());

    }



    //public IEnumerator CreatePrefabAfterSeconds()
    //{
    //    yield return new WaitForSeconds(Random.Range(15, 25));

    //    CreatePowerUp();
    //    CreateGoodFood();
    //    CreateBadFood();
    //}

    //public IEnumerator DestroPrefabAfterSeconds()
    //{
    //    yield return new WaitForSeconds(20);

    //    GoodFoodPrefab.gameObject.SetActive(false);
    //    BadFoodPrefab.gameObject.SetActive(false);
    //    PowerUpPrefab.gameObject.SetActive(false);

    //}













}
