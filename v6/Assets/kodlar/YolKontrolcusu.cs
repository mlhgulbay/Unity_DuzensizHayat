using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class YolKontrolcusu : MonoBehaviour
{
    public GameObject[] level1;
    public GameObject level1Bitis;
    public GameObject[] dusmanlar;
    
    public int[] dusmanXAralik = { -3, 1 };
    public int[] dusmanZAralik = { 13, 30 };
    OyunBitirmeIslemi oyunBitirmeIslemi;
    KarakterKontrolcusu karakterKontrolcusu;
    GucYonetimi gucYonetimi;
    public float geriSayim = 10.0F;
    

    int dusman_sayisi = 2;
    Text geriSayimText;
    

    // Start is called before the first frame update
    void Start()
    {
        oyunBitirmeIslemi = gameObject.GetComponent<OyunBitirmeIslemi>();
        karakterKontrolcusu = gameObject.GetComponent<KarakterKontrolcusu>();
        gucYonetimi = gameObject.GetComponent<GucYonetimi>();
        geriSayimText = GameObject.Find("GeriSayim").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gucYonetimi.karakterGucu > 0 && karakterKontrolcusu.animasyonHizi>=1)
        {
            geriSayim = (geriSayim > 0) ? (geriSayim - Time.deltaTime) : 0;
            geriSayimText.text = geriSayim.ToString();
            if (geriSayim % 2 < 0.0118f)
            {
                dusman_sayisi++;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BitisCizgisi")
        {
            StartCoroutine(oyunBitirmeIslemi.OyunuBitir("Bitis", true, 1));//1 saniye sonra ölme sebebi "Dusman" olarak oyunu bitir (true)
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "YolunBasi")
        {
            if (geriSayim <= 0)
            {
                yeniYolEkle(level1Bitis, other);
            }
            else
            {
                GameObject yol = yeniYolEkle(level1[Random.Range(0, level1.Length)], other);
                yolaDusmanlariEkle(yol);
            }
        }

        if (other.tag == "YolunSonu")
        {
            Destroy(other.transform.parent.gameObject);
        }
    }

    private GameObject yeniYolEkle(GameObject eklenecekObje,Collider algilananCollider)
    {
        GameObject yol = Instantiate(eklenecekObje, algilananCollider.transform.parent.Find("yolun_sonu").position, algilananCollider.transform.parent.parent.rotation, algilananCollider.transform.parent.parent);
        yol.transform.position = new Vector3(yol.transform.position.x, 0, yol.transform.position.z);
        return yol;
    }

    private void yolaDusmanlariEkle(GameObject yol)
    {
        List<string> koordinatlar = new List<string>();
        int x = 0;
        int z = 0;
        for (int i = 0; i < dusman_sayisi; i++)
        {
            x = Random.Range(dusmanXAralik[0], dusmanXAralik[1] + 1);
            z = Random.Range(dusmanZAralik[0], dusmanZAralik[1] + 1);
            if (!koordinatlar.Contains(x.ToString()+","+z.ToString()))
            {
                GameObject dusman = Instantiate(dusmanlar[Random.Range(0, dusmanlar.Length)], yol.transform);
                dusman.transform.position = new Vector3(dusman.transform.position.x + x, 0, transform.position.z + z);
                koordinatlar.Add(x.ToString() + "," + z.ToString());
            }
        }
        bool listede_varmi = false;
        byte kacGucEklensin = 2;
        do
        {
            x = Random.Range(dusmanXAralik[0], dusmanXAralik[1] + 1);
            z = Random.Range(dusmanZAralik[0], dusmanZAralik[1] + 1);
            listede_varmi = koordinatlar.Contains(x.ToString() + "," + z.ToString());
            if (!listede_varmi)
            {
                GameObject guc = Instantiate(gucYonetimi.gucBuyuk, yol.transform);
                guc.transform.position = new Vector3(guc.transform.position.x + x + 0.6f, 2, transform.position.z + z);
                koordinatlar.Add(x.ToString() + "," + z.ToString());
                kacGucEklensin--;
            }
        } while (listede_varmi && kacGucEklensin>=0);
    }
}
