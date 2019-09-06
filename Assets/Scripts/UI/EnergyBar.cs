using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    private Image energyBar;

    private void Awake() {
        energyBar = gameObject.transform.GetComponent<Image>();
    }

    public void UpdateBar(float charge, float maxCharge) {
        energyBar.fillAmount = (charge / maxCharge);
    }

}
