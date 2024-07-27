using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject VarisNoktasi;
    public int AnlikKarakterSayisi = 1;

    public List<GameObject> Karakterler;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Adamyonetimi(string veri, Transform pozisyon)
    {
        switch (veri)
        {
            case "x2":
                int sayi = 0;
                foreach (var item in Karakterler)
                {
                    if (sayi < AnlikKarakterSayisi)
                    {
                        if (!item.activeInHierarchy)
                        {
                            item.transform.position = pozisyon.position;
                            item.SetActive(true);
                            sayi++;
                        }
                    }
                    else
                    {
                        sayi = 0;
                        break;
                    }
                }
                AnlikKarakterSayisi *= 2;
                break;

            case "+3":
                int sayi2 = 0;
                foreach (var item in Karakterler)
                {
                    if (sayi2 < 3)
                    {
                        if (!item.activeInHierarchy)
                        {
                            item.transform.position = pozisyon.position;
                            item.SetActive(true);
                            sayi2++;
                        }
                    }
                    else
                    {
                        sayi2 = 0;
                        break;
                    }
                }
                AnlikKarakterSayisi += 3;
                break;

            case "-4":

                if (AnlikKarakterSayisi <= 4)
                {
                    foreach (var item in Karakterler)
                    {
                        item.transform.position = Vector3.zero;
                        item.SetActive(false);
                    }
                    AnlikKarakterSayisi = 1;
                }
                else
                {
                    int sayi3 = 0;
                    foreach (var item in Karakterler)
                    {
                        if (sayi3 < 4)
                        {
                            if (item.activeInHierarchy)
                            {
                                item.transform.position = Vector3.zero;
                                item.SetActive(false);
                                sayi3++;
                            }
                        }
                        else
                        {
                            sayi3 = 0;
                            break;
                        }
                    }
                    AnlikKarakterSayisi -= 4;
                }
                break;

            case "/2":

                if (AnlikKarakterSayisi <= 2)
                {
                    foreach (var item in Karakterler)
                    {
                        item.transform.position = Vector3.zero;
                        item.SetActive(false);
                    }
                    AnlikKarakterSayisi = 1;                    
                }
                else
                {
                    int bolen = AnlikKarakterSayisi / 2;
                    int sayi4 = 0;
                    foreach (var item in Karakterler)
                    {
                        if (sayi4 < bolen)
                        {
                            if (item.activeInHierarchy)
                            {
                                item.transform.position = Vector3.zero;
                                item.SetActive(false);
                                sayi4++;
                            }
                        }
                        else
                        {
                            sayi4 = 0;
                            break;
                        }
                    }

                    //if (true)
                    //{

                    //}

                    AnlikKarakterSayisi /= 2;                    
                }
                break;
        }
    }
}
