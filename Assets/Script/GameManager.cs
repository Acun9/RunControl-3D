using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Acun;

public class GameManager : MonoBehaviour
{
    public GameObject VarisNoktasi;
    public static int AnlikKarakterSayisi = 1;

    public List<GameObject> Karakterler;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Adamyonetimi(string islemTuru, int gelenSayi, Transform pozisyon)
    {
        switch (islemTuru)
        {
            case "Carpma":
                Matematik›slemleri.Carpma(gelenSayi, Karakterler, pozisyon);                
                break;

            case "Toplama":
                Matematik›slemleri.Toplama(gelenSayi, Karakterler, pozisyon);
                break;

            case "Cikartma":
                Matematik›slemleri.Cikartma(gelenSayi, Karakterler);                
                break;

            case "Bolme":
                Matematik›slemleri.Bolme(gelenSayi, Karakterler);
                break;
        }
    }
}
