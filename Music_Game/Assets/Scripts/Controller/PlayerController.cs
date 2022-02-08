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
        //매 프레임 마다 키가 눌렸는지 확인해야함.
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            // 판정 체크.
            //Space가 눌리면 타이밍 판정할 수 있게 체크타이밍 호출.
            theTimingManager.CheckTiming();
        }
    }
}
