using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Alt_karakter : MonoBehaviour
{
    NavMeshAgent navMesh;
    public GameManager gameManager;
    public GameObject VarisNoktasi;

    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
    }

    private void LateUpdate()
    {
        navMesh.SetDestination(VarisNoktasi.transform.position);
    }

    Vector3 PozisyonVer()
    {
        return new Vector3(transform.position.x, .23f, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("igneliKutu") || other.CompareTag("Testere") || other.CompareTag("PervaneIgneleri"))
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
        else if (other.CompareTag("BosKarakter"))
        {
            gameManager.Karakterler.Add(other.gameObject);
        }
    }
}
