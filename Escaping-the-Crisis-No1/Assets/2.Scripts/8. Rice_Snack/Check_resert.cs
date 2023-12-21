using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_resert : MonoBehaviour
{
    public bool[] Checking_List = new bool[6]; // 올바른 행동을 한 갯수 세기
    [SerializeField] Sprite[] Sprites; // 올바른 행동을 한 갯수에 따라 변하는 결과창 이미지
    [SerializeField] GameObject[] Checks; // 올바른 행동을 했을 시 SetActive(true) 되는 체크 이미지
    private int check_howmuch = 0; // 올바른 행동을 한 갯수 
    // Update is called once per frame
    void Start()
    {
        // 올바른 행동을 한 갯수 초기화(최대 6개)
        check_howmuch = 0;
        // 체크리스트 초기화
        for (int i = 0; i < 7; i++)
        {
            Checking_List[i] = false;
        }
        // 올바른 행동을 한 항목이 있다면 그에 맞는 체크표시 SetActive(true) 되고 올바른 행동을 한 갯수 증가
        for (int i = 0; i<7; i++)
        {
            if (Checking_List[i] == true)
            {
                check_howmuch++;
                Checks[i].SetActive(true);
            }
        }
        // 올바른 행동을 한 갯수에 따라 결과창 변화
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Sprites[check_howmuch];
    }
}
