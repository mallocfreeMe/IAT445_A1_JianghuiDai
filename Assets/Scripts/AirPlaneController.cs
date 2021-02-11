using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class AirPlaneController : MonoBehaviour
{
    public new Camera camera;
    public float forwardSpeed = 25f, straightSpeed = 7.5f, hoverSpeed = 5f;
    public float lookRateSpeed = 90f;
    public float rollSpeed = 90f, rollAcceleration = 3.5f;
    public AudioClip audioClip;

    private bool _isFlying;
    private float _activeForwardSpeed, _activeStraightSpeed, _activeHoverSpeed;
    private float _forwardAcceleration = 2.5f, _straightAcceleration = 2f, _hoverAcceleration = 2f;
    private Vector2 _lookInput, _screeCenter, _mouseDistance;
    private float _rollInput;
    private AudioSource _audioSource;

    private void Start()
    {
        _screeCenter.x = Screen.width * .5f;
        _screeCenter.y = Screen.height * .5f;
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_isFlying)
        {
            // play engine sound
            _audioSource.PlayOneShot(audioClip);
            
            // look at mouse position
            _lookInput.x = Input.mousePosition.x;
            _lookInput.y = Input.mousePosition.y;

            _mouseDistance.x = (_lookInput.x - _screeCenter.x) / _screeCenter.y;
            _mouseDistance.y = (_lookInput.y - _screeCenter.y) / _screeCenter.y;

            _mouseDistance = Vector2.ClampMagnitude(_mouseDistance, 1f);

            _rollInput = Mathf.Lerp(_rollInput, Input.GetAxisRaw("Roll"), rollAcceleration * Time.deltaTime);

            transform.Rotate(-_mouseDistance.y * lookRateSpeed * Time.deltaTime,
                _mouseDistance.x * lookRateSpeed * Time.deltaTime, _rollInput * rollSpeed * Time.deltaTime, Space.Self);

            // get input values for move forward, backward, left, right, up, down 
            _activeForwardSpeed = Mathf.Lerp(_activeForwardSpeed, Input.GetAxisRaw("Horizontal") * forwardSpeed,
                _forwardAcceleration * Time.deltaTime);

            _activeStraightSpeed = Mathf.Lerp(_activeStraightSpeed, Input.GetAxisRaw("Vertical") * straightSpeed,
                _straightAcceleration * Time.deltaTime);

            _activeHoverSpeed = Mathf.Lerp(_activeHoverSpeed, Input.GetAxisRaw("Hover") * hoverSpeed,
                _hoverAcceleration * Time.deltaTime);

            transform.position += -1 * Time.deltaTime * _activeForwardSpeed * transform.forward;
            transform.position += Time.deltaTime * _activeStraightSpeed * transform.right;
            transform.position += Time.deltaTime * _activeHoverSpeed * transform.up;
        }
    }

    // if the airplane collides with the player, then set isFlying to true
    // and activate the camera
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            _isFlying = true;
            camera.gameObject.SetActive(true);
        }
    }
}