using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoDestructor : MonoBehaviour {

    public GameObject explosion;
    public GameObject jugadorexplosion;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DestructorObj") return;
        Instantiate(explosion,transform.position,transform.rotation);
        if (other.CompareTag("Player"))
        {
            Instantiate(jugadorexplosion, other.transform.position, other.transform.rotation);
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
    }

}
