using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Enemy : MonoBehaviour, IInteractable
{
    [SerializeField] private float _lifeTime = 3f;
    private float _timer;
    
    private void OnEnable()
    {
        _timer = 0f;
    }
    
    private void Update()
    {
        _timer += Time.deltaTime;
        
        if (_timer >= _lifeTime)
            gameObject.SetActive(false);
    }
    
    public void Die()
    {
        gameObject.SetActive(false); 
    }
}
