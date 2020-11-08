using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRM;

public class FaceAnim : MonoBehaviour
{
    private VRMBlendShapeProxy proxy;
    public GameObject komachi;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = komachi.GetComponent<Animator>();
    }


    void Update()
    {
        
        if(proxy == null)
        {
            proxy = komachi.GetComponent<VRMBlendShapeProxy>();
        }
        /*
        if (Input.GetKeyDown(KeyCode.Return))
        {
            proxy.SetValue(BlendShapePreset.Fun, 1f);
            anim.Play("reward");
            anim.SetInteger("animInt", 1);
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            proxy.SetValue(BlendShapePreset.Fun, 0f);
            //proxy.SetValue(BlendShapePreset.A, 1f);
            anim.Play("pose");
            anim.SetInteger("animInt", 0);
        }*/

        
    }

    [System.Obsolete]
    public void RewardTime()
    {
        proxy.SetValue(BlendShapePreset.Fun, 1f);
        anim.Play("reward");
        anim.SetInteger("animInt", 1);
    }

    [System.Obsolete]
    public void EndRewardTime()
    {
        proxy.SetValue(BlendShapePreset.Fun, 0f);
        anim.Play("pose");
        anim.SetInteger("animInt", 0);
    }
}
