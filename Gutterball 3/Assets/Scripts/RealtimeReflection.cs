using UnityEngine;
using System.Collections;

public class RealtimeReflection : MonoBehaviour
{
    public Transform camReflect;

    ReflectionProbe probe;
    
    void Awake()
    {
        probe = GetComponent<ReflectionProbe>();
    }
    
    void Update ()
    {
        probe.transform.position = new Vector3(camReflect.position.x, camReflect.position.y * -1, camReflect.position.z);

        probe.RenderProbe();
    }
}