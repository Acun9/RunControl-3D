using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Acun
{
    public class Matematik›slemleri : MonoBehaviour
    {
        public static void Carpma(int gelenSayi, List<GameObject> Karakterler, Transform pozisyon)
        {
            int donguSayisi = (GameManager.AnlikKarakterSayisi * gelenSayi) - GameManager.AnlikKarakterSayisi;
            int sayi = 0;
            foreach (var item in Karakterler)
            {
                if (sayi < donguSayisi)
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
            GameManager.AnlikKarakterSayisi *= gelenSayi;
            Debug.Log(GameManager.AnlikKarakterSayisi);

        }
        public static void Toplama(int gelenSayi, List<GameObject> Karakterler, Transform pozisyon)
        {
            int sayi = 0;
            foreach (var item in Karakterler)
            {
                if (sayi < gelenSayi)
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
            GameManager.AnlikKarakterSayisi += gelenSayi;
            Debug.Log(GameManager.AnlikKarakterSayisi);

        }
        public static void Cikartma(int gelenSayi, List<GameObject> Karakterler)
        {
            if (GameManager.AnlikKarakterSayisi <= gelenSayi)
            {
                foreach (var item in Karakterler)
                {
                    item.transform.position = Vector3.zero;
                    item.SetActive(false);
                }
                GameManager.AnlikKarakterSayisi = 1;
                Debug.Log(GameManager.AnlikKarakterSayisi);

            }
            else
            {
                int sayi = 0;
                foreach (var item in Karakterler)
                {
                    if (sayi < gelenSayi)
                    {
                        if (item.activeInHierarchy)
                        {
                            item.transform.position = Vector3.zero;
                            item.SetActive(false);
                            sayi++;
                        }
                    }
                    else
                    {
                        sayi = 0;
                        break;
                    }
                }
                GameManager.AnlikKarakterSayisi -= gelenSayi;
                Debug.Log(GameManager.AnlikKarakterSayisi);

            }
        }
        public static void Bolme(int gelenSayi, List<GameObject> Karakterler)
        {
            if (GameManager.AnlikKarakterSayisi <= gelenSayi)
            {
                foreach (var item in Karakterler)
                {
                    item.transform.position = Vector3.zero;
                    item.SetActive(false);
                }
                GameManager.AnlikKarakterSayisi = 1;
                Debug.Log(GameManager.AnlikKarakterSayisi);

            }
            else
            {   //17
                int bolum = GameManager.AnlikKarakterSayisi / gelenSayi;
                int kalan = GameManager.AnlikKarakterSayisi % gelenSayi;
                int donguSayisi = GameManager.AnlikKarakterSayisi - (bolum + kalan);
                int sayi = 0;
                foreach (var item in Karakterler)
                {
                    if (sayi < donguSayisi)
                    {
                        if (item.activeInHierarchy)
                        {
                            item.transform.position = Vector3.zero;
                            item.SetActive(false);
                            sayi++;
                        }
                    }
                    else
                    {
                        sayi = 0;
                        break;
                    }
                }
                GameManager.AnlikKarakterSayisi -= donguSayisi;
                Debug.Log(GameManager.AnlikKarakterSayisi);
            }
        }
    }

}

