using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Dusman : MonoBehaviour
{
    public GameObject saldiriHedefi;
    public GameManager gameManager;
    NavMeshAgent navMesh;
    bool saldiriHali;
    Animator animator;

    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
    public void AnimasyonTetikle()
    {
        animator.SetBool("Saldir", true);
        saldiriHali = true;
    }
    void LateUpdate()
    {
        if (saldiriHali)
            navMesh.SetDestination(saldiriHedefi.transform.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AltKarakter"))
        {
            Vector3 yeniPoz = new Vector3(transform.position.x, .23f, transform.position.z);
            gameManager.YokOlmaEfektiOlustur(yeniPoz,false,true);
            gameObject.SetActive(false);
        }
    }
}
