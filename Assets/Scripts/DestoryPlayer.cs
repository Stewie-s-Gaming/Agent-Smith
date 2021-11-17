using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestoryPlayer : MonoBehaviour
{
    [SerializeField] string triggerTag;
    [SerializeField] string sceneName;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == triggerTag)
        {
            SceneManager.LoadScene(sceneName);    // Input can either be a serial number or a name; here we use name.
        }
    }
}
