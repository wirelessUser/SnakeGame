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

    }


}
