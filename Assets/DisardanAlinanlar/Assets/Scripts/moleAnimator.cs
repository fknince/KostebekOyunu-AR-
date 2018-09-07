using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moleAnimator : MonoBehaviour {
	private ParticleSystem dust;
	private GameObject moleHitAudio;
	private MoleTrackableEventHandler trackableHandler;

	// Use this for initialization
	void Start () {
		moleHitAudio = GameObject.Find ("ARCamera").transform.Find ("moleHitAudio").gameObject;
		dust = this.gameObject.transform.parent.transform.Find ("Dust").gameObject.GetComponent<ParticleSystem> ();
		trackableHandler = GameObject.Find ("ImageTarget").gameObject.GetComponent<MoleTrackableEventHandler> ();
		iTween.MoveBy (gameObject, iTween.Hash ("y", 0.1, "easeType", "easeInOutQuad", "speed", 3, "delay", Random.Range (0.3f, 5f),
			"onComplete", "animComplete_Down"));



		
	}

	
	// Function caled when animation below ground is complete
	public void animComplete_Down()
	{
		//only make the mole character visible if the trackable is visible.This is to avoid having the
		//mole character visible with no detected Trackable
		if (trackableHandler.trackableVisible ()) {
			this.gameObject.GetComponent<Renderer> ().enabled = true;
			this.gameObject.GetComponent<Collider> ().enabled = true;
		
		}
		iTween.MoveBy (gameObject, iTween.Hash ("y", -0.1, "easeType", "easeInOutQuad", "speed", 3, "delay", Random.Range (0.3f, 1f),
			"onComplete", "animComplete_Up"));


	}
	public void animComplete_Up()
	{
		iTween.MoveBy (gameObject, iTween.Hash ("y", 0.1, "easeType", "easeInOutQuad", "speed", 3, "delay", Random.Range (0.3f, 5f),
			"onComplete", "animComplete_Down"));

	}
	void OnCollisionEnter(Collision collision)
	{
		dust.Play ();
		moleHitAudio.GetComponent<AudioSource> ().Play ();
		this.gameObject.GetComponent<Renderer> ().enabled = false;
		this.gameObject.GetComponent<Collider> ().enabled = false;
	}
}
