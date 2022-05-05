using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
     //캐릭터 위치 정보
    [SerializeField]
    Transform playerTransform;
    //카메라 위치 정보
    [SerializeField]
    Vector3 cameraPosition;

    //맵의 중앙
    [SerializeField]
    Vector2 center;
    //맵의 크기
    private Vector2 mapSize;

    //카메라 이동 속도
    [SerializeField]
    float cameraMoveSpeed;

    Vector3 playerSize;
    private float height;
    private float width;

    void Start()
    {
        //플레이어 위치 정보 가져옴
        // playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        
        Transform mapSizeTransform = GameObject.Find("World").GetComponent<Transform>();
        mapSize = new Vector2(mapSizeTransform.localScale.x /2 , mapSizeTransform.localScale.y / 2);

        //카메라 범위 계산
        playerSize = GetComponent<Renderer>().bounds.size;
        height = playerSize.y / 2;
        width = playerSize.x / 2;
    }

    void FixedUpdate()
    {
        LimitCameraArea();
    }

    //영역(Map) 밖을 비추지 않도록 영역 제한
    void LimitCameraArea()
    {
        Vector3 camPos = new Vector3(cameraPosition.x * playerTransform.localScale.x, cameraPosition.y, cameraPosition.z);
        //선형 보간 사용해서 카메라 이동 부드럽게
        transform.position = Vector3.Lerp(transform.position, 
                                          playerTransform.position + camPos, 
                                          Time.deltaTime * cameraMoveSpeed);
        
        
        //Clamp 이용해서 범위 제한
        float lx = mapSize.x - width;
        float clampX = Mathf.Clamp(transform.position.x, -lx + center.x, lx + center.x);

        float ly = mapSize.y - height;
        float clampY = Mathf.Clamp(transform.position.y, -ly + center.y, ly + center.y);

        transform.position = new Vector3(clampX, clampY, 0);
    }
}
