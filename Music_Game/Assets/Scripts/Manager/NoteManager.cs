using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{

    public int bpm = 0;

    //��Ʈ ������ ���� �� �ð� üũ���� ����.
    double curentTime = 0d;

    //��Ʈ�� ���� �� ��ġ ����.
    [SerializeField] Transform tfNoteAppear = null;

    //��Ʈ �������� ���� ����.
    [SerializeField] GameObject goNote = null;

    //TimingManager theTimingManager ������ �� �ְ� ����� �ֱ�.
    TimingManager theTimingManager;
    EffectManager theEffectManager;

    void Start()
    {
        theEffectManager = GetComponent<EffectManager>();
        theTimingManager = GetComponent<TimingManager>();
    }



    void Update()
    {
        //curentTime�� 1�ʿ� 1�� ����
        curentTime += Time.deltaTime;

        //�׷��ٰ� curentTime�� 60s�� ������ bpm���� Ŀ���� ��Ʈ 1���� ����ӵ�.
        if (curentTime >= 60d / bpm)
        {
            //60������ bpm���� ���ų� Ŀ���� ��0.5�ʰ� ������ ��Ʈ�� ����?��ġ�� ����.
            GameObject t_note = Instantiate(goNote, tfNoteAppear.position, Quaternion.identity);

            //�� ��ũ��Ʈ�� �پ��ִ� ��ü�� �θ�� ����.
            t_note.transform.SetParent(this.transform);

            //��Ʈ�� �����Ǵ� ���� ��ƮList�� �ش� ��Ʈ�� �߰�.
            theTimingManager.boxNoteList.Add(t_note);

            //curentTime�� 0�� �ƴ� 60d/bpm�� ���ֱ�.(0���� �ϸ� �ȵǴ� ������ ���� ���� ������ ����� �����̴�.
            curentTime -= 60d / bpm;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        //�ݶ��̴� ���� �����ų� ������ �ߵ��ϴ� �Լ�.
        //Note �ױ׷� �� �ݶ��̴��� �����Ǹ� �� ��ü�� �ı�.
        if (collision.CompareTag("Note"))
        {
            //��Ʈ�� ȭ�� ������ ������ �� ������ ���� 4(miss)�Ѱܼ� ����ǰ� �ϱ�.
            theEffectManager.JudgementEffect(4);
            //��Ʈ�� �ı��Ǵ� �������� �ش� ��Ʈ�� List���� ����.
            theTimingManager.boxNoteList.Remove(collision.gameObject);

            Destroy(collision.gameObject);

            
        }
    }
}
