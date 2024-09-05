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
    void AnimasyonTetikle()
    {
        GetComponent<Animator>().SetBool("Saldir",true);
        saldiriHali = true;
    }
    void LateUpdate()
    {
        if (saldiriHali)
        navMesh.SetDestination(saldiriHedefi.transform.position);
    }
}
