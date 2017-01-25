using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSystem : MonoBehaviour {
	public GameObject emitter;
	public float waittime = 1.0f;
	// Use this for initialization
	void Start () {
		//Create Emitterを1.0秒後に呼び出す
		Invoke("CreateEmitter", waittime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void CreateEmitter(){
		Instantiate (emitter, emitter.transform.position, emitter.transform.rotation);
	}
}
