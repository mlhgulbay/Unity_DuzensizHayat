using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GucYonetimi : MonoBehaviour
{
    YolKontrolcusu yolKontrolcusu;
    KarakterKontrolcusu karakterKontrolcusu;
    public GameObject gucKucuk;
    public GameObject gucBuyuk;

    public float karakterGucu = 2.0F;
    Text karakterGucuText;
    // Start is called before the first frame update
    void Start()
    {
        yolKontrolcusu = gameObject.GetComponent<YolKontrolcusu>();
        karakterKontrolcusu = gameObject.GetComponent<KarakterKontrolcusu>();
        karakterGucuText = GameObject.Find("Guc").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (karakterKontrolcusu.animasyonHizi >= 1)
        {
            karakterGucu = (karakterGucu > 0) ? (karakterGucu - Time.deltaTime) : 0;
        }
        karakterGucuText.text = "Güç : " + karakterGucu.ToString();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GucKucuk")
        {
            karakterGucu += 1;
            Destroy(other.gameObject);
        }
        if (other.tag == "GucBuyuk")
        {
            karakterGucu += 1.2f;
            Destroy(other.gameObject);
        }
        
    }
}
