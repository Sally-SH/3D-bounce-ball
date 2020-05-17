using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star_item : MonoBehaviour
{
    public float rotateSpeed;
    // Start is called before the first frame update
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 1) * rotateSpeed * Time.deltaTime);
    }


}
