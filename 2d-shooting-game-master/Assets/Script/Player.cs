using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	Spaceship spaceship;
	// Use this for initialization
	IEnumerator Start () {
		spaceship = GetComponent<Spaceship> ();
		while (true) {
			spaceship.Shot (transform);
			//ショット音を鳴らす
			GetComponent<AudioSource> ().Play ();

			//shotDelay秒待つ
			yield return new WaitForSeconds (spaceship.shotDelay);
		}
	}
	
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxisRaw ("Horizontal");
		float y = Input.GetAxisRaw ("Vertical");
		Vector2 direction = new Vector2 (x, y).normalized;
		spaceship.Move (direction);
		Clamp ();
	}

	//移動制限 unity5.2から改善されている（rigidbodyでの移動と併用可能）
	void Clamp(){
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
		Vector2 pos = transform.position;
		pos.x=Mathf.Clamp(pos.x,min.x,max.x);
		pos.y=Mathf.Clamp(pos.y,min.y,max.y);
		transform.position = pos;
	}
	void OnTriggerEnter2D(Collider2D c){
		string layerName = LayerMask.LayerToName (c.gameObject.layer);
		if (layerName == "Bullet(Enemy)") {
			Destroy (c.gameObject);
		}
		if(layerName=="Bullet(Enemy)" || layerName == "Enemy"){

			//Managerコンポーネントをシーン内から探して取得し、GameOverメソッドを呼び出す
			//FindObjectOfType<Manager>().GameOver();

			spaceship.Explosion ();
			Destroy (gameObject);
		}
			
	}
}
