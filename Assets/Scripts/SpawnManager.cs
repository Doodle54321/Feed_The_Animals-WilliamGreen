/*

GameObject: Game Manager

Component: SpawnManager

Description: Manages spawning animal prefabs periodically based on a frequency timer, handles screen bounds, and checks game over state.
*/

using UnityEngine;

public class SpawnManager : MonoBehaviour
{
public static SpawnManager Instance { get; private set; }

[SerializeField] private GameObject[] animalPrefab;
[SerializeField] private int animalsToFeed;
[SerializeField] private float spawnStart;
[SerializeField] private float startFrequency;
public bool isGameOver{get; private set;}

private float spawnZPosition;
 [SerializeField] private float centerToEdge;
private float timer;
private bool isSpawningActive = true;

private void Awake()
{
    Instance = this;
}

private void Start()
{
    spawnZPosition = 20.0f;
    centerToEdge = 15.0f;
    timer = startFrequency;
    isSpawningActive = true;
}

private void Update()
{
    HandleSpawningTimer();
}

private void HandleSpawningTimer()
{

    timer -= Time.deltaTime;
    if (timer <= 0.0f)
    {
        SpawnAnimal();
        timer = startFrequency;
    }
}

private void SpawnAnimal()
{
 if (animalPrefab == null && animalPrefab.Length == 0)
    {
       return;
    }
    if(animalsToFeed > 0)
    {
         int randomIndex = Random.Range(0, animalPrefab.Length);
        float randomX = Random.Range(-centerToEdge, centerToEdge);
        Vector3 spawnPosition = new Vector3(randomX, 0.0f, spawnZPosition);
        Instantiate(animalPrefab[randomIndex], spawnPosition, animalPrefab[randomIndex].transform.rotation);
    }
    else
    {   
        GameOver();
    }
}

private void GameOver()
{
    Debug.Log("Game Over");
}

// Called by: External Scripts
public int GetNumberOfAnimalsToFeed()
{
    return animalsToFeed;
}
}

