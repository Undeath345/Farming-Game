using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemToolPanel : ItemPanel
{
    [SerializeField] ToolBarController toolBarController;

    private void Start()
    {
        Init();
        toolBarController.onChange += HighLight;
        HighLight(0);
    }
    public override void OnClick(int id)
    {
        toolBarController.Set(id);
        buttons[id].Highlight(true);
    }

    int currentSelectedTool;

    public void HighLight(int id)
    {
        buttons[currentSelectedTool].Highlight(false);
        currentSelectedTool = id;
        buttons[currentSelectedTool].Highlight(true);
    }
}
