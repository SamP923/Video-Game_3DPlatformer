﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

	public Text scoreValue;
	public Text highScoreValue;

	// Use this for initialization
	void Start () {
		scoreValue.text = "score: " + GameManager.instance.score.ToString();
		highScoreValue.text = "high score: " + GameManager.instance.highScore.ToString();
	}
	
	// Update is called once per frame
	public void RestartGame () {
		SceneManager.LoadScene("level1");
		GameManager.instance.ResetGame();
	}
}
