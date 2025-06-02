using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // El jugador
    private Vector3 initialOffset;

    void Start()
    {
        if (target != null)
        {
            initialOffset = transform.position - target.position;
        }

        LockCursor();
    }

    void Update()
    {
        HandleCursor();
    }

    void LateUpdate()
    {
        if (target == null) return;

        // Mantiene la posición inicial relativa al jugador
        transform.position = target.position + initialOffset;
        // No se cambia la rotación, permanece como la pusiste en el editor
    }

    void HandleCursor()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnlockCursor();
        }
        else if (Input.GetMouseButtonDown(0) && Cursor.lockState != CursorLockMode.Locked)
        {
            LockCursor();
        }
    }

    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
