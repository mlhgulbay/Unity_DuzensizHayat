using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolumYoneticisi : MonoBehaviour
{
   public void BolumAc(string BolumIsmi)
   {
       Application.LoadLevel(BolumIsmi);// "BolumIsmi" değişkeninde yazan Sahne ismini yükler. Yani Örneğin "baslangic" sayfasını (sahnesini,schene) açar
   }


    public void Cikis()
    {
        Application.Quit(); // Uygulamayı kapatır. Bu kodun çalışıp uygulamanın kapanabilmesi için derlenmiş (.exe) uygulamasında denemek lazım.
                            // Unity geliştirici mod olduğu için Application.Quit komutu çalışmayacaktır.
    }
}
