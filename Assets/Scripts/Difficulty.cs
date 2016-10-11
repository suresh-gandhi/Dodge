using UnityEngine;
using System.Collections;

public static class Difficulty {
	static float secondsToMaxDifficulty = 60.0f;

	public static float GetDifficultyPercentage(){
		//return 0;
		return Mathf.Clamp01 (Time.timeSinceLevelLoad / secondsToMaxDifficulty);
	}

}
