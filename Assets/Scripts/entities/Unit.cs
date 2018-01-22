using UnityEngine;
using System.Collections;

public class Unit : Destructable
{
    public float movespeed = 5;
    public Vector3 aim;

    public void move(Vector3 direction)
    {
        direction = direction * movespeed * Time.deltaTime;
        // transform.position = transform.position + direction;
        transform.Translate(direction);
    }

    public void look(Vector3 aimPosition)
    {
        Vector3 direction = aimPosition - transform.position;
        float radian = Mathf.Atan2(direction.x, direction.z);
        float angle = radian * Mathf.Rad2Deg;
        aim = aimPosition;
        aim.y = 0;
        if (graphics != null)
        {
            graphics.transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
            aim = graphics.transform.forward;
        }
        if (cam != null) {
            cam.transform.position = aimPosition;
        }
    }
}
