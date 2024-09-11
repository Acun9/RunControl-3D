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
    bool carpti;
   
    private void LateUpdate()
    {
        if (carpti)
            navMesh.SetDestination(VarisNoktasi.transform.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AltKarakter") || other.CompareTag("Player"))
        {
            MaterialDegistirVeAnimasyonTetikle();
            carpti = true;
        }
    }
    void MaterialDegistirVeAnimasyonTetikle()
    {
        Material[] mats = skinnedMeshRenderer.materials;
        mats[0] = atanacakMaterial;
        skinnedMeshRenderer.materials = mats;
        animator.SetBool("Saldir", true);
    }
}
