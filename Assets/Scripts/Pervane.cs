using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pervane : MonoBehaviour
{
    public Animator animator;
    public float beklemeSuresi;
    public BoxCollider ruzgar;

    public void AnimasyonDurum(string durum)
    {
        if (durum == "true")
        {
            animator.SetBool("Calistir", true);
            ruzgar.enabled = true;
        }                    
        else
        {
            animator.SetBool("Calistir", false);
            StartCoroutine(AnimasyonTetikle());
            ruzgar.enabled=false;
        }
            
    }
    IEnumerator AnimasyonTetikle()
    {
        yield return new WaitForSeconds(beklemeSuresi);
        AnimasyonDurum("true");
    } 
}
