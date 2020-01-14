using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Создание переменной «враг»
    //public Transform enemy;
    public Transform enemy2;
    public Transform enemy3;
    // public Transform enemy4;

    // Временные промежутки между событиями, кол-во врагов
    public float timeBeforeSpawning = 1.5f;
    public float timeBetweenEnemies = 0.25f;
    public float timeBeforeWaves = 2.0f;
    public int enemiesPerWave = 2;
    private int currentNumberOfEnemies = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(timeBeforeSpawning);
        while (true)
        {
            if (currentNumberOfEnemies <= 0)
            {
                float randDirection;
                float randDistance;
                for (int i = 0; i < enemiesPerWave; i++)
                {
                    // Задаём случайные переменные для расстояния и направления
                    randDistance = Random.Range(10, 30);
                    randDirection = Random.Range(0, 360);
                    // Используем переменные для задания координат появления врага
                    float posX = this.transform.position.x + (Mathf.Cos((randDirection) * Mathf.Deg2Rad) * randDistance);
                    float posY = this.transform.position.y + (Mathf.Sin((randDirection) * Mathf.Deg2Rad) * randDistance);
                    // Создаём врага на заданных координатах
                    // Instantiate(enemy, new Vector3(posX, posY, 0), this.transform.rotation);
                    Instantiate(enemy2, new Vector3(posX, posY, 0), this.transform.rotation);
                    Instantiate(enemy3, new Vector3(posX, posY, 0), this.transform.rotation);
                    // Instantiate(enemy4, new Vector3(posX, posY, 0), this.transform.rotation);
                    currentNumberOfEnemies++;
                    yield return new WaitForSeconds(timeBetweenEnemies);
                }

            }
            yield return new WaitForSeconds(timeBeforeWaves);

        }

        // Процедура уменьшения количества врагов в переменной


    }
    public void KilledEnemy()
    {
        currentNumberOfEnemies--;
    }
}
