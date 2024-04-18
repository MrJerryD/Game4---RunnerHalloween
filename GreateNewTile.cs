using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GreateNewTile : MonoBehaviour
{
    //public GameObject tilePrefab;
    public float _speed; // скорость другого кусочка, не основного префаба
    public int maxCount;
    public List<MoveTile> tiles = new List<MoveTile>(); // взяли копмонент с другого кода для задания скорости
    public GameObject[] tilePrefabs;

    public Transform tileFolder;

    private void Start()
    {
        tiles.First().speed = _speed;
        for (int i = 0; i < maxCount; i++)
        {
            GreateTiles();
        }
    }

    private void Update()
    {
        if (tiles.Count < maxCount)
        {
            GreateTiles();
        }
    }

    private void GreateTiles()
    {
        float offset = 10.0f; // Измените это значение на то, которое подходит

        // Выбираем случайный префаб из массива
        GameObject randomTilePrefab = tilePrefabs[Random.Range(0, tilePrefabs.Length)];

        GameObject newTileObject = Instantiate(randomTilePrefab, tiles.Last().transform.position + Vector3.forward * offset, Quaternion.identity);

        MoveTile newMoveTile = newTileObject.GetComponent<MoveTile>();
        newMoveTile.speed = _speed;
        tiles.Add(newMoveTile);

        newTileObject.transform.SetParent(tileFolder); // это для того тчобы префабами не забивать иерархию 
    }


    private void OnTriggerEnter(Collider other)
    {
        tiles.Remove(other.GetComponent<MoveTile>()); // удаляем компонент со списка который столкнулся с тригером
        Destroy(other.gameObject);
    }
}
