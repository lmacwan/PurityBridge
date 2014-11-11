using PurityBridge.Live;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Xml;
using umbraco.MacroEngines;

/// <summary>
/// Summary description for SmartService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class SmartBlogService : System.Web.Services.WebService
{
    /// <summary>
    /// The constructor
    /// </summary>
    public SmartBlogService()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    /// <summary>
    /// Returns all the comments below a given page
    /// </summary>
    [WebMethod]
    public List<Comment> GetComments(int intId)
    {
        List<Comment> returnVal = new List<Comment>();

        XmlDocument document = new XmlDocument();
        document.Load(AppDomain.CurrentDomain.BaseDirectory + "/config/SmartBlog.config");

        if (!bool.Parse(document.GetElementsByTagName("masterDisableComments")[0].InnerText))
        {
            DynamicNode CurrentPage = new DynamicNode(intId);
            dynamic comments = CurrentPage.Descendants("SmartBlogComment");

            foreach (DynamicNode comment in comments)
            {
                returnVal.Add(new Comment(comment.Id, 
                    comment.Name, 
                    comment.GetPropertyValue("smartBlogWebsite"), 
                    Convert.ToDateTime(comment.GetPropertyValue("CreateDate").ToString()).ToString(SmartBlogLibraries.Helpers.DateTime.DateFormatNormalWithTime), 
                    comment.GetPropertyValue("smartBlogComment")));
            }
        }

        return returnVal;
    }

    /// <summary>
    /// Returns all the comments below a given page
    /// </summary>
    [WebMethod]
    public string SubscribeNewsletter(string email)
    {
        var success = false;
        var msg = string.Empty;

        if (MailUtility.SendSingleMail(email))
        {
            success = true;
            msg = "Your request has been submitted successfully.";
        }

        return new JavaScriptSerializer().Serialize(new { success = success, message = msg });
    }

    /// <summary>
    ///Adds a new comment to an existing post and if set in the config, will use the admins email address to provide a summary.
    /// </summary>
    [WebMethod]
    public object AddComment(int intId, string strName, string strWebsite, string strEmail, string strComment)
    {
        if(intId > 0 && !string.IsNullOrEmpty(strName))
        {
            XmlDocument document = new XmlDocument();
            document.Load(AppDomain.CurrentDomain.BaseDirectory + "/config/SmartBlog.config");

            try
            {
                Dictionary<string, object> properties = new Dictionary<string, object>() { 
                        {"smartBlogName", strName},
                        {"smartBlogEmail", strEmail},
                        {"smartBlogWebsite", strWebsite},
                        {"smartBlogComment", strComment}
                    };

                bool publish = !string.IsNullOrEmpty(document.GetElementsByTagName("autoApproveComments")[0].InnerText) ? bool.Parse(document.GetElementsByTagName("autoApproveComments")[0].InnerText) : false;

                SmartBlogLibraries.Helpers.Cms.CreateContentNode(strName, "SmartBlogComment", properties, intId, publish);
            }
            catch(Exception)
            {
                return new { success = false };
            }

            DynamicNode node = new DynamicNode(intId);

            if (!string.IsNullOrEmpty(document.GetElementsByTagName("moderatorCommentEmail")[0].InnerText))
            {
                StringBuilder emailBody = new StringBuilder();
                emailBody.AppendLine("This is an automated message; please do not reply.");
                emailBody.AppendLine("--------------------------------------------------");
                emailBody.AppendLine();
                emailBody.AppendLine(strName + " posted a comment on '" + node.Name + "' at " + DateTime.Now.ToString() + " with the following text:");
                emailBody.AppendLine(strComment);
                emailBody.AppendLine();
                emailBody.AppendLine("--------------------------------------------------");
                emailBody.AppendLine();
                emailBody.AppendLine("The comment was posted here: http://" + HttpContext.Current.Request.Url.Host + node.Url + " please log into the content management system to approve it and make it visible on the website.");
                emailBody.AppendLine();
                emailBody.AppendLine("Regards,");
                emailBody.AppendLine("Support");

                try
                {
                    SmartBlogLibraries.Helpers.Mailing.SendEmail(document.GetElementsByTagName("moderatorCommentEmail")[0].InnerText, "support@101ltd.com", "Comment Added", emailBody.ToString(), strEmail);
                }
                catch (Exception)
                {

                }
            }

            return new { success = true };
        }

        return new { success = false };
    }

    /// <summary>
    /// Container for the data items that will be pushed back to the client via JSON
    /// </summary>
    public class Comment
    {
        public int intId;
        public string strName;
        public string strWebsite;
        public string strDate;
        public string strComment;

        public Comment(int intId, string strName, string strWebsite, string strDate, string strComment)
        {
            this.intId = intId;
            this.strName = strName;
            this.strWebsite = strWebsite;
            this.strDate = strDate;
            this.strComment = strComment;
        }
    }
}
