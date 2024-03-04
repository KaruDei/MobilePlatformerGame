using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private Vector3 _position;
    private void Update()
    {
        _position = _player.position;
        _position.z = -10;
        transform.position = Vector3.Lerp(transform.position, _position, Time.deltaTime);
    }
}
