using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraAyarlari : MonoBehaviour
{
    public bool ArkaPlanRenkAktif = true; // bu class ı tanımladığımız cameranın ayarlar bölümünden belirlenen rengin çalışabilmesi için 
                                          // o cameraya eklenen bu class'ın bu özelliğine tıklanarak "false" seçeneği seçilmesi gerekir.
                                          // eğer o seçenek "true" ise bu class ın içinde yani alt satırda bulunan "ArkaPlanRGB" değişkeninde
                                          // belirlenen RGB kodlarında hangi renk tanımlandıysa otomatik olarak bu classı kullanan ve "ArkaPlanRenkAktif"
                                          // seçeneği true olan bütün kameralar aynı renge sahip olacaktır. Sebebi ise bu "ArkaPlanRGB" değişkeninin
                                          // static tanımlanmasıdır.

                                          // özet olarak burada tanımladığımız arkaplan rengi istenilen bütün sahnelerin kamera arkaplan rengini aynı yapmaktır.
    public static int[] ArkaPlanRGB = {0,0,0};

    private void Start()
    {
        if (ArkaPlanRenkAktif) 
        {
            gameObject.GetComponent<Camera>().backgroundColor = new Color(ArkaPlanRGB[0], ArkaPlanRGB[1], ArkaPlanRGB[2]);
            // eğer bu class ı kapsayan obje ye ait ArkaPlanRenkAktif değişkeni true ise mevcut objenin Component ini çekiyoruz yani özelliğini
            // peki nasıl çekiyoruz .GetComponent ile. Bu özellik nasıl kullanılıyor .GetComponent<Camera>() yani Camera özelliğine ulaştık
            // peki bu Camera özelliğine ulaşınca ne yapıyoruz .backgroundColor yani arka plan rengi ne bir renk tanımlıyoruz
            // gameObject in baş harfi küçük olacak şekilde gameObject.GetComponent<Camera>().backgroundColor = new Color()
            // atayacağımız renk Color Class tipinde olmalı. İçine de renk kodlarını değişkenimizden yerleştiriyoruz.
            // new Color(ArkaPlanRGB[0], ArkaPlanRGB[1], ArkaPlanRGB[2]);
            // yani
            // gameObject.GetComponent<Camera>().backgroundColor = new Color(ArkaPlanRGB[0], ArkaPlanRGB[1], ArkaPlanRGB[2]);
        }
    }
}
