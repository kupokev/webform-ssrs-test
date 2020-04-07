using Microsoft.Reporting.WebForms;
using System;
using System.Net;
using System.Web.UI;

namespace WebSsrsTest.Pages.Reports
{
    public partial class ReportTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // Set the processing mode for the ReportViewer to Remote  
                ReportViewer1.ProcessingMode = ProcessingMode.Remote;

                ReportViewer1.ServerReport.ReportServerCredentials = new CustomReportCredentials();
                
                ServerReport serverReport = ReportViewer1.ServerReport;

                // Set the report server URL and report path  
                serverReport.ReportServerUrl = new Uri("http://rkhrpt01.home.local/ReportServer");
                serverReport.ReportPath = "/TestReport/GeoLocation";
            }
        }

        public class CustomReportCredentials : IReportServerCredentials
        {
            public System.Security.Principal.WindowsIdentity ImpersonationUser
            {
                get { return null; }
            }

            public ICredentials NetworkCredentials
            {
                get
                {
                    //return new NetworkCredential(_UserName, _PassWord, _DomainName);
                    return System.Net.CredentialCache.DefaultCredentials;
                }
            }

            public bool GetFormsCredentials(out Cookie authCookie, out string user, out string password, out string authority)
            {
                authCookie = null;
                user = password = authority = null;
                return false;
            }
        }
    }
}