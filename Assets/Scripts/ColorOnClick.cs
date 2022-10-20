using UnityEngine;

public class ColorOnClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1024, 768, true);
        GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f, 0.3f, 0.3f);
    }

}
