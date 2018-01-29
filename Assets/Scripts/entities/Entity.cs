using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Entity : NetworkBehaviour
{
    public Camera cam;
    public GameObject graphics;
    protected Rigidbody rb;

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
	{
    }
}
