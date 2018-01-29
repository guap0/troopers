using UnityEngine;
using System.Collections;

public class Unit : Destructable
{
    public float movespeed = 5;
    public Vector3 aim;

    private Vector3 velocity;

    public void move(Vector3 direction)
    {
        velocity = direction * movespeed;
        // transform.position = transform.position + direction;
        //transform.Translate(direction);
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

    // Update is called once per frame
    void FixedUpdate ()
    {
        if(velocity != Vector3.zero)
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }
}
