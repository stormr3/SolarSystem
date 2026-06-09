using UnityEngine;

public class Gravity : MonoBehaviour
{
    public Transform earthT;

    [SerializeField] 
    private Vector3 velocity = new Vector3 (0f, 0f, 0f);
    private float massOfEarth = 10;
    private float massOfMoon = 10;
    private const float G = 0.01f;

    private Vector3 acc, dispToEarth;
    private float distToEarth;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocity);

        dispToEarth = earthT.position - transform.position;
        distToEarth = dispToEarth.magnitude;
        acc = ((G * massOfEarth) / (distToEarth * distToEarth)) * dispToEarth.normalized;
        velocity += acc;
        print(acc);
    }
}
