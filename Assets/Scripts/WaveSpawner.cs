using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING}; 




    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }
    public Wave [] waves;
    public Transform[] spawnPoints;
    private int nextWave = 0;

    public float timeBetweenWaves = 5f; //to be changed to the enemies count
    private float waveCountdown;
    private float searchCountDown = 2f; // Used to check the enemies on the screen

    private SpawnState state = SpawnState.COUNTING;

    void Start()
    {
        waveCountdown = timeBetweenWaves;

        if (spawnPoints.Length == 0)
        {
            Debug.Log("No Spawn Points referenced.");
        }

        if (waves.Length == 0)
        {
            Debug.Log("No waves Found.");
        }
    }

    void Update()
    {
        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if (waveCountdown <= 0)
        {
            if(state != SpawnState.SPAWNING)
            {
                StartCoroutine( SpawnWave( waves[nextWave] ) );
            }        
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }


    bool EnemyIsAlive()
    {
        searchCountDown -= Time.deltaTime;

        if (searchCountDown <= 0f)
        {
            searchCountDown = 2f;
            if (GameObject.FindGameObjectWithTag ("Enemy") == null)
            {
                return false;
            }
        }

        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave" + _wave.name);
        state = SpawnState.SPAWNING;
        //spawns

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f/_wave.rate ); //yield return new WaitForSeconds(_wave.delay); 
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        Debug.Log("Spawning Enemy: "+ _enemy.name);

        Transform _sp = spawnPoints[ Random.Range(0, spawnPoints.Length) ];
        Instantiate(_enemy, _sp.position, _sp.rotation); 
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed!");
        
        state =  SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1) 
        {
            //put here the level ending screen
            nextWave = 0;
            Debug.Log ("ALL WAVES COMPLETE! Looping...");
        }

        else
        {
            nextWave++;
        }
        
    }
}




 