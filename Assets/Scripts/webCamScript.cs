using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebCamScript : MonoBehaviour {

    public RawImage webCameraPlane;
    private bool gyroEnabled;
    public Button firingButton;

    void Awake()
    {
        gyroEnabled = EnableGyro();
    }

    // Use this for initialization
    void Start()
    {

        if (Application.isMobilePlatform)
        {
            if (gyroEnabled)
            {
                GameObject cameraParent = new GameObject("camParent");
                cameraParent.transform.position = this.transform.position;
                this.transform.parent = cameraParent.transform;
                //cameraParent.transform.Rotate(Vector3.right, 90);
            }
            else
            {
                Application.Quit();
            }
        }
      
        WebCamTexture webCameraTexture = new WebCamTexture(Screen.currentResolution.height, Screen.currentResolution.width, 30);
        webCameraTexture.Play();
        //print(Screen.currentResolution.width);


        webCameraPlane.texture = webCameraTexture;
       
        //webCameraPlane.SetNativeSize();
        //print(webCameraPlane.GetComponent<RectTransform>().rect.width);

        firingButton.onClick.AddListener(OnButtonDown);
    }

    // Update is called once per frame
    void Update () {

        Quaternion cameraRotation = new Quaternion(Input.gyro.attitude.x, Input.gyro.attitude.y, -Input.gyro.attitude.z, -Input.gyro.attitude.w);
        this.transform.localRotation = cameraRotation;

   
	}

    private bool EnableGyro(){
        if (SystemInfo.supportsGyroscope) {
            Input.gyro.enabled = true;
            return true;
        }
        return false;
    }

    void OnButtonDown() {

    }
}
