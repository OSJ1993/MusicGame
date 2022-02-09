using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{

    //���ǵ� ����.
    public float noteSpeed = 400;

    //���� ��Ʈ�� �̹����� �����ϰ� �ش� ��Ʈ�� �ı����� �ʵ��� ����.
    UnityEngine.UI.Image noteImage;

    void Start()
    {
        noteImage = GetComponent<Image>();
    }

   
    void Update()
    {
        //�� ��ũ��Ʈ�� �پ��ִ� ��ü ���� ������ ���� ���������� 1�ʿ� noteSpeed �� ��ŭ �̵��� �� �ְ� �����.
        transform.localPosition += Vector3.right * noteSpeed * Time.deltaTime;
    }

    //�� �Լ��� ȣ��Ǹ� �� �̹����� enabled ��Ȱ��ȭ(false) ������� �����.
    public void HideNote()
    {
        noteImage.enabled = false;
    }
}
