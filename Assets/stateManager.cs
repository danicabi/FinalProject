using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stateManager : MonoBehaviour
{
    public void reloadCurrentScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void changeSceneByName(string name){
        if(name != null){
            SceneManager.LoadScene(name);
        }
    }
}
