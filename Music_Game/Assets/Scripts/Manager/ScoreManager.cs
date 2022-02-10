using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //Text ���� ����.
    [SerializeField] Text txtScore = null;

    //���� �� ���� ���� �ö󰡰� �� ����Ʈ����.
    [SerializeField] int increasaseScore = 10;

    //���� ������ ���� ����.
    int currentScore = 0;

    //������ ���� ����ġ�� �ٸ� �� �ְ� ���ִ� ���� ����.
    [SerializeField] float[] weight = null;


    Animator myAnim;
    string animScoreUp = "ScoreUp";
    void Start()
    {
        myAnim = GetComponent<Animator>();
        currentScore = 0;
        txtScore.text = "0";
    }

    //� ��Ʈ ������ �޾ƿԴ� Ȯ��.
    public void IncreasaseScore(int p_JudgementState)
    {
        //�ӽ� ������ ������ ������ �־��ְ� ���⿡ ������ ���� ����ġ�� �־��ֱ�.
        int t_increasaseScore = increasaseScore;

        //����ġ ���.
        t_increasaseScore = (int)(t_increasaseScore * weight[p_JudgementState]);

        //�� ������ ���� ������ ���ϱ�.
        currentScore += t_increasaseScore;

        //���ڿ� ���� : ��ȭ, ����, �Ҽ���, ��¥ ǥ�� �������� ��ȯ������
        txtScore.text = string.Format("{0:#,##0}", currentScore);

        myAnim.SetTrigger(animScoreUp);
    }
}
