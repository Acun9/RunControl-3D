using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdamLekesi : MonoBehaviour
{
    IEnumerator Start()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }

    //private void Start()
    //{
    //    StartCoroutine(Pasiflestir());
    //}
    //IEnumerator Pasiflestir()
    //{
    //    yield return new WaitForSeconds(3f);
    //    gameObject.SetActive(false);
    //}
}