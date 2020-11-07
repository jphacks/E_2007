using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRM;

public class FaceAnim : MonoBehaviour
{
    private VRMBlendShapeProxy proxy;
    public GameObject komachi;
    public Toggle egao;
    public Toggle defo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        
        if(proxy == null)
        {
            proxy = komachi.GetComponent<VRMBlendShapeProxy>();
        }

        if (egao.isOn)
        {
            proxy.SetValue(BlendShapePreset.Fun,1f);
        }
        else
        {
            proxy.SetValue(BlendShapePreset.Fun, 0f);
        }

        if (defo.isOn)
        {
            proxy.SetValue(BlendShapePreset.Neutral, 1f);
        }
        else
        {
            proxy.SetValue(BlendShapePreset.Neutral, 0f);
        }
    }
}
