using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.InputSystem;

public class touchinput : MonoBehaviour
{
    [SerializeField] private TMP_Text debubtext;

    public void SingleTap(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            var touchPos = ctx.ReadValue<Vector2>();
            debubtext.text = touchPos.ToString();
        }
    }

}
