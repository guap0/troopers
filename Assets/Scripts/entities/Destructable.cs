using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Destructable : Entity
{
	[SerializeField]
	private int maxHealth = 100;

	[SyncVar]
	private int currentHealth = 100;

	void Awake() {
		SetDefaults();
	}

	public void SetDefaults() {
		currentHealth = maxHealth;
	}

	public void TakeDamage(int value) {
		currentHealth -= value;
		Debug.Log(transform.name + " now has " + currentHealth + " health");
	}
}
