using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class DuckSpawn : MonoBehaviour {

    [SerializeField]
    public Duck duckPrefab;

    public float spawnTime = 0.1f;

    private float timer;

	// Use this for initialization
	void Start () {
        timer = 0;
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if(timer >= spawnTime && NetworkServer.active)
        {
            timer = 0;
            Duck duckClone = Instantiate(duckPrefab);
            duckClone.transform.position = transform.position + (transform.forward * 1.0f);
            duckClone.transform.rotation = transform.rotation;

            NetworkServer.Spawn(duckClone.gameObject);
        }
    }
}
