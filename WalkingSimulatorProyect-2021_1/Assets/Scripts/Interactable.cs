using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
	public float radius = 0.73f;

	void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, radius);
	}
}
