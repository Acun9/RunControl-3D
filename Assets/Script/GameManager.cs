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
        }
    }
}
