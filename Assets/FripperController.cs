using UnityEngine;
using System.Collections;

public class FripperController : MonoBehaviour
{
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    // Use this for initialization
    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {

        //左右の矢印キーを押した時、左右のフリッパーを動かす
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //矢印キー離された時フリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }

        //↓メンタリングの解説

        // １、指が触れている場合にタッチ情報を取得して処理をしなければならない。

        // ２、myTouch.phase = TouchPhase.Began; ⇨ phase変数は分岐をするための条件で使用する。

        // if (myTouch.phase == TouchPhase.Began) {

        // } else if (myTouch.phase == TouchPhase.Ended) {

        // }

        // ３、左右のタッチを判定するにはmyTouch.position.x変数を使用する。

        // if (myTouch.position.x > Screen.Width * 0.5 && tag == "RightFripperTag") {
        //     // 右タッチで右フリッパーを上げる
        // }

        // ４、マルチタッチに対応するにはどうすればいいか？

        // for (int i = 0; i < Input.TouchCount; i++) {
        //     // タッチしている指の本数分loopする。
        //     Touch myTouch = Input.GetTouch(i);

        //     if (myTouc??) {

        //     }
        // }



        //【スマホ対応版】画面左右をタップした時、左右のフリッパーを動かす        
        for (int i = 0; i < Input.touchCount; i++)//マルチタッチ
        {
            Touch myTouch = Input.GetTouch(i);

            if (myTouch.position.x < Screen.width * 0.5 && tag == "LeftFripperTag")
            {
                SetAngle(this.flickAngle);
                //Debug.Log("画面左タップ");

                if (myTouch.phase == TouchPhase.Ended && tag == "LeftFripperTag")//左タップを離した場合
                {
                    SetAngle(this.defaultAngle);
                    //Debug.Log("画面左タップ離す");
                }
            }


            if (myTouch.position.x > Screen.width * 0.5 && tag == "RightFripperTag")
            {
                SetAngle(this.flickAngle);
                //Debug.Log("画面右タップ");

                if (myTouch.phase == TouchPhase.Ended && tag == "RightFripperTag")//右タップを離した場合
                {
                    SetAngle(this.defaultAngle);
                    //Debug.Log("画面右タップ離す");
                }
            }
        }
    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}