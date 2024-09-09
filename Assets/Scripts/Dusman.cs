using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Dusman : MonoBehaviour
{
    public GameObject saldiriHedefi;
    NavMeshAgent navMesh;
    bool saldiriHali;

    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
    }
    public void AnimasyonTetikle()
    {
        GetComponent<Animator>().SetBool("Saldir", true);
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
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().YokOlmaEfektiOlustur(yeniPoz,false,true);
            gameObject.SetActive(false);
        }
    }
}
