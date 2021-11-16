using UnityEngine;

public class CameraFollow : MonoBehaviour
{

	[SerializeField][Tooltip("this is the target we want the camera to follow along the game")]
	public Transform target;
    private int leftPosition = -7;
    private int rightPosition = 340;
    void FixedUpdate()
	{
		Vector3 desiredPosition = transform.position;
		//in order to not see the remaining screen
		if (target != null)
		{
            if (target.position.x <= leftPosition)
            {
                desiredPosition.x = leftPosition;
            }
            else if (target.position.x >= rightPosition)
            {
                desiredPosition.x = rightPosition;
            }
            else //if (target.position.x >= 28 && target.position.x <= 305)
            {
                desiredPosition.x = target.position.x;
            }
            transform.position = desiredPosition;
		}
	}
}
