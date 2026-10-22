using UnityEngine;

public class RockyWalk : MonoBehaviour
{
    public Transform leftArm;
    public Transform rightArm;
    public Transform leftLeg;
    public Transform rightLeg;

    public float swingSpeed = 4f;
    public float armSwingAmount = 10f;
    public float legSwingAmount = 24f;
    public float bounceAmount = 0.08f;

    private float startY;

    void Start()
    {
        startY = transform.position.y;
    }

    void Update()
    {
        float timeValue = Time.time * swingSpeed;
        float armAngle = Mathf.Sin(timeValue) * armSwingAmount;
        float legAngle = Mathf.Sin(timeValue) * legSwingAmount;

        if (leftArm != null)
            leftArm.localRotation = Quaternion.Euler(armAngle, 0f, 0f);

        if (rightArm != null)
            rightArm.localRotation = Quaternion.Euler(-armAngle, 0f, 0f);

        if (leftLeg != null)
            leftLeg.localRotation = Quaternion.Euler(-legAngle, 0f, 0f);

        if (rightLeg != null)
            rightLeg.localRotation = Quaternion.Euler(legAngle, 0f, 0f);

        float bounce = Mathf.Abs(Mathf.Sin(timeValue)) * bounceAmount;
        transform.position = new Vector3(transform.position.x, startY + bounce, transform.position.z);
    }
}