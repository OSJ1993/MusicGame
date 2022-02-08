using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{

    public int bpm = 0;

    //노트 생성을 위한 그 시간 체크해줄 변수.
    double curentTime = 0d;

    //노트가 생성 될 위치 변수.
    [SerializeField] Transform tfNoteAppear = null;

    //노트 프리팩을 담을 변수.
    [SerializeField] GameObject goNote = null;

    //TimingManager theTimingManager 참조할 수 있게 만들어 주기.
    TimingManager theTimingManager;

    void Start()
    {
        theTimingManager = GetComponent<TimingManager>();
    }



    void Update()
    {
        //curentTime을 1초에 1씩 증가
        curentTime += Time.deltaTime;

        //그러다가 curentTime이 60s초 나누기 bpm보다 커지면 비트 1개당 등장속도.
        if (curentTime >= 60d / bpm)
        {
            //60나누기 bpm보다 같거나 커지면 즉0.5초가 지나면 노트를 취향?위치에 생성.
            GameObject t_note = Instantiate(goNote, tfNoteAppear.position, Quaternion.identity);

            //이 스크립트가 붙어있는 객체를 부모로 설정.
            t_note.transform.SetParent(this.transform);

            //노트가 생성되는 순간 노트List에 해당 노트를 추가.
            theTimingManager.boxNoteList.Add(t_note);

            //curentTime에 0이 아닌 60d/bpm을 빼주기.(0으로 하면 안되는 이유는 아주 작은 오차가 생기기 때문이다.
            curentTime -= 60d / bpm;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //콜라이더 내에 들어오거나 나가면 발동하는 함수.
        //Note 테그로 된 콜라이더가 감지되면 그 객체를 파괴.
        if (collision.CompareTag("Note"))
        {
            //노트가 파괴되는 순간에도 해당 노트를 List에서 제거.
            theTimingManager.boxNoteList.Remove(collision.gameObject);

            Destroy(collision.gameObject);
        }
    }
}
