using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlanetGenerator : MonoBehaviour {
    public GameObject[] planets;
    Queue<GameObject> availablePlanets = new Queue<GameObject>();
    
    // Use this for initialization
    void Start () {
        // Add planets to the queue
        availablePlanets.Enqueue(planets[0]);
        availablePlanets.Enqueue(planets[1]);
        availablePlanets.Enqueue(planets[2]);
        availablePlanets.Enqueue(planets[3]);
        // Every 20 seconds
        InvokeRepeating("MovePlanet", 0, 20f);
    }

    // Update is called once per frame
    void Update () {
    }

    // Retrieve planets from the queue and make them start floating downward
    void MovePlanet() {
        EnqueuePlanets();
        // If the queue is empty, do nothing
        if (availablePlanets.Count == 0)
            return;

        // Get planet
        GameObject aPlanet = availablePlanets.Dequeue();
        aPlanet.GetComponent<Planet>().isMoving = true;
    }

    // When planets go off-screen, handle their reset
    void EnqueuePlanets() {
        foreach(GameObject aPlanet in planets) {
            if ((aPlanet.transform.position.y < 0) && !(aPlanet.GetComponent<Planet>().isMoving)) {
                aPlanet.GetComponent<Planet>().ResetPosition();
                availablePlanets.Enqueue(aPlanet);
            }
        }
    }
}
