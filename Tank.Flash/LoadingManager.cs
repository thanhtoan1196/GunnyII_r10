﻿using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace Tank.Flash
{
    public class LoadingManager
    {
        public static int LoadingCount = 0;

        static LoadingManager()
        {
        }
    }
}
