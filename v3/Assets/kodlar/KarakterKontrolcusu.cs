using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterKontrolcusu : MonoBehaviour
{
    Animator animator;
    Transform transform;
    Rigidbody rigidbody;

    public float animasyonHizi = 0;
    public float animasyonHizDegisimi = 0.03f;

    float karakterHiziZ = 0;
    public float karakterHiziHassaslik = 0.09f;
    public float karakteriSolaSagaDonmeHassasligi = 0.1f;

    bool karakterYonlendirmeIzniDikey = true;
    bool karakterYonlendirmeIzniYatay = true;

    bool karakterZiplasinMi = true;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        transform = gameObject.GetComponent<Transform>();
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (karakterYonlendirmeIzniDikey)
        {
            if (Input.GetKey(KeyCode.W)) Karakteri_z_yonunde_ileriye_ayarla();              // 1---1

            if (Input.GetKey(KeyCode.S)) Karakteri_z_yonunde_yavaslamaya_ayarla();          // 1---2
        }

        if (karakterYonlendirmeIzniYatay)
        {
            if (Input.GetKey(KeyCode.A)) KarakteriSolaGotur();                              // 1---3

            if (Input.GetKey(KeyCode.D)) KarakteriSagaGotur();                              // 1---4
        }

        if (Input.GetKey(KeyCode.T)) KaraktereDansEttir();                                  // 1---5

        if (Input.GetKeyDown("space")) KarakteriZiplat();                                   // 1---6

        Karakteri_z_yonunde_hareketlendir();                                                // 2+++1
        Karakterin_rotasyonunu_sabit_tut();                                                 // 2+++2
    }

    /****************************************************************************************************************/

    // 2+++1
    void Karakteri_z_yonunde_hareketlendir()
    {
        transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z+karakterHiziZ);
    }

    /****************************************************************************************************************/

    // 2+++2
    void Karakterin_rotasyonunu_sabit_tut()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    /****************************************************************************************************************/

    // 3***1
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Zemin")
        {
            karakterZiplasinMi = true;
        }
    }

    /****************************************************************************************************************/

    // 3***1
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Zemin")
        {
            karakterZiplasinMi = false;
        }
    }

    /****************************************************************************************************************/

    // 1---1
    void Karakteri_z_yonunde_ileriye_ayarla()
    {
        AnimasyonHiziniArttir();    //1---1---1
        KarakterHiziniGuncelle();   //1---7
    }

    // karakterin animasyonu, animatorController da 0 ile 1 arasında tanımlandığı için en fazla 1 olabilir
    void AnimasyonHiziniArttir()    //1---1---1
    {
        animasyonHizi += animasyonHizDegisimi;
        if (animasyonHizi > 1) animasyonHizi = 1;
        animator.SetFloat("dur_yuru_kos", animasyonHizi);
    }

    /****************************************************************************************************************/

    // 1---2
    void Karakteri_z_yonunde_yavaslamaya_ayarla()
    {
        AnimasyonHiziniAzalt();    //1---2---1
        KarakterHiziniGuncelle();  //1---7
    }

    // karakterin animasyonu, animatorController da 0 ile 1 arasında tanımlandığı için en az 0 olabilir
    void AnimasyonHiziniAzalt()    //1---2---1
    {
        animasyonHizi -= animasyonHizDegisimi;
        if (animasyonHizi < 0) animasyonHizi = 0;
        animator.SetFloat("dur_yuru_kos", animasyonHizi);
    }

    /****************************************************************************************************************/

    // 1---3
    void KarakteriSolaGotur()
    {
        transform.position = new Vector3(transform.position.x - karakteriSolaSagaDonmeHassasligi, transform.position.y, transform.position.z);
    }

    /****************************************************************************************************************/

    // 1---4
    void KarakteriSagaGotur()
    {
        transform.position = new Vector3(transform.position.x + karakteriSolaSagaDonmeHassasligi, transform.position.y, transform.position.z);
    }

    /****************************************************************************************************************/

    // 1---5
    void KaraktereDansEttir()
    {
        animator.SetTrigger("dans_etsin_mi");
    }

    /****************************************************************************************************************/

    // 1---6
    void KarakteriZiplat()
    {
        if (karakterZiplasinMi)
        {
            animator.SetTrigger("ziplasin_mi");
            rigidbody.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
        }
    }

    /****************************************************************************************************************/

    //1---7
    void KarakterHiziniGuncelle()  
    {
        karakterHiziZ = animasyonHizi * karakterHiziHassaslik;
    }
    
    /****************************************************************************************************************/
    
}
