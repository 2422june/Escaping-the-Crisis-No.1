using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_resert : MonoBehaviour
{
    public bool[] Checking_List = new bool[6]; // �ùٸ� �ൿ�� �� ���� ����
    [SerializeField] Sprite[] Sprites; // �ùٸ� �ൿ�� �� ������ ���� ���ϴ� ���â �̹���
    [SerializeField] GameObject[] Checks; // �ùٸ� �ൿ�� ���� �� SetActive(true) �Ǵ� üũ �̹���
    private int check_howmuch = 0; // �ùٸ� �ൿ�� �� ���� 
    // Update is called once per frame
    void Start()
    {
        // �ùٸ� �ൿ�� �� ���� �ʱ�ȭ(�ִ� 6��)
        check_howmuch = 0;
        // üũ����Ʈ �ʱ�ȭ
        for (int i = 0; i < 7; i++)
        {
            Checking_List[i] = false;
        }
        // �ùٸ� �ൿ�� �� �׸��� �ִٸ� �׿� �´� üũǥ�� SetActive(true) �ǰ� �ùٸ� �ൿ�� �� ���� ����
        for (int i = 0; i<7; i++)
        {
            if (Checking_List[i] == true)
            {
                check_howmuch++;
                Checks[i].SetActive(true);
            }
        }
        // �ùٸ� �ൿ�� �� ������ ���� ���â ��ȭ
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Sprites[check_howmuch];
    }
}
