using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] List<GameObject> _spawnObjects;
    [SerializeField] float _spawnTime;
    [SerializeField] float _spawnRate;
    GameObject _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ObjectSpawn", _spawnTime, _spawnRate);
        _gameManager = GameObject.Find("Game Manager");
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameManager.GetComponent<GameManager>().gameStarted && !_gameManager.GetComponent<GameManager>().isGameOver)
        {
            _spawnRate = Mathf.Lerp(_spawnRate, 0.5f, 0.0001f);
        }
    }

    void ObjectSpawn()
    {
        if (_gameManager.GetComponent<GameManager>().gameStarted && !_gameManager.GetComponent<GameManager>().isGameOver)
        {
            int _objectIndex = Random.Range(0, _spawnObjects.Count);
            float _randomX = Random.Range(-3.5f, 3.5f);
            Vector3 _spawnPosition = new Vector3(_randomX, 6, transform.position.z);

            Instantiate(_spawnObjects[_objectIndex], _spawnPosition, Quaternion.identity);
        }
    }
}
