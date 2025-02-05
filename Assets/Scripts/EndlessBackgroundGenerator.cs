// EndlessBackgroundGenerator.cs
using UnityEngine;
using System.Collections.Generic;

public class EndlessBackgroundGenerator : MonoBehaviour
{
    public GameObject backgroundPrefab; // Prefab del fondo
    public Transform player;            // Referencia a la nave espacial
    public float spawnDistance = 20f;   // Distancia para generar un nuevo fondo
    public float tileHeight = 20f;      // Altura de cada tile de fondo

    private List<GameObject> activeBackgrounds = new List<GameObject>();
    private float lastSpawnY;

    void Start()
    {
        // Instanciamos el primer fondo
        GameObject initialTile = Instantiate(backgroundPrefab, new Vector3(0,0, 14.47f), Quaternion.identity);
        activeBackgrounds.Add(initialTile);
        lastSpawnY = initialTile.transform.position.y + tileHeight;
    }

    void Update()
    {
        // Verifica si el jugador se acerca al último tile generado
        if (player.position.y + spawnDistance > lastSpawnY)
        {
            SpawnBackgroundTile();
        }

        // Elimina tiles que están muy por debajo del jugador para optimizar
        for (int i = activeBackgrounds.Count - 1; i >= 0; i--)
        {
            if (player.position.y - activeBackgrounds[i].transform.position.y > spawnDistance * 2)
            {
                Destroy(activeBackgrounds[i]);
                activeBackgrounds.RemoveAt(i);
            }
        }
    }

    void SpawnBackgroundTile()
    {
        Vector3 spawnPosition = new Vector3(0, lastSpawnY, 14.47f);
        GameObject newTile = Instantiate(backgroundPrefab, spawnPosition, Quaternion.identity);
        activeBackgrounds.Add(newTile);

        lastSpawnY += tileHeight;
    }
}
