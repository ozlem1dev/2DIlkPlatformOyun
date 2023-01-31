using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private GameObject _camera;
    [SerializeField] private GameObject _player;
    private Vector3 playerPos;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag(tag:"Player");
    }

    private void Update()
    {
        playerPos = _player.transform.position;
        _camera.transform.position = new Vector3(x:playerPos.x, _camera.transform.position.y, z: playerPos.z - 1.0f);
    }
}
