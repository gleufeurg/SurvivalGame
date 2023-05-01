using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipSystem : MonoBehaviour
{
    #region Singleton

    public static TooltipSystem instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    [SerializeField] Tooltip tooltip;

    public void Show(string content, string header = "")
    {
        tooltip.SetText(content, header);
        tooltip.gameObject.SetActive(true);
    }
    public void Hide()
    {
        tooltip.gameObject.SetActive(false);
    }
}
