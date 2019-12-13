using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterDusmanIliskisi : MonoBehaviour
{
    Animator animator;
    KarakterKontrolcusu karakterKontrolcusu;
    OyunBitirmeIslemi oyunBitirmeIslemi;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        karakterKontrolcusu = gameObject.GetComponent<KarakterKontrolcusu>();
        oyunBitirmeIslemi = gameObject.GetComponent<OyunBitirmeIslemi>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Dusman")
        {
            animator.SetBool("olsun_mu", true);
            karakterKontrolcusu.KarakterKontrolEtme = false;
            StartCoroutine(oyunBitirmeIslemi.OyunuBitir("Dusman", true,4));//4 saniye sonra ölme sebebi "Dusman" olarak oyunu bitir (true)
        }
    }
}
