using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuManager : MonoBehaviour
{
    public void StartGame(){
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void Option(){
        SceneManager.LoadScene("Options");
    }
}
