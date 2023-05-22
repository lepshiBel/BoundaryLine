#nullable enable

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Control
{
    Accelerometer,
    Drag
}

public class ControlManager : MonoBehaviour
{
    public static Control CurrentControl { get; private set; } = Control.Accelerometer;

    private const string ControlKey = "SelectedControl";

    public AccelerometerObjectMovement? accelerometerMovement;
    public DragMovement? dragMovement;

    private void Awake()
    {
        if (PlayerPrefs.HasKey(ControlKey))
        {
            int controlValue = PlayerPrefs.GetInt(ControlKey);
            CurrentControl = (Control)controlValue;
        }
        else
        {
            PlayerPrefs.SetInt(ControlKey, (int)CurrentControl);
        }

        if (PlayerPrefs.GetInt(ControlKey) == 0)
        {
            ApplyAccelerometerControl();
        }
        else if (PlayerPrefs.GetInt(ControlKey) == 1)
        {
            ApplyDragControl();
        }
    }

    public void SetControl(int control)
    {
        CurrentControl = (Control)control;
        PlayerPrefs.SetInt(ControlKey, control);

        if (PlayerPrefs.GetInt(ControlKey) == 0)
        {
            ApplyAccelerometerControl();
        }
        else if (PlayerPrefs.GetInt(ControlKey) == 1)
        {
            ApplyDragControl();
        }
    }

    private void ApplyAccelerometerControl()
    {
        if (accelerometerMovement != null && dragMovement != null)
        {
            accelerometerMovement.enabled = true;
            dragMovement.enabled = false;
        }
    }

    private void ApplyDragControl()
    {
        if (accelerometerMovement != null && dragMovement != null)
        {
            accelerometerMovement.enabled = false;
            dragMovement.enabled = true;
        }
    }
}
