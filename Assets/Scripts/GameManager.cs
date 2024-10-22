using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Acun;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public GameObject AnaKarakter;
    public static int AnlikKarakterSayisi = 1;

    public List<GameObject> Karakterler;
    public List<GameObject> OlusmaEfektleri;
    public List<GameObject> YokOlmaEfektleri;
    public List<GameObject> AdamLekesiEfektleri;

    [Header("=====> Level Verileri <=====")]
    public List<GameObject> Dusmanlar;
    public int DusmanSayisi;
    public bool OyunBittiMi;
    bool karakterSonaGeldiMi;

    Matematik›slemleri matematik›slemleri = new Matematik›slemleri();
    BellekYonetimi bellekYonetimi = new BellekYonetimi();
    void Start()
    {
        DusmanOlustur();
        Debug.Log(bellekYonetimi.VeriOku_int("Puan"));

    }
    public void DusmanOlustur()
    {
        for (int i = 0; i < DusmanSayisi; i++)
        {
            Dusmanlar[i].SetActive(true);
        }
    }
    public void DusmanTetikle()
    {
        foreach (var item in Dusmanlar)
        {
            if (item.activeInHierarchy)
            {
                item.GetComponent<Dusman>().AnimasyonTetikle();
            }
        }
        karakterSonaGeldiMi = true;
        SavasDurumu();
    }

    void Update()
    {

    }
    void SavasDurumu()
    {
        if (karakterSonaGeldiMi)
        {
            if (AnlikKarakterSayisi == 1 || DusmanSayisi == 0)
            {
                OyunBittiMi = true;
                foreach (var item in Dusmanlar)
                {
                    if (item.activeInHierarchy)
                    {
                        item.GetComponent<Animator>().SetBool("Saldir", false);
                    }
                }
                foreach (var item in Karakterler)
                {
                    if (item.activeInHierarchy)
                    {
                        item.GetComponent<Animator>().SetBool("Saldir", false);
                    }
                }

                AnaKarakter.GetComponent<Animator>().SetBool("Saldir", false);

                if (AnlikKarakterSayisi > DusmanSayisi)
                {
                    if (AnlikKarakterSayisi > 5)
                    {
                        bellekYonetimi.VeriKaydet_int("Puan", bellekYonetimi.VeriOku_int("Puan") + 600);
                    }
                    else
                    {
                        bellekYonetimi.VeriKaydet_int("Puan", bellekYonetimi.VeriOku_int("Puan") + 200);
                    }
                    Debug.Log("Kazandin.");
                    Debug.Log(bellekYonetimi.VeriOku_int("Puan"));
                }
                else
                {
                    Debug.Log("Kaybettin.");

                }
            }
        }
    }

    public void Adamyonetimi(string islemTuru, int gelenSayi, Transform pozisyon)
    {
        switch (islemTuru)
        {
            case "Carpma":
                matematik›slemleri.Carpma(gelenSayi, Karakterler, OlusmaEfektleri, pozisyon);
                break;

            case "Toplama":
                matematik›slemleri.Toplama(gelenSayi, Karakterler, OlusmaEfektleri, pozisyon);
                break;

            case "Cikartma":
                matematik›slemleri.Cikartma(gelenSayi, Karakterler, YokOlmaEfektleri);
                break;

            case "Bolme":
                matematik›slemleri.Bolme(gelenSayi, Karakterler, YokOlmaEfektleri);
                break;
        }
    }
    public void YokOlmaEfektiOlustur(Vector3 pozisyon, bool Balyoz = false, bool Durum = false)
    {
        foreach (var item in YokOlmaEfektleri)
        {
            if (!item.activeInHierarchy)
            {
                item.transform.position = pozisyon;
                item.SetActive(true);
                item.GetComponent<ParticleSystem>().Play();
                item.GetComponent<AudioSource>().Play();
                if (!Durum)
                    AnlikKarakterSayisi--;
                else
                    DusmanSayisi--;
                break;
            }
        }

        if (Balyoz)
        {
            Vector3 yeniPoz = new Vector3(pozisyon.x, .005f, pozisyon.z);
            foreach (var item in AdamLekesiEfektleri)
            {
                if (!item.activeInHierarchy)
                {
                    item.transform.position = yeniPoz;
                    item.SetActive(true);
                    break;
                }
            }
        }
        if (!OyunBittiMi)
        {
            SavasDurumu();
        }
    }
}
