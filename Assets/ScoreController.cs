using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    
    private int score;
    private GameObject ScoreText;
    //各ターゲットの点数
    int[] points = { 10, 20, 30, 40 };

    public void UpdateScore(int i){
        //Scoreの更新
        this.score += points[i];
    }

    // Use this for initialization
    void Start() {
        //シーン中からScoreのテキストを取得
        this.ScoreText = GameObject.Find("Score");
        //scoreの初期化
        this.score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        this.ScoreText.GetComponent<Text>().text = "Score:" + this.score;
	}
}
