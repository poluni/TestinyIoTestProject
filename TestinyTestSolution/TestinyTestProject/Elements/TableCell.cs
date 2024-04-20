using OpenQA.Selenium;

namespace TestinyTestProject.Elements;

public class TableCell
{
    private UIElement _uiElement;

    public TableCell(UIElement uiElement)
    {
        _uiElement = uiElement;
    }

    public string Text => _uiElement.Text;
}