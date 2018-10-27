using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {
    //HingiJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

	// Use this for initialization
	void Start () {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
		
	}
	
	// Update is called once per frame
	void Update () {

        //左矢印キーを押したとき左フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag"){
            SetAngle(this.flickAngle);
        }
        //右矢印キーを押したとき右フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag"){
            SetAngle(this.flickAngle);
        }

        //矢印キーが離されたときフリッパーを元に戻す
        if(Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag") {
            SetAngle(this.defaultAngle);
        }
        if(Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag") {
            SetAngle(this.defaultAngle);
        }


        ///タッチに対応させる部分
        if (Input.touchCount > 0){

            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);

                //画面左半分をタッチしたら左のフリッパーを動かす
                if (touch.phase == TouchPhase.Began
                    && touch.position.x < Screen.width * 0.5f
                    && tag == "LeftFripperTag")
                {
                    SetAngle(this.flickAngle);
                }

                //画面右半分をタッチしたら右のフリッパーを動かす
                if (touch.phase == TouchPhase.Began
                    && touch.position.x > Screen.width * 0.5f
                    && tag == "RightFripperTag")
                {
                    SetAngle(this.flickAngle);
                }

                //画面から指を離したらフリッパーをもとに戻す
                if (touch.phase == TouchPhase.Ended
                    && touch.position.x < Screen.width * 0.5f
                    && tag == "LeftFripperTag")
                {
                    SetAngle(this.defaultAngle);
                }
                if (touch.phase == TouchPhase.Ended
                    && touch.position.x > Screen.width * 0.5f
                    && tag == "RightFripperTag")
                {
                    SetAngle(this.defaultAngle);
                }
            }
        }
            //
        ///
	}

    //フリッパーの傾きを設定
    public void SetAngle(float angle) {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
