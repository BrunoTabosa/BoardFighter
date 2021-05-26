using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public TextMeshProUGUI healthValue;
    public TextMeshProUGUI attackValue;
    public TextMeshProUGUI actionsValue;

    private PlayerController controller;

    public void UpdateUI(PlayerController player = null)
    {
        if(controller == null)
        {
            if (player == null) return;
            controller = player;
        }

        healthValue.text = controller.health.ToString();
        attackValue.text = controller.attack.ToString();
        actionsValue.text = controller.remaingActions.ToString();
    }
}
