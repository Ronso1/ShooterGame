using UnityEngine;
public class ReturnPlayer : MonoBehaviour
{
    [SerializeField] private Collider _player;
    [SerializeField] private Transform _teleportPosition;
    private void OnTriggerEnter(Collider collision)
    {
        if (_player == collision) _player.transform.position = _teleportPosition.position;
    }
}
