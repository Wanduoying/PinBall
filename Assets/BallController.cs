using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    //スコアを表示するテキスト
    private GameObject ScoreText;

    //現在のスコア
    private int Score = 0;



    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");

        //ScoreText取得
        this.ScoreText = GameObject.Find("ScoreText");
    }



    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }



    //ボールがオブジェクトに当たつた時のスコア計算
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "SmallStarTag" )
        {
            Score+= 10;
            //Debug.Log(Score + "(SmallStar)");
        }

        if (other.gameObject.tag == "LargeStarTag")
        {
            Score += 100;
            //Debug.Log(Score + "(LargeStar)");
        }

        if (other.gameObject.tag == "SmallCloudTag")
        {
            Score += 25;
            //Debug.Log(Score + "(SmallCloud)");
        }

        if (other.gameObject.tag == "LargeCloudTag")
        {
            Score += 50;
            //Debug.Log(Score + "(LargeCloud)");
        }

        //現在のスコア表示
        this.ScoreText.GetComponent<Text>().text = "Score:" + Score;
    }
    
       
}