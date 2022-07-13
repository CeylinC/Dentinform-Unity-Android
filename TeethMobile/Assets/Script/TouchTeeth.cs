using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTeeth : MonoBehaviour
{
    Animator mouthanimator, kameraanimator;
    Camera kamera;
    public GameObject infoScreen, description, title, kokluDis, mouth, displaybutton;
    public GameObject[] kardesDis, allTeeths, allTooths;
    [SerializeField] private Material highlightMaterial, defaultMaterial, kardesDisMaterial;
    //Teeth ve Tooth sağdan sola sıralı
    string[] ToothNameList = {
        "d1",
        "d2",
        "d3",
        "d4",
        "d5",
        "d6",
        "d7",
        "d8",
        "d9",
        "d10",
        "d11",
        "d12",
        "d13",
        "d14",
        "d15",
        "d16",
        "u1",
        "u2",
        "u3",
        "u4",
        "u5",
        "u6",
        "u7",
        "u8",
        "u9",
        "u10",
        "u11",
        "u12",
        "u13",
        "u14",
        "u15",
        "u16"
    };
    string[] TeethNameList = {
    "DownTeethRightMolar.1",
    "DownTeethRightMolar.2",
    "DownTeethRightMolar.3",
    "DownTeethRightPremolar.1",
    "DownTeethRightPremolar.2",
    "DownTeethRightCanine.1",
    "DownTeethRightIncisor.1",
    "DownTeethRightIncisor.2",
    "DownTeethLeftIncisor.2",
    "DownTeethLeftIncisor.1",
    "DownTeethLeftCanine.1",
    "DownTeethLeftPremolar.2",
    "DownTeethLeftPremolar.1",
    "DownTeethLeftMolar.3",
    "DownTeethLeftMolar.2",
    "DownTeethLeftMolar.1",
    "UpTeethRightMolar.2",
    "UpTeethRightMolar.1",
    "UpTeethRightMolar.3",
    "UpTeethRightPremolar.1",
    "UpTeethRightPremolar.2",
    "UpTeethRightCanine.1",
    "UpTeethRightIncisor.1",
    "UpTeethRightIncisor.2",
    "UpTeethLeftIncisor.2",
    "UpTeethLeftIncisor.1",
    "UpTeethLeftCanine.1",
    "UpTeethLeftPremolar.2",
    "UpTeethLeftPremolar.1",
    "UpTeethLeftMolar.3",
    "UpTeethLeftMolar.2",
    "UpTeethLeftMolar.1",

};
    string[] TeethDescription = {
        "Canine diş açıklaması",
        "Incisor diş açıklaması",
        "Molar diş açıklaması",
        "Premolar diş açıklaması"
    };
    void Start()
    {
        int j;
        kamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        mouthanimator = mouth.GetComponent<Animator>();
        allTeeths = new GameObject[TeethNameList.Length];
        allTooths = new GameObject[ToothNameList.Length];
        for(j=0; j<TeethNameList.Length; j++){
            allTeeths[j] = GameObject.Find(TeethNameList[j]);
        }
        for(j=0; j<ToothNameList.Length; j++){
            allTooths[j] = GameObject.Find(ToothNameList[j]);
            allTooths[j].SetActive(false);
        }
        kokluDis.SetActive(false);
        OpenMouth();
    }

    void FixedUpdate()
    {
        int i;
        if (Input.touchCount > 0)
        {
            Touch dokunma = Input.GetTouch(0); //Tek dokunma
            RaycastHit dokunulanNesne;
            if (Physics.Raycast(kamera.ScreenPointToRay(dokunma.position), out dokunulanNesne)){
                PaintTeeth(defaultMaterial, allTeeths);
                foreach(GameObject tooth in allTooths){
                    tooth.transform.localEulerAngles = new Vector3(90,0,0);
                    tooth.SetActive(false);
                }
                for(i=0; i<TeethNameList.Length; i++){
                    if (dokunulanNesne.collider.gameObject.name == TeethNameList[i]){
                        LeftMouth();
                        allTooths[i].SetActive(true);
                        displaybutton.SetActive(true);
                        kardesDis = GameObject.FindGameObjectsWithTag(dokunulanNesne.collider.gameObject.tag);
                        switch (dokunulanNesne.collider.gameObject.tag)
                        {
                            case "Canine":
                                description.GetComponent<TMPro.TextMeshProUGUI>().text = TeethDescription[0];
                                title.GetComponent<TMPro.TextMeshProUGUI>().text = "Canine";
                                PaintTeeth(kardesDisMaterial, kardesDis);
                                break;
                            case "Incisor":
                                description.GetComponent<TMPro.TextMeshProUGUI>().text = TeethDescription[1];
                                title.GetComponent<TMPro.TextMeshProUGUI>().text = "Incisor";
                                PaintTeeth(kardesDisMaterial, kardesDis);
                                break;
                            case "Molar":
                                description.GetComponent<TMPro.TextMeshProUGUI>().text = TeethDescription[2];
                                title.GetComponent<TMPro.TextMeshProUGUI>().text = "Molar";
                                PaintTeeth(kardesDisMaterial, kardesDis);
                                break;
                            case "Premolar":
                                description.GetComponent<TMPro.TextMeshProUGUI>().text = TeethDescription[3];
                                title.GetComponent<TMPro.TextMeshProUGUI>().text = "Premolar";
                                PaintTeeth(kardesDisMaterial, kardesDis);
                                break;
                        }
                        var selection = dokunulanNesne.transform.GetComponent<Renderer>();
                        selection.material = highlightMaterial;
                    }
                }
            }
        }
    }

    void PaintTeeth(Material mat, GameObject[] teeths){
        int i;
        for(i=0; i<teeths.Length; i++){
            teeths[i].transform.GetComponent<Renderer>().material = mat;
        }
    }
    void ChangeCameraTransform(){
        kameraanimator = GameObject.Find("Main Camera").GetComponent<Animator>();
        kameraanimator.SetBool("Open", true);
    }
    void OpenMouth(){
        mouthanimator.SetBool("Open", true);
        ChangeCameraTransform();
    }
    void LeftMouth(){
        mouth.transform.position = new Vector3(-2,0,-2);
        infoScreen.SetActive(true);
    }
}
