using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    private float visiblePosZ = -6.5f;
    // Game Over 表示
    private GameObject gameoverText;
    // 得点表示
    private GameObject scoreText;
    // ボールの衝突時に加算される点数
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.gameoverText = GameObject.Find("GameOverText");
        this.scoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.z < this.visiblePosZ)
        {
            this.gameoverText.GetComponent<Text>().text = "Game Over";
            this.scoreText.GetComponent<Text>().text = score.ToString();

        }
    }

    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision other)
    {
        // デバッグ
        Debug.Log("衝突した" + other.gameObject.tag);

        // タグによって光らせる色を変える
        if (other.gameObject.tag == "SmallStarTag")
        {
            score += 10;
            this.scoreText.GetComponent<Text>().text = score.ToString();
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            score += 20;
            this.scoreText.GetComponent<Text>().text = score.ToString();
        }
        else if (other.gameObject.tag == "SmallCloudTag" || other.gameObject.tag == "LargeCloudTag")
        {
            score += 30;
            this.scoreText.GetComponent<Text>().text = score.ToString();
        }
    }
}

