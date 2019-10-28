using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterSesleri : MonoBehaviour
{
    public AudioClip yuruyusSesi;
    public AudioClip kosmaSesi;
    public AudioClip ziplamaSesi;

    AudioClip mevcutAudioClip = null;

    AudioSource audioSource;
    KarakterKontrolcusu karakterKontrolcusu;


    // Bu Class tetiklendiğinde ilk ve tek çalışacak başlangıç fonksiyonu
    void Start()
    {
        karakterKontrolcusu = gameObject.GetComponent<KarakterKontrolcusu>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Zemin")// eğer "zemin" tag özelliğine sahip nesnenin üzerinde ise
        {
            KarakterZemineDegiyor();// AyakSesi fonksiyonu çalışsın
        }
    }

    void KarakterZemineDegiyor()
    {
        float hiz = karakterKontrolcusu.animasyonHizi; // karakterKontrolcusu class ın içindeki animasyonHizi değişkeninin değerini hafızaya aktarıyoruz.

        if (hiz > 0) // eğer bir hıza sahip ise
        {
            if (hiz > 0.5f) // eğer hızı yarının üstünde ise
            {
                mevcutAudioClip = kosmaSesi; // kosma sesi yap
            }
            else
            {
                mevcutAudioClip = yuruyusSesi; // yürüme sesi yap
            }

        }
        else // eğer bir hıza sahip değil ise ve Space tuşuna basılmadı ise
        {
            mevcutAudioClip = null; // sesi yok et
        }

        if (Input.GetKeyDown(KeyCode.Space))mevcutAudioClip = ziplamaSesi; // zıpladıysa sesi güncelle

        if (audioSource.clip != mevcutAudioClip) // eğer o an çalan clip ile mevcut değişen ses aynı değil ise
        {
            SesKlibiniTetiklet(mevcutAudioClip); // sesi güncelle
        }
    }

    void SesKlibiniTetiklet(AudioClip clip) // AudioClip türünde gelen ses
    {
        audioSource.clip = clip;  // audioSource componentinin clip özelliğini, gelen clip e eşitle - yani çalacak sesi, istenilen ses yap
        audioSource.Stop();       // önce bitir
        audioSource.Play();       // sonra başlat
    }
}
