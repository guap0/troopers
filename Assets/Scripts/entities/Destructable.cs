using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Destructable : Entity
{
	[SyncVar]
	private bool _isDead = false;
	public bool isDead
	{
		get { return _isDead; }
		protected set { _isDead = value; }
	}
	[SerializeField]
	private int maxHealth = 100;

	[SyncVar]
	private int currentHealth = 100;

	[SerializeField]
	private Behaviour[] disableOnDeath;
	private bool[] wasEnabled;

	public void Setup() {
		wasEnabled = new bool[disableOnDeath.Length];
		for(int i = 0; i < disableOnDeath.Length; i++) {
			wasEnabled[i] = disableOnDeath[i].enabled;
		}

		SetDefaults();
	}

	void Update() {
		if(!isLocalPlayer) return;

		if(Input.GetKeyDown(KeyCode.K)) {
			RpcTakeDamage(50);
		}
	}

	public void SetDefaults() {
		isDead = false;
		currentHealth = maxHealth;

		// Reenable components
		for(int i = 0; i < disableOnDeath.Length; i++) {
			disableOnDeath[i].enabled = wasEnabled[i];
		}

		setColliderEnabled(true);
	}

	[ClientRpc]
	public void RpcTakeDamage(int value) {
		if(!isDead) {
			currentHealth -= value;
			Debug.Log(transform.name + " now has " + currentHealth + " health");

			if(currentHealth <= 0) {
				currentHealth = 0;
				Die();
			}
		}
	}

	private void setColliderEnabled(bool enabled) {
		Collider _collider = GetComponent<Collider>();
		if(_collider != null) {
			_collider.enabled = enabled;
		}
	}

	private void Die() {
		isDead = true;

		// Disable components
		for(int i = 0; i < disableOnDeath.Length; i++) {
			disableOnDeath[i].enabled = false;
		}

		setColliderEnabled(false);

		Debug.Log(transform.name + " has died");

		// Respawn
		StartCoroutine(Respawn());
	}

	private IEnumerator Respawn () {
		yield return new WaitForSeconds(GameManager.instance.config.respawnTime);

		SetDefaults();
		Transform _spawnPoint = NetworkManager.singleton.GetStartPosition();

		transform.position = _spawnPoint.position;
	}
}
