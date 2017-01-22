using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	Spaceship spaceship;
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
			Destroy (c.gameObject);
			spaceship.Explosion ();
			Destroy (gameObject);
		}


	}
}
