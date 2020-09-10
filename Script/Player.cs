using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //configuration parameter
    [SerializeField] float moveSpeed;
    [SerializeField] float xBoundariesOffset;
    [SerializeField] float yBoundariesOffset;
    [SerializeField] GameObject laser_;
    [SerializeField] float fireSpeed;
    [SerializeField] float laserOffset;

    float xMin;
    float xMax;
    float yMin;
    float yMax;
    
    void Start()
    {
        DefineBoundaries();
    }

    void Update()
    {
        Move();
        Fire();
    }

    private void Fire()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Vector2 laserSpawnPos = new Vector2(transform.position.x, transform.position.y + laserOffset);
            GameObject laser_0 = Instantiate(laser_, laserSpawnPos, Quaternion.identity) as GameObject;
            laser_0.GetComponent<Rigidbody2D>().velocity = new Vector2(0, fireSpeed);
            Destroy(laser_0, 2f);
        }
    }

    private void DefineBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + xBoundariesOffset;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - xBoundariesOffset;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + yBoundariesOffset;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - yBoundariesOffset;
    }

    private void Move()
    {
        var moveX = Input.GetAxis("Horizontal") * Time.deltaTime *moveSpeed;
        var moveY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var newXpos = Mathf.Clamp(transform.position.x + moveX, xMin, xMax);
        var newYpos = Mathf.Clamp(transform.position.y + moveY, yMin, yMax);
        transform.position = new Vector2(newXpos, newYpos);
    }
}
