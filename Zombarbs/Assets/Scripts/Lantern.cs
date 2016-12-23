using UnityEngine;
using System.Collections;

public class Lantern : MonoBehaviour {
    void Update() {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion rot = Quaternion.LookRotation(transform.position - mousePos, Mathf.Sign(transform.lossyScale.x) * Vector3.forward);
        float z = (rot.eulerAngles.z + 270) % 360;
        z -= 180;
        z = Mathf.Clamp(z, -90, 90);
        z += 180;
        z = (z + 180) % 360;

        //z = (z < 270 && z > 180) ? 90 : z;
        //clamp [270, 90]
        //x + 90
        //clamp [0, 180]
        //(x + 270) % 360
        //rot = Quaternion.Euler(rot.eulerAngles.x, rot.eulerAngles.y, Mathf.Clamp(rot.eulerAngles.z, -60, 60));
        rot.eulerAngles = new Vector3(0, 0, z);

        Debug.Log("z: " + z);
        Debug.Log("rot.eulerAngles: " + rot.eulerAngles.z);
        transform.rotation = rot;
    }
}
