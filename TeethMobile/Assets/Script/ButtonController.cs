using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public GameObject infoScreen, mouth, kokluDis, displaybuttonText, infoScreenButton;
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
            displaybuttonText.GetComponent<TMPro.TextMeshProUGUI>().text = "Dişi Göster";
            infoScreenButton.SetActive(false);
            displayMouth = false;
        }
        else{
            mouth.SetActive(false);
            kokluDis.SetActive(true);
            displaybuttonText.GetComponent<TMPro.TextMeshProUGUI>().text = "Ağzı Göster";
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
