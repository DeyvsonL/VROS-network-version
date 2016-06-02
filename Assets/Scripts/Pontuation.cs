using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Pontuation : NetworkBehaviour
{

    private int pontuation;
    public const int DEFAULT_PONTUATION_INCREASE = 1;

	// Use this for initialization
	void Start () {
        resetPontuation();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        //bool isMine = GetComponent<NetworkIdentity>().isMine;
        bool isMine = isLocalPlayer;
        if (isMine)
        {
            GUI.Box(new Rect(10, 10, 150, 100), "Pontuation: " + pontuation);
        }
    }

    public void changePontuation (int value)
    {
        pontuation += value;
    }

    public void resetPontuation()
    {
        pontuation = 0;
    }

    public int getPontuation()
    {
        return pontuation;
    }
}   
