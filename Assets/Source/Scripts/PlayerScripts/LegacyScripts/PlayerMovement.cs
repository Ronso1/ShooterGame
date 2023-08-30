using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private Transform _root;
    [SerializeField] private GameObject _camera, _weapon;
    [SerializeField] private float _speed, _speedBoost = 1f;
    [SerializeField] private float _gravityScale = 5f;
    public float health = 100f;
    private float _horizontal;
    private float _vertical;
    private bool _isGrounded = true;
    private bool _weaponHide = true;
    private void OnCollisionEnter() => _isGrounded = true;
    private void Update()
    {        
        _horizontal = Input.GetAxis(HorizontalAxis);
        _vertical = Input.GetAxis(VerticalAxis);
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _isGrounded = false;
            _rigidBody.AddForce((_gravityScale - 1) * _rigidBody.mass * Vector3.up);
        }
        WeaponActiveStatus();
    }
    private void FixedUpdate()
    {
        var moveDirection = _root.TransformDirection(new Vector3(_horizontal, 0, _vertical).normalized);
        if (Input.GetKey(KeyCode.LeftShift))
            _rigidBody.MovePosition(_rigidBody.transform.position + moveDirection * (_speed + _speedBoost) * Time.fixedDeltaTime);
        else
            _rigidBody.MovePosition(_rigidBody.transform.position + moveDirection * _speed * Time.fixedDeltaTime);
    }

    private void WeaponActiveStatus()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            _weaponHide = !_weaponHide;
            _weapon.SetActive(_weaponHide);
        }
    }
}