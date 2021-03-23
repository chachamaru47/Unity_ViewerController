using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewerController : MonoBehaviour
{
    [SerializeField]
    private GameObject _cameraObject = null;

    [SerializeField]
    private float _cameraSpeed = 10;

    [SerializeField]
    private float _cameraSensitive = 3;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        MoveUpdate();
        RotateUpdate();

        if (Input.GetKey(KeyCode.Escape))
        {
            Quit();
        }
    }

    private void MoveUpdate()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        float updown = (Input.GetKey(KeyCode.E) ? 1.0f : 0.0f) + (Input.GetKey(KeyCode.Q) ? -1.0f : 0.0f);

        if (_cameraObject != null)
        {
            _cameraObject.transform.position += _cameraObject.transform.forward * vertical * _cameraSpeed * Time.deltaTime;
            _cameraObject.transform.position += _cameraObject.transform.right * horizontal * _cameraSpeed * Time.deltaTime;
            _cameraObject.transform.position += _cameraObject.transform.up * updown * _cameraSpeed * Time.deltaTime;
        }
    }

    private void RotateUpdate()
    {
        float rotate_x = Input.GetAxis("Mouse X");
        float rotete_y = Input.GetAxis("Mouse Y");

        if (_cameraObject != null)
        {
            _cameraObject.transform.RotateAround(_cameraObject.transform.position, Vector3.up, rotate_x * _cameraSensitive);
            _cameraObject.transform.RotateAround(_cameraObject.transform.position, _cameraObject.transform.right, -rotete_y * _cameraSensitive);
        }
    }

    private void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
      UnityEngine.Application.Quit();
#endif
    }
}
