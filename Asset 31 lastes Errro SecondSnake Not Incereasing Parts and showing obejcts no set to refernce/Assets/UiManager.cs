using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    public TextMeshProUGUI Scoretext;
   
    public int score;
    public GameObject WinPanel;
    public GameObject loosePanel;
    public GameObject resume;
    public GameObject pause;
    void createInstance()
    {
        if (instance == null)
        {
            instance = this;
        }


    }
    private void Awake()
    {
        resume.gameObject.SetActive(false);
        WinPanel.gameObject.SetActive(false);
        loosePanel.gameObject.SetActive(false);
        createInstance();
        score = 0;

        Scoretext.text = "Score:" + " " + score;
    }


    private void Start()
    {
            
    }
    // Update is called once per frame
    void Update()
    {
       // print("calkling update of UI");
        Scoretext.text = "Score:" + score;
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
