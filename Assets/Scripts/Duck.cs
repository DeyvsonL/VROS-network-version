using UnityEngine;
using System.Collections;

public class Duck : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;

    [SerializeField]
    private float maxAliveTime = 5.0f;

    private Rigidbody rigidBody;

    protected virtual void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    protected virtual void Start()
    {
        rigidBody.velocity = transform.forward * speed;
        Destroy(gameObject, maxAliveTime);
    }

}
