using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] ParticleSystem _success;
    [SerializeField] ParticleSystem _failure;
    
    BoxCollider _col;
    Rigidbody _objectRb;
    GameObject _gameManager;
    GameObject _soundManager;
    // Start is called before the first frame update
    void Start()
    {
        _col = GetComponent<BoxCollider>();
        _objectRb = GetComponent<Rigidbody>();
        _gameManager = GameObject.Find("Game Manager");
        _soundManager = GameObject.Find("Sound Manager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Environment"))
        {
            _soundManager.GetComponent<SoundManager>().PlayFailure();
            Instantiate(_failure, transform.position, Quaternion.identity);
            _gameManager.GetComponent<GameManager>().ChangeLives();
            Destroy(_objectRb);
            Destroy(_col);
            Destroy(gameObject, 1.1f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        _soundManager.GetComponent<SoundManager>().PlaySuccess();
        Instantiate(_success, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
