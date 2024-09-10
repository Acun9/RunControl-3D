using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Karakter : MonoBehaviour
{
    public GameManager gameManager;
    public Kamera kamera;
    public bool karakterSonaGeldiMi;
    public GameObject karakterinGidecegiYer;

    private void FixedUpdate()
    {
        if (!karakterSonaGeldiMi)
            transform.Translate(Vector3.forward * .5f * Time.deltaTime);
    }

    void Update()
    {
        if (karakterSonaGeldiMi)
        {
            transform.position = Vector3.Lerp(transform.position, karakterinGidecegiYer.transform.position, .015f);

        }
        else
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (Input.GetAxis("Mouse X") < 0)
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - .1f, transform.position.y, transform.position.z), .3f);
                }
                if (Input.GetAxis("Mouse X") > 0)
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + .1f, transform.position.y, transform.position.z), .3f);
                }
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Carpma") || other.CompareTag("Toplama") || other.CompareTag("Cikartma") || other.CompareTag("Bolme"))
            gameManager.Adamyonetimi(other.tag, int.Parse(other.name), other.transform);
        else if (other.CompareTag("SonTetikleyici"))
        {
            kamera.kameraSonaGeldiMi = true;
            karakterSonaGeldiMi = true;
            gameManager.DusmanTetikle();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Direk") || 
            collision.gameObject.CompareTag("igneliKutu") || 
            collision.gameObject.CompareTag("PervaneIgneleri"))
        {
            if (transform.position.x < 0)            
                transform.position = new Vector3(transform.position.x + .2f, transform.position.y, transform.position.z);
            else
                transform.position = new Vector3(transform.position.x - .2f, transform.position.y, transform.position.z);

        }
    }
}
