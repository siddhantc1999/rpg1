using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouseworldpos : MonoBehaviour
{
    Vector3 mousepos;
    public static Mouseworldpos Instance;
    public Vector3 targetpos;
    [SerializeField] LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = GetMousepos();

    }
    public static Vector3 GetMousepos()
    {
       
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray,out RaycastHit raycasthit,float.MaxValue,Instance.layerMask);
        return raycasthit.point;
    }
}
