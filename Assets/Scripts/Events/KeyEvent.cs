using UnityEngine;
using UnityEngine.Events;

public class KeyEvent : MonoBehaviour
{
    [SerializeField] private KeyCode activeKey;
    [SerializeField] private bool callableWhilePausing = false;
    [SerializeField] private UnityEvent onKey;
    private void Update()
    {
        if (Input.GetKey(activeKey)) 
        if (callableWhilePausing || Time.timeScale > 0)
        onKey?.Invoke();
    }
}

