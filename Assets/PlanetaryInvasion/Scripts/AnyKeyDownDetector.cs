using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnyKeyDownDetector : MonoBehaviour
{
    public UnityEvent AnyKeyUp;

    bool holdingDown;

    void Update()
    {
        if (Input.anyKey)
        {
            Debug.Log("A key is being pressed");
            holdingDown = true;
        }

        if (!Input.anyKey && holdingDown)
        {
            // this.enabled = false;
			AnyKeyUp.Invoke();
            Debug.Log("A key was released");
            holdingDown = false;
        }

    }
}
