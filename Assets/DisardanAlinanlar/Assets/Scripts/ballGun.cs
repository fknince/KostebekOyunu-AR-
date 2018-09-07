using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballGun : MonoBehaviour {
	public GameObject projectile;
	public Transform projectilePlaceHolder;
	private GameObject ballFireAudio;
	private GameObject Trackable; 
	private MoleTrackableEventHandler trackableHandler;
	// Use this for initialization
	void Start () {
		ballFireAudio = this.gameObject.transform.Find ("ballFireAudio").gameObject;
		Trackable = GameObject.Find ("ImageTarget").gameObject;
		trackableHandler = GameObject.Find ("ImageTarget").gameObject.GetComponent<MoleTrackableEventHandler> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && trackableHandler.trackableVisible ()) {
			ballFireAudio.GetComponent<AudioSource> ().Play ();
			GameObject obj = Instantiate (projectile, projectilePlaceHolder.position, this.gameObject.transform.rotation) as GameObject;
			obj.gameObject.GetComponent<Rigidbody>().AddRelativeForce (Vector3.forward * Time.deltaTime*2000);
			obj.transform.parent = Trackable.transform;
			Destroy (obj.gameObject, 5f);
		}
	}
}
