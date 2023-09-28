using System.Collections;
using UnityEngine;

public class AR_Sound : MonoBehaviour
{
    [SerializeField] private AudioSource _shootAR;
    [SerializeField] private float _timeToShootEnabled;
    [SerializeField] private float _timeDelay;
    private bool _isPlaying = false;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && _isPlaying) StartCoroutine(ShootSoundDelay()); 
    }

    private void OnEnable() => StartCoroutine(ShootEnabled());

    private void OnDisable() => _isPlaying = false;

    private IEnumerator ShootSoundDelay()
    {
        var timeToWait = new WaitForSeconds(_timeDelay);
        _isPlaying = false;
        _shootAR.Play();
        yield return timeToWait;
        _isPlaying = true;
    }

    private IEnumerator ShootEnabled()
    {
        yield return new WaitForSeconds(_timeToShootEnabled);
        _isPlaying = true;
    }
}
