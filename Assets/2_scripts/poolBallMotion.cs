using UnityEngine;

public class poolBallMotion : MonoBehaviour
{
    public float power = 10f;
    public float maxDrag = 5f;
    public Rigidbody rb;
    //public LineRenderer lr;

    Vector3 dragStartpos;
    Touch touch;

    private void Start()
    {
        rb = rb.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                DragStart();
            }
            if (touch.phase == TouchPhase.Moved)
            {
                Dragging();
            }
            if (touch.phase == TouchPhase.Ended)
            {
                DragRelease();
            }
        }
    }
    public void DragStart()
    {
        dragStartpos = Camera.main.ScreenToWorldPoint(touch.position);
        //dragStartpos.z = 0f;
        //lr.positionCount = 1;
        //lr.SetPosition(0, dragStartpos);
    }
    public void Dragging()
    {
        Vector3 draggingPos = Camera.main.ScreenToWorldPoint(touch.position);
        //draggingPos.z = 0f;
        //lr.positionCount = 2;
        //lr.SetPosition(1, draggingPos);
    }
    public void DragRelease()
    {
        //lr.positionCount = 0;
        Vector3 dragReleasePos = Camera.main.ScreenToWorldPoint(touch.position);
        //dragReleasePos.z = 0f;

        Vector3 force = dragStartpos - dragReleasePos;
        Vector3 clampedForce = Vector3.ClampMagnitude(force, maxDrag) * power;

        rb.AddForce(clampedForce, ForceMode.Impulse);
    }
}
