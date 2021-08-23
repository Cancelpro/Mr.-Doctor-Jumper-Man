using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookMouse : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] enum RotationAxes{
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }
    [SerializeField] float sensitivityHor = 10.0f;
    [SerializeField] float sensitivityVert = 10.0f;
    [SerializeField] RotationAxes axes = RotationAxes.MouseXAndY;

    [SerializeField] float minimumVert = -45.0f;
    [SerializeField] float maximumVert = 45.0f;

    private float _rotationX = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(axes == RotationAxes.MouseX){
            //horizontal rotation code.
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);

        } else if (axes == RotationAxes.MouseY){
            //Vertical rotation code.
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

            float rotationY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        } else{
            //both vertical and horizontal rotation....
            
            transform.Rotate(transform.rotation.x, Input.GetAxis("Mouse X") * sensitivityHor, 0);
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

            float rotationY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
    }
}
