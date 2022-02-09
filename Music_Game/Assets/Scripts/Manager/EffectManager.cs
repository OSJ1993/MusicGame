using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectManager : MonoBehaviour
{
    [SerializeField] Animator noteHitAnimator = null;
    string hit = "Hit";

    [SerializeField] Animator judgementAnimator = null;

    //��ü�� �̹��� ���� ����.
    [SerializeField] Image judgementImage = null;

    //����Ʈ �� �� ���� ���� �̹��� ���(�迭).
    [SerializeField] Sprite[] judgementSprite = null;


   
    public void JudgementEffect(int p_num)
    {
        //�Ǹ����� ���� �´� ���� �̹��� ��������Ʈ ��ü
        judgementImage.sprite = judgementSprite[p_num];

        judgementAnimator.SetTrigger(hit);
    }

    public void NoteHitEffect()
    {
        noteHitAnimator.SetTrigger(hit);
    }
}
