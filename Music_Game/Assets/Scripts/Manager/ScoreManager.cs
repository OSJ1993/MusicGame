using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //Text 변수 선언.
    [SerializeField] Text txtScore = null;

    //맞출 때 마다 점수 올라가게 할 디폴트변수.
    [SerializeField] int increasaseScore = 10;

    //현재 점수를 담을 변수.
    int currentScore = 0;

    //판정에 따라 가중치가 다를 수 있게 해주는 변수 선언.
    [SerializeField] float[] weight = null;


    Animator myAnim;
    string animScoreUp = "ScoreUp";
    void Start()
    {
        myAnim = GetComponent<Animator>();
        currentScore = 0;
        txtScore.text = "0";
    }

    //어떤 노트 판정을 받아왔는 확인.
    public void IncreasaseScore(int p_JudgementState)
    {
        //임시 변수에 증가할 변수를 넣어주고 여기에 판정에 따른 가중치를 넣어주기.
        int t_increasaseScore = increasaseScore;

        //가중치 계산.
        t_increasaseScore = (int)(t_increasaseScore * weight[p_JudgementState]);

        //이 점수를 현재 점수에 더하기.
        currentScore += t_increasaseScore;

        //문자열 형식 : 재화, 단위, 소수점, 날짜 표현 형식으로 변환시켜줌
        txtScore.text = string.Format("{0:#,##0}", currentScore);

        myAnim.SetTrigger(animScoreUp);
    }
}
