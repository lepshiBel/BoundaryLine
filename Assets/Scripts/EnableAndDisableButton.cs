using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableAndDisableButton : MonoBehaviour
{
    [SerializeField] private GameObject objectToEnable;
    [SerializeField] private GameObject objectToDisable;

    // Start is called before the first frame update
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() => HandleClick(objectToEnable, objectToDisable));
    }

    private void HandleClick(GameObject objectToEnable, GameObject objectToDisable)
    {
        objectToDisable.SetActive(false);
        objectToEnable.SetActive(true);
    }
}
