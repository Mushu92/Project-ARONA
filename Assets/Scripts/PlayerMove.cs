using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rigid;  //Rigidbody2D ������Ʈ ������ ���� rigid�� ����
    Vector3 playerSize; //ĳ���� ��������Ʈ ������
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();  // Player ������Ʈ ���� Rigidbody2D ������Ʈ�� rigid�� ����
        playerSize = GetComponent<Renderer>().bounds.size;
    }

    void Update() {
        
         var distance = (transform.position - Camera.main.transform.position).z;
 
         var leftBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance)).x + (playerSize.x/2);
         var rightBorder = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance)).x - (playerSize.x/2);
 
         var bottomBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance)).y + (playerSize.y/2);
         var topBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, distance)).y - (playerSize.y/2);
     
         // Here the position of the player is clamped into the boundaries
         transform.position = (new Vector3 (
             Mathf.Clamp (transform.position.x, leftBorder, rightBorder),
             Mathf.Clamp (transform.position.y, bottomBorder, topBorder),
             transform.position.z)
         );
    }


    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal"); // h�� �Է��� ���� GetAxisraw horizontal�� -1 ~ 1 ����.. �Ƹ�?

        if( h > 0 ) {
            transform.localScale = new Vector3(1,1,1);
        } else if( h < 0 ){
            transform.localScale = new Vector3(-1,1,1);
        }
        
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);  // impulse�� ���� ������� �𸣰���
        Debug.Log(h);
    }
}
