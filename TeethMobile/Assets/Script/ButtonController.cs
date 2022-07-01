using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void PlayScene(){
        SceneManager.LoadScene("SampleScene");
    }
    public void InfoScene(){
        SceneManager.LoadScene("InfoScene");
    }
    public void HomeScene(){
        SceneManager.LoadScene("HomePage");
    }

}
