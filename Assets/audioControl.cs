using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioControl : MonoBehaviour {
	private AudioSource aSource;
	private MoleTrackableEventHandler trackableHandler;
	// Use this for initialization
	void Start () {
		aSource=gameObject.GetComponent<AudioSource>();
		trackableHandler = GameObject.Find ("ImageTarget").gameObject.GetComponent<MoleTrackableEventHandler> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (trackableHandler.trackableVisible () && !aSource.isPlaying)
			aSource.Play ();
		else if (!trackableHandler.trackableVisible () && aSource.isPlaying)
			aSource.Stop ();
			
		
	}
}
