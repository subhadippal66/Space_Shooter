using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    
    void Start()
    {
        
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        var moveX = Input.GetAxis("Horizontal") * Time.deltaTime *moveSpeed;
        var moveY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var newXpos = transform.position.x + moveX;
        var newYpos = transform.position.y + moveY;
        transform.position = new Vector2(newXpos, newYpos);
    }
}
