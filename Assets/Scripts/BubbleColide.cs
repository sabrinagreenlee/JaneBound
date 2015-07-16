﻿using UnityEngine;
using System.Collections;
using Assets.Scripts.Util;

public class BubbleColide : MonoBehaviour
{
	private Rigidbody myBody;

	void Update ()
	{
		myBody = this.GetComponent<Rigidbody>();
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag != "Player" && col.gameObject.layer != 13){
			if(myBody)
			{
				//myBody.isKinematic = true;
				GameObject go = new GameObject();
				go.transform.position = this.transform.position;
				go.transform.parent = col.transform;

				FollowPoint _fp = this.GetComponent<FollowPoint>();
				_fp.FollowTransform = go.transform;
				_fp.enabled = true;
				Physics.IgnoreCollision(this.GetComponent<Collider>(), col.collider, true);

				Destroy (myBody);
				Destroy(this.GetComponent<Assets.Scripts.Util.VelocityInfo>());
				//this.transform.parent = go.transform;
			}
		}
	}
}
