using Microsoft.FluentUI.AspNetCore.Components;

namespace YOCA.Fluent.Models;

public class CustomIcons
{

}

public static class FontAwesome
{
    public static Icon Icon(string iconName) => new Icon(iconName, IconVariant.Regular, IconSize.Size16, $"<span class=\"{iconName}\"></span>");
}
