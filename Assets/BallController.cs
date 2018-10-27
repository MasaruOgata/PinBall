using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバーを表示するテキスト
    private GameObject gameoverText;

    //Score内のスクリプト参照用の変数
    GameObject refObject;


    ////衝突時にポイントを加算、タグでポイントを判別
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "SmallStarTag")
        {
            ScoreController Score1 = refObject.GetComponent<ScoreController>();
            Score1.UpdateScore(0);
        }
        else if (collision.gameObject.tag == "LargeStarTag")
        {
            ScoreController Score1 = refObject.GetComponent<ScoreController>();
            Score1.UpdateScore(1);
        }
        else if (collision.gameObject.tag == "SmallCloudTag")
        {
            ScoreController Score1 = refObject.GetComponent<ScoreController>();
            Score1.UpdateScore(2);
        }
        else if (collision.gameObject.tag == "SmallCloudTag")
        {
            ScoreController Score1 = refObject.GetComponent<ScoreController>();
            Score1.UpdateScore(3);
        }
    }
            /// 


            // Use this for initialization
    void Start () {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
        //ScoreControllerを取得
        refObject = GameObject.Find("Score");
	}
	
	// Update is called once per frame
	void Update () {
        //ボールが画面外に出た場合
        if(this.transform.position.z < this.visiblePosZ) {
            //GameOverTextにゲームオーバーを表示
            this.gameoverText.GetComponent<Text>().text = "GameOver";
        }
		
	}
}
