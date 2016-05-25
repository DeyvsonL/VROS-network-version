using UnityEngine;
using System.Collections;


public class SmoothFollow : MonoBehaviour {
    //inspector variables
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float speed;

    //private variables
    private Vector3 offset;
	

    protected virtual void Awake() {
        offset = transform.position;
    }

	// Update is called once per frame
	protected virtual void Update () {
        if (target == null) return;

        Vector3 finalPosition = target.position + offset;
        
        transform.position = Vector3.Slerp(transform.position, finalPosition, speed * Time.deltaTime);


	}
}
