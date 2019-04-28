using UnityEngine;

public class Health : MonoBehaviour {
	public int maxHealth;
	private int _health;
	public int health {
		get {return _health;}
		set {
			_health = value;
			if (value <= 0) Die();
		}
	}

	void Awake() {
		health = maxHealth;
	}

	void OnTriggerEnter2D(Collider2D col) {
		DamagingObject DO = col.GetComponent<DamagingObject>();
		if (DO != (null)) {
			this.health -= DO.Loss;
		}
	}

	public void Die() {
		Destroy(this.gameObject);
	}
}
