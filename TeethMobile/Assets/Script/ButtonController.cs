using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public GameObject infoScreen, mouth, kokluDis, displaybuttonText;
    bool displayMouth = false;
    public void PlayScene(){
        SceneManager.LoadScene("SampleScene");
    }
    public void InfoScene(){
        SceneManager.LoadScene("InfoScene");
    }
    public void HomeScene(){
        SceneManager.LoadScene("HomePage");
    }
    public void Display(){
        infoScreen.SetActive(false);
        mouth.transform.position = new Vector3(0,0,-2);
        if(displayMouth){
            mouth.SetActive(true);
            kokluDis.SetActive(false);
            displaybuttonText.GetComponent<TMPro.TextMeshProUGUI>().text = "Dişi Göster";
            displayMouth = false;
        }
        else{
            mouth.SetActive(false);
            kokluDis.SetActive(true);
            displaybuttonText.GetComponent<TMPro.TextMeshProUGUI>().text = "Ağzı Göster";
            displayMouth = true;
        }
    }
}
