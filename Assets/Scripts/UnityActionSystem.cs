using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityActionSystem : MonoBehaviour
{
    [SerializeField] private LayerMask unitlayermask;
    [SerializeField] private Unit selectedUnit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
        if(Input.GetMouseButtonDown(1))
        {
            if (TryHandleUnitSelection())
                return;
            selectedUnit.Settargetpos(Mouseworldpos.GetMousepos());
        }
    }

    private bool TryHandleUnitSelection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycasthit, float.MaxValue, unitlayermask))
        {
            if (raycasthit.transform.TryGetComponent<Unit>(out Unit unit))
            {
                selectedUnit = unit;
                return true;
            }
        }
        return false;
    }
}
