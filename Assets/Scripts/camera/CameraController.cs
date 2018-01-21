using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour {

	public CameraTarget cameraTarget;

    [HideInInspector]
    public Camera cameraComponent;

	void Start() {
		cameraComponent = GetComponent<Camera>();
        cameraTarget = GameObject.Find("GameObject").GetComponent<CameraDirector>().target.cameraTarget;
    }
    
	void Update () {
        float cameraFriction = 0.1f;
        Vector3 targetVector = cameraTarget.position - transform.position;
        transform.position += targetVector * cameraFriction;
    }

}
