using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirObjetos : MonoBehaviour {

    //OnTriggerEnter: Cuando otro collider entra en contacto
    //OnTriggerStay: Cuando un collider permanece en contacto
    //OnTriggerExit: Cuando un collider deja de estar en contacto

    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }

}
