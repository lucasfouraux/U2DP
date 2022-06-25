using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class PointsUI : MonoBehaviour {
    private TextMeshProUGUI pointsText; 
    public UnityEvent onTextChange;

    private void Awake() {
        pointsText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetPoints(int val) {
        pointsText.SetText(val.ToString());
        onTextChange?.Invoke();
    }
}
