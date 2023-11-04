using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Reloader : MonoBehaviour
{
    public GameObject pref;
    public GameObject copy;
    public TMP_InputField input;

    public void ReloadScene()
    {
        if (copy != null)
        {
            Destroy(copy);    
        }
        copy = Instantiate(pref, Vector3.zero, Quaternion.identity);
        int.TryParse(input.text, out copy.GetComponentInChildren<GeneratePathExample>().waypointsCount);
        Debug.Log(copy.GetComponentInChildren<GeneratePathExample>().waypointsCount);
        float r = Random.Range(0.0f, 1.0f);
        float g = Random.Range(0.0f, 1.0f);
        float b = Random.Range(0.0f, 1.0f);
        copy.GetComponentInChildren<TrailRenderer>().startColor = new Color(r, g, b);
    }

}
