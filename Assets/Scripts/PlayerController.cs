using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private float halfScreenWidthInWorldUnits;
	private float playerWidth;

	public float speed = 7.0f;
	public event System.Action OnPlayerDeath;

	// Use this for initialization
	void Start () {
		halfScreenWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize;
		playerWidth = this.gameObject.transform.localScale.x / 2;
	}
	
	// Update is called once per frame
	void Update () {
		float inputX = Input.GetAxisRaw ("Horizontal");
		float velocity = inputX * speed;
		this.gameObject.transform.Translate (Vector2.right * velocity * Time.deltaTime);

		if (this.gameObject.transform.position.x < -(halfScreenWidthInWorldUnits + playerWidth)) {
			this.gameObject.transform.position = new Vector2 (halfScreenWidthInWorldUnits + playerWidth, transform.position.y);
		}

		if (this.gameObject.transform.position.x > (halfScreenWidthInWorldUnits + playerWidth)) {
			this.gameObject.transform.position = new Vector2 (-(halfScreenWidthInWorldUnits + playerWidth), transform.position.y);
		}
	}

	void OnTriggerEnter2D(Collider2D triggerCollider){ //This method is called automatically by the Unity Physics Engine.
		if(triggerCollider.tag == "Falling Block"){
			if (OnPlayerDeath != null) {
				OnPlayerDeath ();
			}
			Destroy (this.gameObject);
			//FindObjectOfType<GameOver> ().OnGameOver ();
		}
	}

}
