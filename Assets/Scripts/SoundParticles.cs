using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundParticles : MonoBehaviour {

    public float particleLife = 10f;
    Rigidbody2D rbody;
    float birthTime;

    float forceIncrement;
    float forceTime;

	// Use this for initialization
	void Start () {
        birthTime = 0;
        forceTime = 0;
        rbody = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        //die when it has exceeded its life
        birthTime += Time.deltaTime;
        if( birthTime > particleLife)
        {
            Destroy(this.gameObject);
        }

	}

    private void FixedUpdate()
    {
        if (birthTime > forceTime)
        {
            rbody.AddForce(Random.insideUnitCircle);
            forceTime += forceIncrement;
        }
    }
}
