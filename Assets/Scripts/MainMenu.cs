using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public Button PlayButton;
    public string scenName;

    private void Awake()
    {
        
        PlayButton.onClick.AddListener(() => {SceneManager.LoadScene(scenName); } );

       // GameObject.Find("PlayButton").GetComponent<Button>().onClick.AddListener((string sceneName) => { SceneManager.LoadScene(sceneName) });

        // error unity action does not take one arument
    }


}
