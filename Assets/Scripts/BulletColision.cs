using UnityEngine;
using System.Collections;

public class BulletColision : MonoBehaviour {
    public const string TAG_BULLET = "Bullet";
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    protected virtual void OnCollisionEnter(Collision collision)
    {
        GameObject player = collision.gameObject.GetComponent<OriginPlayer>().player;
        bool isBullet = collision.gameObject.tag == TAG_BULLET;
        
        if (isBullet)
        {
            Pontuation points = player.GetComponent<Pontuation>();
            points.changePontuation(Pontuation.DEFAULT_PONTUATION_INCREASE);
            Destroy(this.gameObject);
        }
    }
}
