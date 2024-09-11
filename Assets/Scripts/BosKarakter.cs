using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BosKarakter : MonoBehaviour
{
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public Material atanacakMaterial;
    public GameObject VarisNoktasi;
    public NavMeshAgent navMesh;
    public Animator animator;
    public GameManager gameManager;
    bool carpti;

    private void LateUpdate()
    {
        if (carpti)
            navMesh.SetDestination(VarisNoktasi.transform.position);
    }
    Vector3 PozisyonVer()
    {
        return new Vector3(transform.position.x, .23f, transform.position.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AltKarakter") || other.CompareTag("Player"))
        {
            if (gameObject.CompareTag("BosKarakter"))
            {
                MaterialDegistirVeAnimasyonTetikle();
                carpti = true;
            }            
        }
        else if (other.CompareTag("igneliKutu") || other.CompareTag("Testere") || other.CompareTag("PervaneIgneleri"))
        {
            gameManager.YokOlmaEfektiOlustur(PozisyonVer());
            gameObject.SetActive(false);
        }
        else if (other.CompareTag("Balyoz"))
        {
            gameManager.YokOlmaEfektiOlustur(PozisyonVer(), true);
            gameObject.SetActive(false);
        }
        else if (other.CompareTag("Dusman"))
        {
            gameManager.YokOlmaEfektiOlustur(PozisyonVer(), false, false);
            gameObject.SetActive(false);
        }
    }
    void MaterialDegistirVeAnimasyonTetikle()
    {
        Material[] mats = skinnedMeshRenderer.materials;
        mats[0] = atanacakMaterial;
        skinnedMeshRenderer.materials = mats;
        animator.SetBool("Saldir", true);

        gameObject.tag = "AltKarakter";
        GameManager.AnlikKarakterSayisi++;
        Debug.Log(GameManager.AnlikKarakterSayisi);


    }
}
