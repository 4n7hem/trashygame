using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DamagingObject : MonoBehaviour {
	public Force force = Force.ENEMY;
	public int Loss = 1;
}
