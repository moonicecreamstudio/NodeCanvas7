using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FruitSpawnerManager : MonoBehaviour
{
    public GameObject chosenFruit;
    public GameObject[] fruitList;
    public Transform spawnedFruit;

    public float fruitTime;
    public float fruitTimeCoolDown;

    public float spawnRadius; // Valid spawn area
    public int maxAttempts; // Attempts to find valid spawn

    public void Start()
    {

    }

    public void Update()
    {
        fruitTime += Time.deltaTime;

        if (fruitTime >= fruitTimeCoolDown) // When fruit time reaches cooldown, spawn fruit
        {
            fruitSelector();
            SpawnFruit();
            fruitTime = 0f;
        }
    }

    public void fruitSelector() // Choose between the possible list of fruits
    {
        int fruitRoll = Random.Range(0, fruitList.Length);
        chosenFruit = fruitList[fruitRoll];
    }

    public void SpawnFruit()
    {
        if (chosenFruit == null) return; // Ensures a fruit has been selected

        Vector3 randomPoint = GetRandomNavMeshPoint(transform.position, spawnRadius);
        if (randomPoint != Vector3.zero)
        {
            Instantiate(chosenFruit, randomPoint, Quaternion.identity, spawnedFruit);
        }
        else
        {
            Debug.LogWarning("Failed to find a valid NavMesh position.");
        }
    }

    public Vector3 GetRandomNavMeshPoint(Vector3 origin, float radius)
    {
        for (int i = 0; i < maxAttempts; i++)
        {
            Vector3 randomDirection = Random.insideUnitSphere * radius;
            randomDirection += origin;

            if (NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, radius, NavMesh.AllAreas))
            {
                return hit.position;
            }
        }
        return Vector3.zero; // Return zero if no valid point is found
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green; // Set the color of the gizmo
        Gizmos.DrawWireSphere(transform.position, spawnRadius); // Draw the spawn radius
    }
}
