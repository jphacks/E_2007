using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputButton : MonoBehaviour
{
    [SerializeField] GameObject field;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        field.SetActive(true);
    }

    public void InputEnd()
    {
        field.SetActive(false);
    }
}
