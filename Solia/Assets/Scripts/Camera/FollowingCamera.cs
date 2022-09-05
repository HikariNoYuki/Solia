using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    [Tooltip("The transform to follow")]
    public Transform toFollow;

    [Tooltip("The deadzone of the camera following")]
    [SerializeField] private float deadzone;

    [Tooltip("The percentage of the distance to move every frame")]
    [Range(1, 100)][SerializeField] private float percentageDistance;

    //the starting z coordinate (game in 2d, dont want to move the z axis)
    private float startingZcoordinate;

    private void FixedUpdate()
    {
        //move a percentage of the distance toward the follow target if too far
        float distance = Vector3.Distance(transform.position, toFollow.position);
        if (distance > deadzone)
        {
            transform.position += (toFollow.position - transform.position) * percentageDistance * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, transform.position.y, startingZcoordinate);
        }
    }

    private void Start()
    {
        startingZcoordinate = transform.position.z;
    }
}