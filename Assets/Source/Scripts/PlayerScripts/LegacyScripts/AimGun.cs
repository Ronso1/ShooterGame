using UnityEngine;
public class AimGun : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private void Update()
    {
        if (Input.GetMouseButtonDown(1)) _animator.SetBool("isAim", true);
        if (Input.GetMouseButtonUp(1)) _animator.SetBool("isAim", false);
    }
}