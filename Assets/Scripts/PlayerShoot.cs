using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(Unit))]
public class PlayerShoot : MonoBehaviour {
    Unit player;

    [SerializeField]
    private LayerMask rayMask;

	// Use this for initialization
	void Start () {
        player = GetComponent<Unit>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
	}

    void Shoot() {
        RaycastHit hit;
        player.aim.y = 0;
        if (Physics.Raycast(player.transform.position, player.aim, out hit, 100f, rayMask)) {
            print("we hit " + hit.collider.name);
        }
    }
}
