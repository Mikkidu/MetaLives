using UnityEngine;

public class ShipHP : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _maxHealth;

    private string _playerID;

    public delegate void OnHPChanged(int hp);
    public OnHPChanged OnHpChangedEvent;
    public bool isDead;

    public string GetPlayerID => _playerID;
    public bool IsAlive => !isDead;
    public int getMaxHealth => _maxHealth;

    private void Awake()
    {
        _health = _maxHealth;
    }

    private void Start()
    {
        if (OnHpChangedEvent != null) OnHpChangedEvent.Invoke(_health);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (OnHpChangedEvent != null) OnHpChangedEvent.Invoke(_health);
        if (_health <= 0) Death();
    }
    protected virtual void Death()
    {
        //_animator.SetBool("IsDead", true);
        isDead = true;
        GetComponent<Collider2D>().enabled = false;
    }

}
