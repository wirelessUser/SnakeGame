using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    public TextMeshProUGUI ScoretextSnake1;
    public TextMeshProUGUI ScoretextSnake2;
    public int scoreSnake1;
    public int scoreSnake2;
    public GameObject WinPanel;
    public GameObject loosePanel;
    public GameObject resume;
    public GameObject pause;
    

    public TextMeshProUGUI BoostedText;
    public float Timer;

    
    public bool[] boostSnake;

    void createInstance()
    {
        if (instance== null)
        {
            instance = this;
        }


    }
    private void Awake()
    {
        boostSnake[0] = false;
        resume.gameObject.SetActive(false);
        WinPanel.gameObject.SetActive(false);
        loosePanel.gameObject.SetActive(false);
        createInstance();
        scoreSnake1 = 0;

        ScoretextSnake1.text = "Score:" + " " + scoreSnake1;
        ScoretextSnake2.text = "Score:" + " " + scoreSnake2;
    }


    private void Start()
    {
            
    }
    // Update is called once per frame
    void Update()
    {
       // print("calkling update of UI");
        ScoretextSnake1.text = "Score:" + scoreSnake1;
        ScoretextSnake2.text = "Score:" + scoreSnake2;

        if (boostSnake[0]==true)
        {
           
                Timer += Time.deltaTime;
                if (Timer >= 5)
                {
                    BoostedText.gameObject.SetActive(false);
                    boostSnake[0] = false;
                    Timer = 0;
                }
           
        }

    
    }



    
    public void Boost(GameObject  snakeObj)
    {
        BoostedText.text = "Congrats! " + snakeObj.name + "You are Boosted";

        BoostedText.gameObject.SetActive(true);

    }
    public void Restart(string Levelname)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(Levelname);
        WinPanel.gameObject.SetActive(false);
        pause.gameObject.SetActive(false);
        loosePanel.gameObject.SetActive(false);
    }

    public void pausegame()
    {
        Time.timeScale = 0;
        resume.gameObject.SetActive(true);

    }

   
    public void Resumegame()
    {
        Time.timeScale = 1;
        resume.gameObject.SetActive(false);
        pause.gameObject.SetActive(true);

    }
}
