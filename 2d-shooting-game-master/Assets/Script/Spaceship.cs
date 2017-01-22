using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Spaceship : MonoBehaviour {
	public float speed;

	//弾を鬱間隔
	public float shotDelay;
	public GameObject bullet;
	public bool canShot;
	public GameObject explosion;

	public void Explosion(){
		Instantiate (explosion, transform.position, transform.rotation);
	}

	public void Shot(Transform origin){
		Instantiate (bullet, origin.position, origin.rotation);
	}

	public void Move(Vector2 direction){
		GetComponent<Rigidbody2D> ().velocity = direction * speed;
	}

}
