using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(Player))]
public class PlayerScript : NetworkBehaviour {

    public Behaviour[] componentsToDisable;
    public Camera sceneCamera;

    [SerializeField]
    int remoteLayerName = 9;// "RemotePlayer";

    void Start()
    {
        if (!isLocalPlayer)
        {
            DisableComponents();
            AssignRemoteLayer();
        }
        else {
            // sceneCamera = Camera.main;
            // if (sceneCamera != null) {
            //     sceneCamera.gameObject.SetActive(false);
            // }
            Camera.main.gameObject.SetActive(false);
        }
    }

    public override void OnStartClient() {
        base.OnStartClient();

        string _netID = GetComponent<NetworkIdentity>().netId.ToString();
        Player _player = GetComponent<Player>();

        GameManager.RegisterPlayer(_netID, _player);
    }

    void DisableComponents() {
        for (int i = 0; i < componentsToDisable.Length; i++)
        {
            componentsToDisable[i].enabled = false;
        }
    }

    void AssignRemoteLayer() {
        gameObject.layer = remoteLayerName;
    }

    void OnDisable()
    {
        if (sceneCamera != null) {
            sceneCamera.gameObject.SetActive(true);
        }

        GameManager.UnRegisterPlayer(transform.name);
    }

}
