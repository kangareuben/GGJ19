using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarFactory : MonoBehaviour
{
    public Settings SpawnSettings { get { return _spawnSettings; } }
    [SerializeField]
    private GameObject _starPrefab;

    [SerializeField]
    private Settings _spawnSettings;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < _spawnSettings.startingSpawn; i++)
        {
            SpawnStar();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnStar()
    {
        GameObject starGO = Instantiate(_starPrefab);

        starGO.transform.position = new Vector3(Random.Range(_spawnSettings.spawnBounds.x, _spawnSettings.spawnBounds.x + _spawnSettings.spawnBounds.width),
                                                Random.Range(_spawnSettings.spawnBounds.y, _spawnSettings.spawnBounds.y + _spawnSettings.spawnBounds.height),
                                                0);


        StarMovement movement = starGO.GetComponent<StarMovement>();
        Vector3 velocity = new Vector3(Random.Range(_spawnSettings.minSpeed, _spawnSettings.maxSpeed),
                                        Random.Range(_spawnSettings.minSpeed, _spawnSettings.maxSpeed),
                                        0);

        movement.SetVelocity(velocity);
    }

    [System.Serializable]
    public struct Settings
    {
        public int startingSpawn;
        public float spawnDelay;
        public float maxSpeed;
        public float minSpeed;
        public Rect spawnBounds;
    }
}
