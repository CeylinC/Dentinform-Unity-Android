using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTeeth : MonoBehaviour
{
    public class Tooth
    {
        private string _name;
        private GameObject _tooth;
        private GameObject _toothInMouth;
        private float _kuronBoyu;
        private float _kokBoyu;
        private float _bukkalKokBoyu;
        private float _palatinalKokBoyu;
        private float _kuronGenisligi;
        private float _kuronGenisligiKole;
        private float _kuronKalinligi;
        private float _kuronKalinligiKole;
        private float _mesialEgim;
        private float _distalEgim;

        public Tooth(string _name, GameObject _tooth, GameObject _toothInMouth, float _kuronBoyu, float _kokBoyu, float _kuronGenisligi, float _kuronGenisligiKole, float _kuronKalinligi, float _kuronKalinligiKole, float _mesialEgim, float _distalEgim)
        {
            this._name = _name;
            this._tooth = _tooth;
            this._toothInMouth = _toothInMouth;
            this._kuronBoyu = _kuronBoyu;
            this._kokBoyu = _kokBoyu;
            this._kuronGenisligi = _kuronGenisligi;
            this._kuronGenisligiKole = _kuronGenisligiKole;
            this._kuronKalinligi = _kuronKalinligi;
            this._kuronKalinligiKole = _kuronKalinligiKole;
            this._mesialEgim = _mesialEgim;
            this._distalEgim = _distalEgim;
        }
        public Tooth(string _name, GameObject _tooth, GameObject _toothInMouth, float _kuronBoyu, float _bukkalKokBoyu, float _palatinalKokBoyu, float _kuronGenisligi, float _kuronGenisligiKole, float _kuronKalinligi, float _kuronKalinligiKole, float _mesialEgim, float _distalEgim)
        {
            this._name = _name;
            this._tooth = _tooth;
            this._toothInMouth = _toothInMouth;
            this._kuronBoyu = _kuronBoyu;
            this._bukkalKokBoyu = _bukkalKokBoyu;
            this._palatinalKokBoyu = _palatinalKokBoyu;
            this._kuronGenisligi = _kuronGenisligi;
            this._kuronGenisligiKole = _kuronGenisligiKole;
            this._kuronKalinligi = _kuronKalinligi;
            this._kuronKalinligiKole = _kuronKalinligiKole;
            this._mesialEgim = _mesialEgim;
            this._distalEgim = _distalEgim;
        }

        public GameObject GetToothInMouth() { return _toothInMouth; }
        public GameObject GetTooth() { return _tooth; }
        public string GetName() { return _name;}
        public float GetKuronBoyu() { return _kuronBoyu; }
        public float GetKokBoyu() { return _kokBoyu; }
        public float GetBukkalKokBoyu() { return _bukkalKokBoyu; }
        public float GetPalatinalKokBoyu() { return _palatinalKokBoyu; }
        public float GetKuronGenisligi() { return _kuronGenisligi; }
        public float GetKuronGenisligiKole() { return _kuronGenisligiKole; }
        public float GetKuronKalinligi() { return _kuronKalinligi; }
        public float GetKuronKalinligiKole() { return _kuronKalinligiKole; }
        public float GetMesialEgim() { return _mesialEgim; }
        public float GetDistalEgim() { return _distalEgim; }
    }
    Animator mouthanimator, kameraanimator;
    Camera kamera;
    List<Tooth> Teeth = new List<Tooth>();
    float speedRotation = 10.0f;
    Quaternion rotation;
    public GameObject infoScreen, description, title, kokluDis, mouth, displaybutton;
    [SerializeField] private Material highlightMaterial, defaultMaterial;

    void Start()
    {
        kamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        mouthanimator = mouth.GetComponent<Animator>();

        Teeth.Add(new Tooth("Sağ Alt 3. Molar", GameObject.Find("d16"), GameObject.Find("DownTeethRightMolar.1"), 7f, 11f, 10f, 7.5f, 9.5f, 9f, 1f, 0f));
        Teeth.Add(new Tooth("Sağ Alt 2. Molar", GameObject.Find("d15"), GameObject.Find("DownTeethRightMolar.2"), 7f, 13f, 10.5f, 8f, 10f, 9f, 1f, 0f));
        Teeth.Add(new Tooth("Sağ Alt 1. Molar", GameObject.Find("d14"), GameObject.Find("DownTeethRightMolar.3"), 7.5f, 14f, 11f, 9f, 10.5f, 9f, 1f, 0f));
        Teeth.Add(new Tooth("Sağ Alt 2. Premolar", GameObject.Find("d13"), GameObject.Find("DownTeethRightPremolar.1"), 8f, 14.5f, 7f, 5f, 8f, 7f, 1f, 0f));
        Teeth.Add(new Tooth("Sağ Alt 1.Premolar", GameObject.Find("d12"), GameObject.Find("DownTeethRightPremolar.2"), 8.5f, 13.5f, 7f, 5f, 7.5f, 6.5f, 1f, 0f));
        Teeth.Add(new Tooth("Sağ Alt Kanin", GameObject.Find("d11"), GameObject.Find("DownTeethRightCanine.1"), 11f, 16f, 7f, 5.5f, 7.5f, 7f, 2.5f, 1f));
        Teeth.Add(new Tooth("Sağ Alt Lateral", GameObject.Find("d10"), GameObject.Find("DownTeethRightIncisor.1"), 9.5f, 14f, 5.5f, 4f, 6.5f, 5.5f, 3f, 2f));
        Teeth.Add(new Tooth("Sağ Alt Santral", GameObject.Find("d9"), GameObject.Find("DownTeethRightIncisor.2"), 9f, 12.5f, 5f, 3.5f, 6f, 5.3f, 3f, 2f));
        Teeth.Add(new Tooth("Sol Alt Santral", GameObject.Find("d8"), GameObject.Find("DownTeethLeftIncisor.2"), 9f, 12.5f, 5f, 3.5f, 6f, 5.3f, 3f, 2f));
        Teeth.Add(new Tooth("Sol Alt Lateral", GameObject.Find("d7"), GameObject.Find("DownTeethLeftIncisor.1"), 9.5f, 14f, 5.5f, 4f, 6.5f, 5.5f, 3f, 2f));
        Teeth.Add(new Tooth("Sol Alt Kanin", GameObject.Find("d6"), GameObject.Find("DownTeethLeftCanine.1"), 11f, 16f, 7f, 5.5f, 7.5f, 7f, 2.5f, 1f));
        Teeth.Add(new Tooth("Sol Alt 2. Premolar", GameObject.Find("d5"), GameObject.Find("DownTeethLeftPremolar.2"), 8.5f, 13.5f, 7f, 5f, 7.5f, 6.5f, 1f, 0f));
        Teeth.Add(new Tooth("Sol Alt 1. Premolar", GameObject.Find("d4"), GameObject.Find("DownTeethLeftPremolar.1"), 8f, 14.5f, 7f, 5f, 8f, 7f, 1f, 0f));
        Teeth.Add(new Tooth("Sol Alt 1. Molar", GameObject.Find("d3"), GameObject.Find("DownTeethLeftMolar.3"), 7.5f, 14f, 11f, 9f, 10.5f, 9f, 1f, 0f));
        Teeth.Add(new Tooth("Sol Alt 2. Molar", GameObject.Find("d2"), GameObject.Find("DownTeethLeftMolar.2"), 7f, 13f, 10.5f, 8f, 10f, 9f, 1f, 0f));
        Teeth.Add(new Tooth("Sol Alt 3. Molar", GameObject.Find("d1"), GameObject.Find("DownTeethLeftMolar.1"), 7f, 11f, 10f, 7.5f, 9.5f, 9f, 1f, 0f));

        Teeth.Add(new Tooth("Sağ Üst 3. Molar", GameObject.Find("u16"), GameObject.Find("UpTeethRightMolar.1"), 6f, 11f, 8.5f, 6.5f, 10f, 9.5f, 1f, 0f)); // sağ üst 3. molar
        Teeth.Add(new Tooth("Sağ Üst 2. Molar", GameObject.Find("u15"), GameObject.Find("UpTeethRightMolar.2"), 7f, 11f, 12f, 9f, 7f, 11f, 10f, 1f, 0.1f)); //sağ üst 2. molar
        Teeth.Add(new Tooth("Sağ Üst 1. Molar", GameObject.Find("u14"), GameObject.Find("UpTeethRightMolar.3"), 7.5f, 12f, 13f, 10f, 8f, 11f, 10f, 1f, 0.1f)); //sağ üst 1. molar
        Teeth.Add(new Tooth("Sağ Üst 2. Premolar", GameObject.Find("u13"), GameObject.Find("UpTeethRightPremolar.1"), 8.2f, 14f, 7f, 5f, 9f, 8f, 1f, 0.1f)); //sağ üst 2. premolar
        Teeth.Add(new Tooth("Sağ Üst 1. Premolar", GameObject.Find("u12"), GameObject.Find("UpTeethRightPremolar.2"), 8.5f, 14f, 7f, 5f, 9f, 8f, 1f, 0.2f)); //sağ üst 1. premolar
        Teeth.Add(new Tooth("Sağ Üst Kanin", GameObject.Find("u11"), GameObject.Find("UpTeethRightCanine.1"), 10f, 17f, 7.5f, 5.5f, 8f, 7f, 2.5f, 1.5f)); //sağ üst kanin
        Teeth.Add(new Tooth("Sağ Üst Lateral", GameObject.Find("u10"), GameObject.Find("UpTeethRightIncisor.1"), 9f, 13f, 6.5f, 5f, 6f, 5f, 3f, 2f)); //sağ üst lateral
        Teeth.Add(new Tooth("Sağ Üst Santral", GameObject.Find("u9"), GameObject.Find("UpTeethRightIncisor.2"), 10.5f, 13f, 8.5f, 7f, 7f, 6f, 3.5f, 2.5f)); //sağ üst santral
        Teeth.Add(new Tooth("Sol Üst Santral", GameObject.Find("u8"), GameObject.Find("UpTeethLeftIncisor.2"), 10.5f, 13f, 8.5f, 7f, 7f, 6f, 3.5f, 2.5f)); //sol üst santal
        Teeth.Add(new Tooth("Sol Üst Lateral", GameObject.Find("u7"), GameObject.Find("UpTeethLeftIncisor.1"), 9f, 13f, 6.5f, 5f, 6f, 5f, 3f, 2f)); //sol üst lateral
        Teeth.Add(new Tooth("Sol Üst Kanin", GameObject.Find("u6"), GameObject.Find("UpTeethLeftCanine.1"), 10f, 17f, 7.5f, 5.5f, 8f, 7f, 2.5f, 1.5f)); //sol üst kanin
        Teeth.Add(new Tooth("Sol Üst 1. Premolar", GameObject.Find("u5"), GameObject.Find("UpTeethLeftPremolar.2"), 8.5f, 14f, 7f, 5f, 9f, 8f, 1f, 0.2f)); // sol üst 1. premolar
        Teeth.Add(new Tooth("Sol Üst 2. Premolar", GameObject.Find("u4"), GameObject.Find("UpTeethLeftPremolar.1"), 8.2f, 14f, 7f, 5f, 9f, 8f, 1f, 0.1f)); //sol üst 2. premolar
        Teeth.Add(new Tooth("Sol Üst 1. Molar", GameObject.Find("u3"), GameObject.Find("UpTeethLeftMolar.3"), 7.5f, 12f, 13f, 10f, 8f, 11f, 10f, 1f, 0.1f)); //sol üst 1. molar
        Teeth.Add(new Tooth("Sol Üst 2. Molar", GameObject.Find("u2"), GameObject.Find("UpTeethLeftMolar.2"), 7f, 11f, 9f, 12f, 7f, 11f, 10f, 1f, 0.1f)); //sol üst 2. molar
        Teeth.Add(new Tooth("Sol Üst 3. Molar", GameObject.Find("u1"), GameObject.Find("UpTeethLeftMolar.1"), 6f, 11f, 8.5f, 6.5f, 10f, 9.5f, 1f, 0)); //sol üst 3. molar

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
            
            if(dokunma.phase == TouchPhase.Moved || dokunma.phase ==TouchPhase.Stationary){
                rotation = Quaternion.Euler(0f, - dokunma.deltaPosition.x / speedRotation, 0f);
                if(mouth.activeSelf){
                    mouth.transform.rotation = rotation * mouth.transform.rotation;
                    if(mouth.transform.eulerAngles.y > 245f){ mouth.transform.rotation = Quaternion.Euler(0f, 245, 0f); }
                    else if(mouth.transform.eulerAngles.y < 115f){ mouth.transform.rotation = Quaternion.Euler(0f, 115, 0f); }
                }
            }
            
            else
            {
                if (Physics.Raycast(kamera.ScreenPointToRay(dokunma.position), out dokunulanNesne))
                {
                    for (i = 0; i < Teeth.Count; i++)
                    {
                        Teeth[i].GetToothInMouth().transform.GetComponent<Renderer>().material = defaultMaterial;
                        Teeth[i].GetTooth().transform.localEulerAngles = new Vector3(90, 0, 0);
                        Teeth[i].GetTooth().SetActive(false);

                        if (dokunulanNesne.collider.gameObject == Teeth[i].GetToothInMouth())
                        {
                            Teeth[i].GetTooth().SetActive(true);
                            displaybutton.SetActive(true);
                            dokunulanNesne.transform.GetComponent<Renderer>().material = highlightMaterial;
                            title.GetComponent<TMPro.TextMeshProUGUI>().text = Teeth[i].GetName();
                            if (Teeth[i].GetPalatinalKokBoyu() != 0f){
                                description.GetComponent<TMPro.TextMeshProUGUI>().text = "Kuron Boyu : " + Teeth[i].GetKuronBoyu() + "mm\nBukkal Kök Boyu : " + Teeth[i].GetBukkalKokBoyu() + "mm\nPalatinal Kök Boyu : " + Teeth[i].GetPalatinalKokBoyu() + "mm\nKuron Genişliği : " + Teeth[i].GetKuronGenisligi() + "mm\nKuron Genişliği (Kolede) : " + Teeth[i].GetKuronGenisligiKole() + "mm\nKuron Kalınlığı : " + Teeth[i].GetKuronKalinligi() + "mm\nKuron Kalınlığı (Kolede) : " + Teeth[i].GetKuronKalinligiKole() + "mm\nServikal Çizgisi Mesial Eğim : " + Teeth[i].GetMesialEgim() + "mm\nServikal Çizgisi Distal Eğim : " + Teeth[i].GetDistalEgim()+"mm";
                            }
                            else{
                                description.GetComponent<TMPro.TextMeshProUGUI>().text = "Kuron Boyu : " + Teeth[i].GetKuronBoyu() + "mm\nKök Boyu : " + Teeth[i].GetKokBoyu() + "mm\nKuron Genişliği : " + Teeth[i].GetKuronGenisligi() + "mm\nKuron Genişliği (Kolede) : " + Teeth[i].GetKuronGenisligiKole() + "mm\nKuron Kalınlığı : " + Teeth[i].GetKuronKalinligi() + "mm\nKuron Kalınlığı (Kolede) : " + Teeth[i].GetKuronKalinligiKole() + "mm\nServikal Çizgisi Mesial Eğim : " + Teeth[i].GetMesialEgim() + "mm\nServikal Çizgisi Distal Eğim : " + Teeth[i].GetDistalEgim()+"mm";
                            }
                        }
                    }
                }
            }
        }
    }

    void ChangeCameraTransform()
    {
        kameraanimator = GameObject.Find("Main Camera").GetComponent<Animator>();
        kameraanimator.SetBool("Open", true);
    }
    void OpenMouth()
    {
        mouthanimator.SetBool("Open", true);
        ChangeCameraTransform();
    }
}