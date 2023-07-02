using UnityEngine;

[RequireComponent(typeof(ShipHP))]
public class GunController : MonoBehaviour
{
    [SerializeField] private float _attackInterval = 0.5f;
    [SerializeField] private float _attackDistance;
    [SerializeField] private int _unitDamage;
    [SerializeField] private Projectile _projectile;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private DynamicJoystick _rotateJoystick;

    private float _attackTimer;
    private ShipHP _shipHPScript;

    private void Awake()
    {
        _shipHPScript = GetComponent<ShipHP>();
    }

    protected virtual void Update()
    {
        if (_shipHPScript.IsAlive)
        {
            Attack();
        }
    }

    public void Attack()
    {
        if (_attackTimer <= Time.realtimeSinceStartup)
        {
            Shoot();
            _attackTimer = Time.realtimeSinceStartup + _attackInterval;
        }
    }

    private void Shoot()
    {
        /*Projectile bullet = Instantiate(_projectile, _shootPoint.position, _shootPoint.rotation);
        bullet.Initialize(_unitDamage, gameObject.tag);
        if (Inventory.instance.CheckItemByID(_ammoID))
        {
            Vector3 toTarget = currentTarget.bounds.center - _shootPoint.position;
            float angle = Vector3.SignedAngle(Vector3.right, toTarget, Vector3.forward);
            Projectile bullet = Instantiate(_projectile, _shootPoint.position, Quaternion.Euler(Vector3.forward * angle));
            
            Inventory.instance.Spend(_ammoID, 1);
        }*/
    }
}
