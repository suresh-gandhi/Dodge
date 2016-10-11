using UnityEngine;
using System.Collections;

public class FallingBlock : MonoBehaviour {

	public Vector2 speedMinMax;

	float speed;
	float visibleHeightThreshold;

	// Use this for initialization
	void Start () {
		speed = Mathf.Lerp (speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercentage());
		visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y;
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.transform.Translate (Vector3.down * speed * Time.deltaTime, Space.Self); //The effect would be differnt if you would use Space.World.
		if(transform.position.y < visibleHeightThreshold){
			Destroy (gameObject);
		}
	}
}
