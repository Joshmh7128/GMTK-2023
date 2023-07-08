using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class DummyCameraEditorCheck : MonoBehaviour
{
    /// <summary>
    ///  script exists to turn on the dummy camera if we are in the editor, and turn it off in builds
    /// </summary>

    // Start is called before the first frame update
    void Start()
    {
        if (Application.isEditor)
        {
            gameObject.GetComponent<Camera>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<Camera>().enabled = false;
        }
    }
}
