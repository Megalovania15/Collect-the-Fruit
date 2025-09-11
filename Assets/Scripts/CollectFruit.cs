using UnityEngine;
using UnityEngine.InputSystem;

public class CollectFruit : MonoBehaviour
{
    //we require references to the input actions in the input system
    private InputAction mousePress;
    private InputAction mousePos;

    //we will need the camera to create a raycast from it using the position of the
    //mouse on the screen
    private Camera camera;

    //we will update the current mouse position everytime the mouse is moved
    private Vector2 currentMousePos;

    private Fruit fruitInfo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //we will set the camera variable to the main camera, as that is the only
        //camera we have
        camera = Camera.main;

        //need to find the input actions and store them as variables
        mousePress = InputSystem.actions.FindAction("CollectFruit");
        mousePos = InputSystem.actions.FindAction("MousePos");

        //this uses something (a struct) called a callback context to check and update
        //the mouse's position every time it is moved
        mousePos.performed += MouseMoved;
    }

    // Update is called once per frame
    void Update()
    {
        //checks to see if the mouse button has been pressed and executes the code
        if (mousePress.IsPressed())
        {
            DestroyObject();
        }
    }

    //need to get information about the current position of our mouse using a
    //callback
    void MouseMoved (InputAction.CallbackContext context)
    {
        currentMousePos = context.ReadValue<Vector2>(); 
    }

    void DestroyObject()
    {
        if (IsClickedOn())
        {
            Destroy(gameObject);
        }
    }

    //potentially move this to the camera, because it makes more sense there
    //checking to see when the object has been clicked
    bool IsClickedOn()
    { 
        //we create a 3D raycast from the camera using the mouse's current position
        //to destroy the fruit and add a number of points to our score
        Ray ray = camera.ScreenPointToRay(currentMousePos);
        //this tells us that the raycast hit something as well as
        //what the first object the raycast hit was
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

        if (hit)
        {
            //check to see whether the transform of the object hit by the raycast is the
            //same as this object's transform. If it is, return true, otherwise return
            //false.
            return hit.transform == transform;
        }
        return false;
    }

}
