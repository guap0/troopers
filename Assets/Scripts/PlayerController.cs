using UnityEngine;

[RequireComponent(typeof(Unit))]
public class PlayerController : MonoBehaviour {
    [HideInInspector]
    public Unit unit;

    void Start()
    {
        unit = GetComponent<Unit>();
    }

    void Update () {
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = 0;
		float xInput = 0;
		float yInput = 0;

		if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
			//move up
			yInput += 1;
		if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
			//move down
			yInput -= 1;
		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
			//move right
			xInput += 1;
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
			//move left
			xInput -= 1;
		if (xInput != 0 || yInput != 0) {
			Vector3 moveVector = new Vector3(xInput, 0, yInput);
            unit.move(moveVector.normalized);
		}

        // Rotation
        mousePos.z = 20f;
        if (Camera.current != null) {
            mousePos = Camera.current.ScreenToWorldPoint(mousePos);
            Vector3 relativeMousePos = mousePos - transform.position;
            relativeMousePos.y = 0;
            float radian = Mathf.Atan2(relativeMousePos.x, relativeMousePos.z);

            float cameraRadius = Mathf.Min(3, relativeMousePos.magnitude / 2);
            Vector3 targetPosition = transform.position;
            Vector3 cameraOffset = new Vector3(Mathf.Sin(radian) * cameraRadius, 0, Mathf.Cos(radian) * cameraRadius);
            Vector3 aimVector = new Vector3(targetPosition.x, targetPosition.y + 20, targetPosition.z);
            aimVector += cameraOffset;

            unit.look(aimVector);
        }

    }
}
