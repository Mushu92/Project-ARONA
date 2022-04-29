using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed;
    Rigidbody2D rigid;

    Vector3 playerSize;

    void Awake() {
        rigid = GetComponent<Rigidbody2D>();
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
        float h = Input.GetAxisRaw("Horizontal");
        if( h > 0 ) {
            transform.localScale = new Vector3(1,1,1);
        } else if( h < 0 ){
            transform.localScale = new Vector3(-1,1,1);
        }
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (rigid.velocity.x > maxSpeed)
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < maxSpeed * (-1))
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
    }

}
