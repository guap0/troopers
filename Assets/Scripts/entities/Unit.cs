using UnityEngine;
using System.Collections;

public class Unit : Destructable
{
    public float movespeed = 5;

    public void move(Vector3 direction)
    {
        direction = direction * movespeed * Time.deltaTime;
        transform.position = transform.position + direction;
    }

    public void look(Vector3 aim)
    {
        Vector3 direction = aim - transform.position;
        float radian = -Mathf.Atan2(direction.z, direction.x);
        float angle = radian * Mathf.Rad2Deg;
        Vector3 rotationVector = new Vector3(0, angle, 0);
        transform.rotation = Quaternion.Euler(rotationVector);
        cameraTarget.position = aim;
    }
}
