using UnityEngine;
using Plane = UnityEngine.Plane;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerMovement : MonoBehaviour
{
    private Camera _cam;
    private Plane _playerPlane;

    [Range(0f,1f)]
    public float Lerp;

    [Range(0f,1f)]
    public float Border;
    public float MoveSpeed;
    public float Epsilon;

    private Vector3 _bottomLeft;
    private Vector3 _topRight;

    public bool MouseMove;

    public ParticleSystem TheParticles;
    
    void Start()
    {
        _cam = Camera.main;
        _playerPlane = new Plane(Vector3.up, Vector3.zero);

        // Get the screen resolution in pixels
        Vector2 screenDimensions = new Vector2(Screen.width, Screen.height);
        
        // Take the world points for the borders
        Ray bottomLeftRay = _cam.ScreenPointToRay(screenDimensions * Border);
        _playerPlane.Raycast(bottomLeftRay, out float bottomLeftDistance);
        _bottomLeft = bottomLeftRay.GetPoint(bottomLeftDistance);

        Ray topRightRay = _cam.ScreenPointToRay(screenDimensions * (1 - Border));
        _playerPlane.Raycast(topRightRay, out float topRightDistance);
        _topRight = topRightRay.GetPoint(topRightDistance);
    }


    void Update()
    {
        // If the mouse movement is not active, and the mouse button is clicked
        // activate mouse movement
        if (!MouseMove && Input.GetMouseButtonDown(0)) MouseMove = true;
        
        // Keyboard/Controller movement
        Vector2 keyboardInput = new Vector2(Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")).normalized;
        if (keyboardInput.magnitude > 0) MouseMove = false;
        Vector3 keyboardDirection = new Vector3(keyboardInput.x, 0f, keyboardInput.y);
        transform.position += keyboardDirection * (MoveSpeed * Time.deltaTime);

        if (MouseMove)
        {
            Vector2 mousePos = Input.mousePosition;
            Ray ray = _cam.ScreenPointToRay(mousePos);
            _playerPlane.Raycast(ray, out float point);
            Vector3 contactPoint = ray.GetPoint(point);

            Vector3 direction = (contactPoint - transform.position).normalized;

            Vector3 newPosition = transform.position + direction * (MoveSpeed * Time.deltaTime);

            if ((contactPoint - transform.position).magnitude > Epsilon)
                transform.position = Vector3.Lerp(transform.position, newPosition, Lerp);
        }


        float clampedHorizontal = Mathf.Clamp(transform.position.x, _bottomLeft.x, _topRight.x);
        float clampedVertical = Mathf.Clamp(transform.position.z, _bottomLeft.z, _topRight.z);

        transform.position = new Vector3(clampedHorizontal, 0f, clampedVertical);

        if (Input.GetKeyDown(KeyCode.T))
        {
            if (TheParticles.isPlaying)
            {
                TheParticles.Stop();
            }
            else
            {
                TheParticles.Play();
            }
            
        }
    }
}