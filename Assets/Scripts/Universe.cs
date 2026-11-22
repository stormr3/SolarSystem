using UnityEngine;

public class Universe : MonoBehaviour
{
    [SerializeField] public static float GravConst = 1000;
    Planet[] planets;

    private void Awake()
    {
        planets = Object.FindObjectsByType<Planet> (FindObjectsSortMode.None);
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < planets.Length; i++)
        {
            planets[i].UpdateVelocity(planets, Time.fixedDeltaTime);
        }

        for (int i = 0; i < planets.Length; i++)
        {
            planets[i].UpdatePosition(Time.fixedDeltaTime);
        }
    }
}
