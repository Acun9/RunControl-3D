using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Acun;

public class GameManager : MonoBehaviour
{
    public GameObject VarisNoktasi;
    public static int AnlikKarakterSayisi = 1;

    public List<GameObject> Karakterler;
    public List<GameObject> OlusmaEfektleri;
    public List<GameObject> YokOlmaEfektleri;

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
                Matematik›slemleri.Carpma(gelenSayi, Karakterler, OlusmaEfektleri, pozisyon);                
                break;

            case "Toplama":
                Matematik›slemleri.Toplama(gelenSayi, Karakterler, OlusmaEfektleri, pozisyon);
                break;

            case "Cikartma":
                Matematik›slemleri.Cikartma(gelenSayi, Karakterler, YokOlmaEfektleri);                
                break;

            case "Bolme":
                Matematik›slemleri.Bolme(gelenSayi, Karakterler, YokOlmaEfektleri);
                break;
        }
    }
    public void YokOlmaEfektiOlustur(Vector3 pozisyon)
    {
        foreach (var item in YokOlmaEfektleri)
        {
            if (!item.activeInHierarchy)
            {
                item.transform.position = pozisyon;
                item.SetActive(true);
                item.GetComponent<ParticleSystem>().Play();
                AnlikKarakterSayisi--;
                break;
            }
        }
    }    
}
