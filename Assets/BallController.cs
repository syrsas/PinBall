using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    private float visiblePosZ = -6.5f;
    // Game Over �\��
    private GameObject gameoverText;
    // ���_�\��
    private GameObject scoreText;
    // �{�[���̏Փˎ��ɉ��Z�����_��
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

    //�Փˎ��ɌĂ΂��֐�
    void OnCollisionEnter(Collision other)
    {
        // �f�o�b�O
        Debug.Log("�Փ˂���" + other.gameObject.tag);

        // �^�O�ɂ���Č��点��F��ς���
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

