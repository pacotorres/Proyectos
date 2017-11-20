using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour {

    public float tumble = 5f;
    private Rigidbody rig;

    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start () {
        rig.angularVelocity = Random.insideUnitSphere * tumble;
	}
	
}
