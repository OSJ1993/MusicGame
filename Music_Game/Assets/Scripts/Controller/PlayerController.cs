using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    TimingManager theTimingManager;

    void Start()
    {
        theTimingManager = FindObjectOfType<TimingManager>();
    }


    void Update()
    {
        //�� ������ ���� Ű�� ���ȴ��� Ȯ���ؾ���.
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            // ���� üũ.
            //Space�� ������ Ÿ�̹� ������ �� �ְ� üũŸ�̹� ȣ��.
            theTimingManager.CheckTiming();
        }
    }
}
