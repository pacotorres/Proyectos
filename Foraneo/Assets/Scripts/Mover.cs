using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    private Rigidbody rig;
    public float speed = 20f;

    void Awake()
    {
        //Hacemos referencia Rigidbody para controlar el objeto 
        rig = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start () {
        rig.velocity = transform.forward * speed;
	}
	
}
