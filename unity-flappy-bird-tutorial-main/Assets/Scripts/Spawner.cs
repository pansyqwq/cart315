using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 2f;
    public float verticalGap = 3f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        if (prefabs == null || prefabs.Length == 0)
            return;

        int randomIndex = Random.Range(0, prefabs.Length);

        if (prefabs[randomIndex] == null)
            return;

        GameObject obstacle = Instantiate(
            prefabs[randomIndex],
            transform.position,
            Quaternion.identity
        );

        obstacle.transform.position +=
            Vector3.up * Random.Range(minHeight, maxHeight);

        // Only Pipes prefabs need a vertical gap
        Pipes pipes = obstacle.GetComponent<Pipes>();

        if (pipes != null)
        {
            pipes.gap = verticalGap;
        }
    }
}