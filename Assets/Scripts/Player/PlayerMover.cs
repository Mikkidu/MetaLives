using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(ShipHP), typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private DynamicJoystick _moveJoystick;
    [SerializeField] private float _moveSpeed = 5;

    private float _rotateSpeed = 0;
    private Rigidbody2D _rb;
    private ShipHP _shipHPScript;
    private PhotonView _photonView;

    private void Awake()
    {
        _photonView = GetComponent<PhotonView>();
        if (!_photonView.IsMine)
            return;
        _rb = GetComponent<Rigidbody2D>();
        _shipHPScript = GetComponent<ShipHP>();
        _photonView = GetComponent<PhotonView>();
        _moveJoystick = GameUI.gameUI._moveJoystick;
        Camera.main.gameObject.GetComponent<CameraController>().playerTransform = transform;
    }

    private void FixedUpdate()
    {
        if (!_photonView.IsMine)
            return;

        if (_shipHPScript.IsAlive)
        {
            Vector2 direction;
#if PLATFORM_ANDROID
            if (_moveJoystick.Direction.magnitude != 0)
            {
                direction = new Vector2(_moveJoystick.Horizontal, _moveJoystick.Vertical).normalized;
#else
            float horizontalAxis = Input.GetAxis("Horizontal");
            float verticalAxis = Input.GetAxis("Vertical");
            if (horizontalAxis != 0 & verticalAxis != 0)
            {
                direction = new Vector2(horizontalAxis, verticalAxis);
            //Move(new Vector2(_moveJoystick.Horizontal, _moveJoystick.Vertical).normalized);
#endif
                Move(direction.normalized);
            }
        }

    }


    protected void Move(Vector2 direction)
    {
        //if (direction != Vector2.zero) _animator.SetBool("IsMoving", true);
        //else _animator.SetBool("IsMoving", false);
        //_animator.SetFloat("MoveY", direction.y);
        
        float deltaAngle = Vector2.SignedAngle(transform.up, direction);
        float newAngle = Mathf.SmoothDampAngle(_rb.rotation, _rb.rotation + deltaAngle, ref _rotateSpeed, 0.5f);
        Debug.Log(_moveJoystick.Horizontal);
        if (Mathf.Abs(_rb.rotation) > 360)
            _rb.rotation %= 360;
        _rb.MoveRotation(newAngle);
        _rb.velocity = transform.up * _moveSpeed;
    }

}
