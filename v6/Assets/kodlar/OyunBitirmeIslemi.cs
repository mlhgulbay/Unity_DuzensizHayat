using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyunBitirmeIslemi : MonoBehaviour
{
    string oyunBitirmeSebebi = null;
    bool oyunBitsinMi = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (oyunBitsinMi)
        {
            if (oyunBitirmeSebebi == "Dusman") DusmanCarpti();
            if (oyunBitirmeSebebi == "Bitis") BitiseGeldi();
        }
    }

    public IEnumerator OyunuBitir(string oyunBitirmeSebebi,bool oyunBitsinMi, int zaman)
    {
        yield return new WaitForSeconds(zaman);
        this.oyunBitirmeSebebi = oyunBitirmeSebebi;
        this.oyunBitsinMi = oyunBitsinMi;
    }

    void DusmanCarpti()
    {
        Application.LoadLevel("kaybetme");
    }

    void BitiseGeldi()
    {
        Application.LoadLevel("kazanma");
    }
}
