using UnityEngine;

public class FrogTestScript : MonoBehaviour
{
    SkinnedMeshRenderer skinnedMeshRenderer;
    public GameObject body;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        RootMotion();
        anim.SetTrigger("Crawl");
    }

    void RootMotion()
    {
        if (anim.applyRootMotion)
        {
            anim.applyRootMotion = false;
        }
    }

}
