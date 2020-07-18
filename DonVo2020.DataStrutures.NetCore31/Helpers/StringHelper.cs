using Microsoft.AspNetCore.Html;

namespace DonVo2020.DataStrutures.NetCore31.StringHelpers
{
    public static class StringHelper
    {
        public static HtmlString GetHtmlString(string result)
        {
            string temp = result.Replace("\n", "<br>");
            temp = temp.Replace(" ", "&nbsp;");
            temp = temp.Replace("\\", "<font color='blue'>\\</font>");
            temp = temp.Replace(".", "<font color='red'>.</font>");
            temp = temp.Replace("&nbsp;/", "<font color='lime'>&nbsp;/</font>");
            HtmlString html = new HtmlString("<html><b>" + temp + "</b></html>");
            return html;
        }
    }
}
