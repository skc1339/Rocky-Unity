using UnityEngine;

public class FollowRocky : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        if (target != null)
        {
            transform.position = target.position + new Vector3(-1f, 0f, 0f);
        }
    }
}