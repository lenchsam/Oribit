using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;
    private int _currentHealth;
    [SerializeField] private Collider2D _collider;

    public UnityEvent OnDeath = new UnityEvent();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _currentHealth = _maxHealth;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        TakeDamage(10);
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} has died.");
        OnDeath.Invoke();

        if (_collider != null)
        {
            _collider.enabled = false;
        }
        gameObject.SetActive(false);

        //Destroy(gameObject);
    }
    public void OnStart()
    {
        _collider.enabled = true;
        _currentHealth = _maxHealth;
        gameObject.SetActive(true);
    }
}
