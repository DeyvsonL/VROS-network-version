using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class changeCameraToVR : NetworkBehaviour
{
    public GameObject cameraVR;

	// Use this for initialization
	void Start () {

        Camera currentCamera = Camera.main;
        if (currentCamera != null)
        {
            currentCamera.gameObject.SetActive(false);
        }

        bool isMine = isLocalPlayer;
        if (isMine) {
            Camera currentCam = Camera.current;
            GameObject vrCam = (GameObject)Instantiate(cameraVR, transform.position, transform.rotation);
            transform.parent = vrCam.transform;
        }
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
