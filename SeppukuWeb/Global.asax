<%@ Application Language="C#" %>
<%@ Import Namespace="System.Xml" %>
<%@ Import Namespace="System.Web.Configuration" %>
<%@ Import Namespace="System.Threading" %>
<%@ Import Namespace="System.Globalization" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Reflection" %>

<script RunAt="server">
  
  /// <summary>
  /// Application Error handler
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
    //void Application_Error(object sender, EventArgs e)
    //{
    //    HttpContext context = ((HttpApplication)sender).Context;
    //    Exception ex = context.Server.GetLastError();
    //    if (ex == null || !(ex is HttpException) || (ex as HttpException).GetHttpCode() == 404)
    //        return;

    //    StringBuilder sb = new StringBuilder();

    //    try
    //    {
    //        sb.Append("Url : " + context.Request.Url);
    //        sb.Append(Environment.NewLine);
    //        sb.Append("Raw Url : " + context.Request.RawUrl);
    //        sb.Append(Environment.NewLine);

    //        while (ex != null)
    //        {
    //            sb.Append("Message : " + ex.Message);
    //            sb.Append(Environment.NewLine);
    //            sb.Append("Source : " + ex.Source);
    //            sb.Append(Environment.NewLine);
    //            sb.Append("StackTrace : " + ex.StackTrace);
    //            sb.Append(Environment.NewLine);
    //            sb.Append("TargetSite : " + ex.TargetSite);
    //            sb.Append(Environment.NewLine);
    //            ex = ex.InnerException;
    //        }
    //    }
    //    catch (Exception ex2)
    //    {
    //        sb.Append("Error logging error : " + ex2.Message);
    //    }

    //    if (BlogSettings.Instance.EnableErrorLogging)
    //        Utils.Log(sb.ToString());

    //    context.Items["LastErrorDetails"] = sb.ToString();
    //    context.Response.StatusCode = 500;
    //    Server.ClearError();

    //    // Server.Transfer is prohibited during a page callback.
    //    System.Web.UI.Page currentPage = context.CurrentHandler as System.Web.UI.Page;
    //    if (currentPage != null && currentPage.IsCallback)
    //        return;
        
    //    //context.Server.Transfer("~/Blog/error.aspx");
    //}

    /// <summary>
    /// Hooks up the available extensions located in the App_Code folder.
    /// An extension must be decorated with the ExtensionAttribute to work.
    /// <example>
    ///  <code>
    /// [Extension("Description of the SomeExtension class")]
    /// public class SomeExtension
    /// {
    ///   //There must be a parameterless default constructor.
    ///   public SomeExtension()
    ///   {
    ///     //Hook up to the SeppukuOnline.NET events.
    ///   }
    /// }
    /// </code>
    /// </example>
    /// </summary>
    void Application_Start(object sender, EventArgs e)
    {
    }
 
</script>