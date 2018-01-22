using UnityEngine;
using UnityEngine.Networking;

public class PlayerScript : NetworkBehaviour {

    public Behaviour[] componentsToDisable;
    public Camera sceneCamera;

    [SerializeField]
    string remoteLayerName = "RemoteLayer";

    void Start()
    {
        if (!isLocalPlayer)
        {
            DisableComponents();
            AssignRemoteLayer();
        }
        else {
            sceneCamera = Camera.main;
            if (sceneCamera != null) {
                sceneCamera.gameObject.SetActive(false);
            }
        }
    }

    void DisableComponents() {
        for (int i = 0; i < componentsToDisable.Length; i++)
        {
            componentsToDisable[i].enabled = false;
        }
    }

    void AssignRemoteLayer() {
        gameObject.layer = LayerMask.NameToLayer(remoteLayerName);
    }

    void OnDisable()
    {
        if (sceneCamera != null) {
            sceneCamera.gameObject.SetActive(true);
        }
    }

}
