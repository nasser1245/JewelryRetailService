<%@ Application Language="C#" %>

<script runat="server">


    protected void Application_AuthenticateRequest(object sender, EventArgs e)
    {
        HttpCookie userCookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];

        if (userCookie != null && userCookie.Value != "")
        {
            FormsAuthenticationTicket userTicket = FormsAuthentication.Decrypt(userCookie.Value);
            Context.User = new System.Security.Principal.GenericPrincipal(new FormsIdentity(userTicket), userTicket.UserData.Split(new char[] { ',' }));
        }
    }
    
    
    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {
        //  HNewsPortalRazor.Tracking.Tracking.IncVisitStats(HNewsPortalRazor.Tracking.Tracking.StatType.Site, Request.ServerVariables["HTTP_USER_AGENT"]);

        // Code that runs when a new session is started
        //this.countMe();
        //System.Data.DataSet tmpDs = new System.Data.DataSet();
        //tmpDs.ReadXml(Server.MapPath("~/counter.xml"));
    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.


    }
       
</script>
