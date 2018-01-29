using UnityEngine;
using UnityEngine.Networking;

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

        RegisterPlayer();
    }

    void Update() {
        print(Camera.current);
    }

    void RegisterPlayer() {
        string _ID = "Player" + GetComponent<NetworkIdentity>().netId;
        transform.name = _ID;
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
    }

}
