using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
   public static EnemyManager instance;

    [SerializeField]
    private GameObject  Jill_Prefab;

    public Transform[]  Jill_SpawnPoints;
    [SerializeField]
    private int Jill_Enemy_Count;

    private int initial_Jill_Count;

    public float wait_Before_Spawn_Enemies_Time = 10f;

    // Use this for initialization
    void Awake () {
        MakeInstance();
	}

    void Start() {
        initial_Jill_Count = Jill_Enemy_Count;


        SpawnEnemies();

        StartCoroutine("CheckToSpawnEnemies");
    }

    void MakeInstance() {
        if(instance == null) {
            instance = this;
        }
    }

    void SpawnEnemies() {
        SpawnCannibalsZombie();

    }

    void SpawnCannibalsZombie() {

        int index = 0;

        for (int i = 0; i < Jill_Enemy_Count; i++) {

            if (index >= Jill_SpawnPoints.Length) {
                index = 0;
            }

            Instantiate(Jill_Prefab, Jill_SpawnPoints[index].position, Quaternion.identity);

            index++;

        }

        Jill_Enemy_Count = 0;

    }



    IEnumerator CheckToSpawnEnemies() {
        yield return new WaitForSeconds(wait_Before_Spawn_Enemies_Time);

        SpawnEnemies();

        StartCoroutine("CheckToSpawnEnemies");

    }

    public void EnemyDied(bool Jill) {

        if(Jill) {

            Jill_Enemy_Count++;

            if(Jill_Enemy_Count > initial_Jill_Count) {
                Jill_Enemy_Count = initial_Jill_Count;
            }

        }

        
    }

    public void StopSpawning() {
        StopCoroutine("CheckToSpawnEnemies");
    }

} // class
