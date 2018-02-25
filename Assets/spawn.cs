using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour {

	public Transform player;

	// Use this for initialization
	void Start () {
		player.transform.position = new Vector3(System.Convert.ToInt32(Random.value), 66.3f, System.Convert.ToInt32(Random.value));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
