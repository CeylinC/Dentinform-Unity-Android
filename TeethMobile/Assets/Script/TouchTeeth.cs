using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTeeth : MonoBehaviour
{
    Animator mouthanimator, kameraanimator;
    Camera kamera;
    public GameObject infoScreen, description, title;
    public GameObject[] kardesDis, allTeeths;
    [SerializeField] private Material highlightMaterial, defaultMaterial, kardesDisMaterial;
    string[] TeethNameList = {
    "DownTeethLeftMolar.1",
    "DownTeethLeftMolar.2",
    "DownTeethLeftMolar.3",
    "DownTeethRightMolar.1",
    "DownTeethRightMolar.2",
    "DownTeethRightMolar.3",
    "DownTeethLeftPremolar.1",
    "DownTeethLeftPremolar.2",
    "DownTeethRightPremolar.1",
    "DownTeethRightPremolar.2",
    "DownTeethLeftCanine.1",
    "DownTeethRightCanine.1",
    "DownTeethLeftIncisor.1",
    "DownTeethLeftIncisor.2",
    "DownTeethRightIncisor.1",
    "DownTeethRightIncisor.2",
    "UpTeethLeftMolar.1",
    "UpTeethLeftMolar.2",
    "UpTeethLeftMolar.3",
    "UpTeethRightMolar.1",
    "UpTeethRightMolar.2",
    "UpTeethRightMolar.3",
    "UpTeethLeftPremolar.1",
    "UpTeethLeftPremolar.2",
    "UpTeethRightPremolar.1",
    "UpTeethRightPremolar.2",
    "UpTeethLeftCanine.1",
    "UpTeethRightCanine.1",
    "UpTeethLeftIncisor.1",
    "UpTeethLeftIncisor.2",
    "UpTeethRightIncisor.1",
    "UpTeethRightIncisor.2"
};
    string[] TeethDescription = {
        "Canine diş açıklaması",
        "Incisor diş açıklaması",
        "Molar diş açıklaması",
        "Premolar diş açıklaması"
    };
    void Start()
    {
        int i;
        kamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        mouthanimator = GameObject.Find("Mouth").GetComponent<Animator>();
        allTeeths = new GameObject[TeethNameList.Length];
        for(i=0; i<TeethNameList.Length; i++){
            allTeeths[i] = GameObject.Find(TeethNameList[i]);
        }
        OpenMouth();
    }

    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            Touch dokunma = Input.GetTouch(0); //Tek dokunma
            RaycastHit dokunulanNesne;
            if (Physics.Raycast(kamera.ScreenPointToRay(dokunma.position), out dokunulanNesne))
            {
                PaintTeeth(defaultMaterial, allTeeths);
                foreach (string teeth in TeethNameList)
                {
                    if (dokunulanNesne.collider.gameObject.name == teeth)
                    {
                        LeftMouth();
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
    public void OpenMouth(){
        mouthanimator.SetBool("Open", true);
        ChangeCameraTransform();
    }
    void LeftMouth(){
        GameObject.Find("Mouth").transform.position = new Vector3(-2,0,-2);
        infoScreen.SetActive(true);
    }
}
