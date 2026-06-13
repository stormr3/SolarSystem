using UnityEngine;

public class Planet : MonoBehaviour
{
    public float mass;
    public float radius;
    public Vector3 initialVelocity;
    Vector3 velocity;

    private void Awake()
    {
        velocity = initialVelocity;
    }

    public void UpdateVelocity(Planet[] planets, float timeStep)
    {
        Vector3 force = Vector3.zero;
        foreach (var planet in planets)
        {
            if (planet != this)
            {
            Vector3 displacement = planet.transform.position - transform.position;
            force += displacement.normalized * (Universe.GravConst * mass * planet.mass / displacement.sqrMagnitude);
            }
        }

        Vector3 acc = force / mass;
        velocity += acc * timeStep;
    }

    public void UpdatePosition(float timeStep)
    {
        transform.position += velocity * timeStep;
    }
}
