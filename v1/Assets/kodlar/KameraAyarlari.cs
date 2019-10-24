using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraAyarlari : MonoBehaviour
{
    public bool ArkaPlanRenkAktif = true;
    public static int[] ArkaPlanRGB = {0,0,0};

    private void Start()
    {
        if (ArkaPlanRenkAktif)
        {
            gameObject.GetComponent<Camera>().backgroundColor = new Color(ArkaPlanRGB[0], ArkaPlanRGB[1], ArkaPlanRGB[2]);
        }
    }
}
