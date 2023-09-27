using System.Collections;
using UnityEngine;

public class AR_Sound : MonoBehaviour
{
    [SerializeField] private AudioSource _shootAR;
    private bool _isPlaying = false;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && _isPlaying) StartCoroutine(ShootSoundDelay()); 
    }

    private void OnEnable() => StartCoroutine(ShootEnabled());

    private IEnumerator ShootSoundDelay()
    {
        var timeToWait = new WaitForSeconds(0.2f);
        _isPlaying = false;
        _shootAR.Play();
        yield return timeToWait;
        _isPlaying = true;
    }

    private IEnumerator ShootEnabled()
    {
        yield return new WaitForSeconds(0.7f);
        _isPlaying = true;
    }
}
