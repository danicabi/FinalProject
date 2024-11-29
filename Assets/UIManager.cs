using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject deathPanel;
    [SerializeField] GameObject winPanel;

    public void ToggleDeathPanel(){
        deathPanel.SetActive(true);
    }

    public void ToggleWinPanel(){
        winPanel.SetActive(true);
    }
}
