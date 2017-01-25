using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	Spaceship spaceship;
	public int hp = 1;
	// Use this for initialization
	IEnumerator Start () {
		spaceship = GetComponent<Spaceship> ();
		spaceship.Move (transform.up * -1);

		if (spaceship.canShot == false) {
			yield break;
		}
		while (true) {
			foreach(Transform child in transform){
				Transform shotPosition = child.transform;
				spaceship.Shot (shotPosition);
			}
			yield return new WaitForSeconds (spaceship.shotDelay);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D c){
		string layerName = LayerMask.LayerToName (c.gameObject.layer);
		if (layerName == "Bullet(Player)") {
			Transform playerBulletTransform = c.transform.parent;
			Bullet bullet = playerBulletTransform.GetComponent<Bullet> ();
			hp = hp - bullet.power;

			Destroy (c.gameObject);
			if (hp <= 0) {
				spaceship.Explosion ();
				Destroy (gameObject);
			} else {
				spaceship.GetAnimator ().SetTrigger ("Damage");
			}
		}


	}
}
