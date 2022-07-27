using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public GameObject infoScreen, mouth, kokluDis, displayButton, infoScreenButton;
    bool displayMouth = false, YesNo = true;
    public void PlayScene(){
        SceneManager.LoadScene("SampleScene");
    }
    public void HomeScene(){
        SceneManager.LoadScene("HomePage");
    }
    public void Display(){
        kokluDis.transform.position = new Vector3(0,0,0);
        infoScreen.SetActive(false);
        if(displayMouth){
            mouth.SetActive(true);
            kokluDis.SetActive(false);
            displayButton.transform.GetChild(0).gameObject.SetActive(true); //Tooth
            displayButton.transform.GetChild(1).gameObject.SetActive(false); //Teeth
            infoScreenButton.SetActive(false);
            displayMouth = false;
        }
        else{
            mouth.SetActive(false);
            kokluDis.SetActive(true);
            displayButton.transform.GetChild(1).gameObject.SetActive(true); //Teeth
            displayButton.transform.GetChild(0).gameObject.SetActive(false); //Tooth
            infoScreenButton.SetActive(true);
            displayMouth = true;
        }
    }
    public void InfoScreen(){
        if(YesNo){
            kokluDis.transform.position = new Vector3(-3,0,0);
            infoScreen.SetActive(true);
            YesNo = false;
        }
        else{
            kokluDis.transform.position = new Vector3(0,0,0);
            infoScreen.SetActive(false);
            YesNo = true;
        }
    }
}
