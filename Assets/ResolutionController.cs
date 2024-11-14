using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResolutionController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TMP_Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;
    public Toggle vsycToggle;
    Resolution[] Allresolutions;
    bool isFullScreen;
    int selectedResolution;
    List<Resolution> selectedResolutionList = new List<Resolution>();
        

    void Start()
    {
      isFullScreen = true;
      Allresolutions = Screen.resolutions;
      //Screen.SetResolution(1920,1080,isFullScreen);

      List<string> resolutionList = new List<string>();
      string newRes;

      foreach (Resolution res in Allresolutions){
        newRes = res.width.ToString() + " x " + res.height.ToString();
        if(!resolutionList.Contains(newRes)){
            resolutionList.Add(newRes);
            selectedResolutionList.Add(res);
        }
        
      }

      resolutionDropdown.AddOptions(resolutionList);

      if(QualitySettings.vSyncCount == 0){
        vsycToggle.isOn = false;
      }else{
        vsycToggle.isOn = true;
      }
    }

    public void ChangeResolution(){
        selectedResolution = resolutionDropdown.value;
        Screen.SetResolution(selectedResolutionList[selectedResolution].width,selectedResolutionList[selectedResolution].height,isFullScreen);
    }

    public void changeFullScreen(){
        isFullScreen = fullscreenToggle.isOn;
        Screen.SetResolution(selectedResolutionList[selectedResolution].width,selectedResolutionList[selectedResolution].height,isFullScreen);
    }
    // Update is called once per frame

    public void changeVsync(){
        if(vsycToggle.isOn){
            QualitySettings.vSyncCount = 1;
        }else{
            QualitySettings.vSyncCount = 0;
        }
    }
    public void goBack(){
        SceneManager.LoadScene("MainMenu");
    }
}
