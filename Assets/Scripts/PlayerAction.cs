using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(Player))]
public class PlayerAction : NetworkBehaviour {

    private const string PLAYER_TAG = "Player";

    Player player;

    [SerializeField]
    private LayerMask rayMask;

	// Use this for initialization
	void Start () {
        player = GetComponent<Player>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
	}

    [Client]
    void Shoot() {
        RaycastHit hit;
        player.aim.y = 0;
        if (Physics.Raycast(player.transform.position, player.aim, out hit, 100f, rayMask)) {
            print("we hit " + hit.collider.name);
            if(hit.collider.tag == PLAYER_TAG) {
                CmdPlayerShot(hit.collider.name);
            }
        }
    }

    [Command]
    void CmdPlayerShot (string ID) {
        Debug.Log(ID + "has been shot");
    }
}
