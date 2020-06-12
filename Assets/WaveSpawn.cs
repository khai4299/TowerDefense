using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WaveSpawn : MonoBehaviour
{
    public GameObject enermyPrefab;
    public Transform spawnPoint;
    public Text waveText;
    public float TimeBetweenWave = 5f;
    private float countdown = 1f;
    private int waveNumber = 0;
    public static int enermiesAlive = 0;
    public Wave[] waves;
    private int waveIndex = 0;
    public GameManager gameManager;
    private void Start()
    {
        enermiesAlive = 0;
    }
    private void Update()
    {
        if (enermiesAlive > 0)
        {
            return;
        }
        if (waveIndex == waves.Length)
        {               
            gameManager.WinLevel();
            this.enabled = false;
        }
        if (GameManager.endGame)
            return;
        if (countdown<=0)
        {
            StartCoroutine(SpawnWave());
            countdown = TimeBetweenWave;
            PlayerStats.round++;
            return;
        }
        
        countdown-=Time.deltaTime;
         countdown = Mathf.Clamp(countdown, 0, Mathf.Infinity);
        waveText.text = string.Format("{0:00.00}",countdown);
    }
    IEnumerator SpawnWave()
    {
        Wave wave = waves[waveIndex];
        enermiesAlive = wave.count;
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnermy(wave.enermy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        waveIndex++;
    }

    void SpawnEnermy(GameObject enermy)
    {
        Instantiate(enermy, spawnPoint.position, spawnPoint.rotation);
    }
}
