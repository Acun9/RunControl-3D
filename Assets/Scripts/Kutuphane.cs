using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Acun
{
    public class Matematik�slemleri : MonoBehaviour
    {
        public static void Carpma(int gelenSayi, List<GameObject> Karakterler, List<GameObject> OlusmaEfektleri, Transform pozisyon)
        {
            int donguSayisi = (GameManager.AnlikKarakterSayisi * gelenSayi) - GameManager.AnlikKarakterSayisi;
            int sayi = 0;
            foreach (var item in Karakterler)
            {
                if (sayi < donguSayisi)
                {
                    if (!item.activeInHierarchy)
                    {
                        foreach (var item1 in OlusmaEfektleri)
                        {
                            if (!item1.activeInHierarchy)
                            {
                                item1.SetActive(true);
                                item1.transform.position = pozisyon.position;
                                item1.GetComponent<ParticleSystem>().Play();
                                break;
                            }
                        }
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
        public static void Toplama(int gelenSayi, List<GameObject> Karakterler, List<GameObject> OlusmaEfektleri, Transform pozisyon)
        {
            int sayi = 0;
            foreach (var item in Karakterler)
            {
                if (sayi < gelenSayi)
                {
                    if (!item.activeInHierarchy)
                    {
                        foreach (var item1 in OlusmaEfektleri)
                        {
                            if (!item1.activeInHierarchy)
                            {
                                item1.SetActive(true);
                                item1.transform.position = pozisyon.position;
                                item1.GetComponent<ParticleSystem>().Play();
                                break;
                            }
                        }
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
        public static void Cikartma(int gelenSayi, List<GameObject> Karakterler, List<GameObject> YokOlmaEfektleri)
        {
            if (GameManager.AnlikKarakterSayisi <= gelenSayi)
            {
                foreach (var item in Karakterler)
                {

                    foreach (var item1 in YokOlmaEfektleri)
                    {
                        if (!item1.activeInHierarchy)
                        {
                            Vector3 yeniPoz = new Vector3(item.transform.position.x, .23f, item.transform.position.z);
                            item1.SetActive(true);
                            item1.transform.position = yeniPoz;
                            item1.GetComponent<ParticleSystem>().Play();
                            break;
                        }
                    }

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
                            foreach (var item1 in YokOlmaEfektleri)
                            {
                                if (!item1.activeInHierarchy)
                                {
                                    Vector3 yeniPoz = new Vector3(item.transform.position.x, .23f, item.transform.position.z);
                                    item1.SetActive(true);
                                    item1.transform.position = yeniPoz;
                                    item1.GetComponent<ParticleSystem>().Play();
                                    break;
                                }
                            }

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
        public static void Bolme(int gelenSayi, List<GameObject> Karakterler, List<GameObject> YokOlmaEfektleri)
        {
            if (GameManager.AnlikKarakterSayisi <= gelenSayi)
            {
                foreach (var item in Karakterler)
                {
                    foreach (var item1 in YokOlmaEfektleri)
                    {
                        if (!item1.activeInHierarchy)
                        {
                            Vector3 yeniPoz = new Vector3(item.transform.position.x, .23f, item.transform.position.z);
                            item1.SetActive(true);
                            item1.transform.position = yeniPoz;
                            item1.GetComponent<ParticleSystem>().Play();
                            break;
                        }
                    }
                    item.transform.position = Vector3.zero;
                    item.SetActive(false);
                }
                GameManager.AnlikKarakterSayisi = 1;
                Debug.Log(GameManager.AnlikKarakterSayisi);

            }
            else
            {   
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
                            foreach (var item1 in YokOlmaEfektleri)
                            {
                                if (!item1.activeInHierarchy)
                                {
                                    Vector3 yeniPoz = new Vector3(item.transform.position.x, .23f, item.transform.position.z);
                                    item1.SetActive(true);
                                    item1.transform.position = yeniPoz;
                                    item1.GetComponent<ParticleSystem>().Play();
                                    break;
                                }
                            }
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
