using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _xBound;
    Rigidbody _playerRb;
    GameObject _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _gameManager = GameObject.Find("Game Manager");
    }

    // Update is called once per frame
    void Update()
    {
        PositionClamping();
    }
    private void FixedUpdate()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        if (_gameManager.GetComponent<GameManager>().gameStarted && !_gameManager.GetComponent<GameManager>().isGameOver)
        {
            float _horizontalMovement = Input.GetAxisRaw("Horizontal");

            _playerRb.MovePosition(transform.position + Vector3.right * _horizontalMovement * _speed * Time.deltaTime);
        }
    }
    void PositionClamping()
    {
        if (transform.position.x <= -_xBound)
        {
            transform.position = new Vector3(-_xBound, transform.position.y, transform.position.z);
        }
        else if (transform.position.x >= _xBound)
        {
            transform.position = new Vector3(_xBound, transform.position.y, transform.position.z);
        }
    }
}
