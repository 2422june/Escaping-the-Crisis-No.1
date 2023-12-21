using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMovement : MonoBehaviour
{
    //스크롤할 도로 프리팹들
    [SerializeField]
    private GameObject[] roadPrefabs;
    //도로 전체
    [SerializeField]
    private GameObject road;
    //자동차 핸들
    [SerializeField]
    private Transform handleTransform;

    //도로 이동 속도
    private float moveSpeed;
    public float MoveSpeed { get{return moveSpeed;} set{moveSpeed = value;} }
    //도로를 위치를 이동시켜야 할 때의 값
    private float zPoint;
    //도로를 좌우로 이동시킬 양
    private float moveAmount;
    //핸들의 각도에 따라 도로를 이동시킬 양을 조절할 때 사용
    private float amount;
    //도로를 좌우로 움직일 때 걸리는 시간
    private float moveTime;
    //핸들의 회전값이 변했는지 확인할 때 쓸 변수
    private float handleRotZ;

    //도로를 스크롤할 때 이동시킬 위치
    private Vector3 originPos;
    //도로를 좌우로 움직일 때 이동시킬 위치
    private Vector3 targetPos;
    private Vector3 originRoadPos;
    private List<Vector3> originRoadsPos = new List<Vector3>();

    void Start()
    {
        //값 초기화
        moveSpeed = 15.0f;    
        zPoint = -300.0f;
        originPos = roadPrefabs[roadPrefabs.Length - 1].transform.localPosition;
        moveAmount = 0.0f;
        amount = 0.001f;
        moveTime = 0.2f;
        handleRotZ = 0.0f;
        for(int i = 0; i < roadPrefabs.Length; i++)
        {
            originRoadsPos.Add(roadPrefabs[i].transform.position);
        }

        originRoadPos = road.transform.position;
    }

    void Update()
    {
        //도로들을 하나씩 이동시키기
        for(int i = 0; i < roadPrefabs.Length; i++)
        {
            RoadScroll(i);
        }

        RoadMoveHorizontal();
    }

    //다시 실행을 할 경우 초기 상태로 전환
    public void Return()
    {
        Debug.Log("Return");
        //핸들 회전 초기화
        handleTransform.rotation = Quaternion.identity;
        //도로 위치 초기화
        road.transform.position = originRoadPos;
        for(int i = 0; i < roadPrefabs.Length; i++)
        {
            roadPrefabs[i].transform.position = originRoadsPos[i];
        }
    }

    private void RoadScroll(int num)
    {
        roadPrefabs[num].transform.localPosition += Vector3.back * moveSpeed * Time.deltaTime;
        
        if(roadPrefabs[num].transform.localPosition.z <= zPoint)
        {
            roadPrefabs[num].transform.localPosition = originPos;
        }
    }

    private void RoadMoveHorizontal()
    {
        //저장해둔 핸들의 회전값과 현재 핸들의 회전값을 비교해서 값이 같다면 함수 리턴
        if(handleRotZ == handleTransform.rotation.eulerAngles.z)
        {
            return;
        }

        //이동할 양을 핸들 회전값 변화량으로 설정
        moveAmount = handleTransform.rotation.eulerAngles.z - moveAmount;
        //핸들의 회전값을 저장
        handleRotZ = handleTransform.rotation.eulerAngles.z;
        //핸들의 회전값이 음수일 때 처리
        if(moveAmount > 180) {moveAmount -= 360;}

        //값 조절해주기
        moveAmount *= amount;
        StartCoroutine(MoveCoroutine(Vector3.left * moveAmount));
    }

    IEnumerator MoveCoroutine(Vector3 dir)
    {
        float elapsedTime = 0.0f;

        Vector3 currentPos = road.transform.position;
        targetPos = currentPos + dir;

        while(elapsedTime < moveTime)
        {
            //보간으로 이동
            road.transform.position = Vector3.Lerp(currentPos, targetPos, elapsedTime/moveTime);
            
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        road.transform.position = targetPos;
    }
}
