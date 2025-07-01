
using UnityEngine;

public class MoveCam : BaseMonoBehaviour
{
   
    public float smoothSpeed = 1;  // Tốc độ làm mượt camera

    public Vector2 minBounds = Vector2.zero;
    public Vector2 maxBounds = new Vector2(27f, 0);

    private void FixedUpdate()
    {
       
        this.Moving();
    }
    protected virtual void Moving()
    {
        Vector3 desiredPosition = transform.position + new Vector3( InputManager.Instance.HorizontalInput,0,0);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Giới hạn vị trí của camera trong phạm vi bản đồ
            smoothedPosition.x = Mathf.Clamp(smoothedPosition.x, minBounds.x, maxBounds.x);
            smoothedPosition.y = Mathf.Clamp(smoothedPosition.y, minBounds.y, maxBounds.y);

            transform.parent.position = smoothedPosition;
        
    }

}
