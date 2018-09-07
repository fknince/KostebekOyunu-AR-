using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class MoleTrackableEventHandler : MonoBehaviour,ITrackableEventHandler{

	#region PRIVATE_MEMBER_VARIABLES
	private TrackableBehaviour mTrackableBehaviour;
	private bool TrackableStatus=false;
	#endregion PRIVATE_MEMBER_VARIABLES


	// Use this for initialization
	void Start () {

		mTrackableBehaviour = GetComponent<TrackableBehaviour> ();
		if (mTrackableBehaviour) {
			mTrackableBehaviour.RegisterTrackableEventHandler (this);
		}
		OnTrackingLost();

		
	}
	
	public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED || newStatus == TrackableBehaviour.Status.TRACKED) {
			TrackableStatus = true;
			OnTrackingFound ();
		
		} else 
		{
			TrackableStatus = false;
			OnTrackingLost ();
		
		}
	}
	public bool trackableVisible()
	{
		return TrackableStatus;
	}
	protected virtual void OnTrackingFound()
	{
		var rendererComponents = GetComponentsInChildren<Renderer>(true);
		var colliderComponents = GetComponentsInChildren<Collider>(true);
		var canvasComponents = GetComponentsInChildren<Canvas>(true);

		// Enable rendering:
		foreach (var component in rendererComponents)
			component.enabled = true;

		// Enable colliders:
		foreach (var component in colliderComponents)
			component.enabled = true;

		// Enable canvas':
		foreach (var component in canvasComponents)
			component.enabled = true;
	}


	protected virtual void OnTrackingLost()
	{
		var rendererComponents = GetComponentsInChildren<Renderer>(true);
		var colliderComponents = GetComponentsInChildren<Collider>(true);
		var canvasComponents = GetComponentsInChildren<Canvas>(true);

		// Disable rendering:
		foreach (var component in rendererComponents)
			component.enabled = false;

		// Disable colliders:
		foreach (var component in colliderComponents)
			component.enabled = false;

		// Disable canvas':
		foreach (var component in canvasComponents)
			component.enabled = false;
	}
}
