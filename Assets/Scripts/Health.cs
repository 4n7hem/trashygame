using UnityEngine;

public class Health : MonoBehaviour {
	[SerializeField]
	private Force _force;
	public int maxHealth;
	private int _health;
	public float destroyTime;
	public int health {
		get {return _health;}
		set {
			_health = value;
			if (_health > maxHealth) health = maxHealth;
			if (value <= 0) Die();
		}
	}
	public Force force {get {return _force;}}

	void Awake() {
		health = maxHealth;
	}

	void OnTriggerEnter2D(Collider2D col) {
		DamagingObject DO = col.GetComponent<DamagingObject>();
		if (DO != (null) && col.tag !="Enemy Attack" && col.tag !="Player") {
			this.health -= DO.Loss;
		}
	}

	public void Die() {
		Destroy(this.gameObject, destroyTime);
	}
}

public enum Force {
	PLAYER,
	ENEMY
}
