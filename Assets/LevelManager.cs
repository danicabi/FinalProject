using System.Collections;
using System.Collections.Generic;
//using Unity.VisualScripting;
using UnityEngine;
//using UnityEngine.Scripting;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    void Awake(){
        //if(LevelManager.instance == null) instance = this;
        //else Destroy(gameObject);
        if (instance == null)
        {
            instance = this;
           
        }
        else
        {
            // If an instance already exists, destroy the duplicate
            Destroy(gameObject);
        }
        Debug.Log("LevelManager initialized");
    }
   public void GameOver(){
    UIManager ui = FindObjectOfType<UIManager>();
    if(ui != null){
        ui.ToggleDeathPanel();
        Debug.Log("pane show up ");
    }else{
        Debug.Log("UIManager not found");
    }
   }

   public void winner(){
    UIManager ui = FindObjectOfType<UIManager>();
    if(ui != null){
        ui.ToggleWinPanel();
        Debug.Log("pane show up ");
    }else{
        Debug.Log("UIManager not found");
    }
   }
}
