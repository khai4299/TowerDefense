using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

[RequireComponent(typeof(Enermy))]
public class EnermyMovement : MonoBehaviour
{
    private Transform target;
    private int pathIndex = 0;
    private Enermy enermy;
    
    private void Start()
    {
        enermy = GetComponent<Enermy>();
        target = Path.paths[0];
    }
    private void Update()
    {
        if (GameManager.endGame)
            return;
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enermy.speed * Time.deltaTime);
        if (Vector3.Distance(target.position, transform.position) < 0.2f)
        {
            GetNextpoint();
        }
        enermy.speed = enermy.startSpeed;
    }
    void GetNextpoint()
    {
        if (pathIndex >= Path.paths.Length - 1)
        {
            PlayerStats.live--;
            WaveSpawn.enermiesAlive--;
            Destroy(gameObject);
            return;
        }
        pathIndex++;
        target = Path.paths[pathIndex];
    }
}
