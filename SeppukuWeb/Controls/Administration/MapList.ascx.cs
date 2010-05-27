using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_Kingdom_MapList : System.Web.UI.UserControl
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void GvMaps_SelectedIndexChanged(object sender, EventArgs e)
    {
        PnlMap.Visible = true;
        ASP.controls_administration_map_ascx UcMap =
            (ASP.controls_administration_map_ascx)PnlMap.FindControl("UcMap");
        UcMap.MapId = (int)GvMaps.SelectedValue;
        UcMap.DataBind();
    }
    protected void BtnDodaj_Click(object sender, EventArgs e)
    {
        PnlMap.Visible = true;
        ASP.controls_administration_map_ascx UcMap =
            (ASP.controls_administration_map_ascx)PnlMap.FindControl("UcMap");
        UcMap.MapId = 0;
        UcMap.DataBind();
    }

    protected void UcMap_Changed(object sender, EventArgs e)
    {
        GvMaps.DataBind();
    }
}
