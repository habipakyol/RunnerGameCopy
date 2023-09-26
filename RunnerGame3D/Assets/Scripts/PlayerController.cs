using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    private float touchX = 0f;
    private float newX;
    public float xSpeed;
    public float limitX;
    
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            touchX = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }
        else if (Input.GetMouseButton(0))
        {
            touchX = Input.GetAxis("Mouse X");
        }
        else
        {
            touchX = 0;
        }

        newX = transform.position.x + xSpeed * touchX * Time.deltaTime;
        newX = Mathf.Clamp(newX, -limitX, limitX);
        Vector3 newPosition = new Vector3(newX, transform.position.y,
            transform.position.z + Speed * Time.deltaTime);
        transform.position = newPosition;
    }
}
