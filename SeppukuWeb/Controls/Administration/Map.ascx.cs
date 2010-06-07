using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_Kingdom_Map : System.Web.UI.UserControl
{
    public delegate void EventHandler(object sender, EventArgs e);
    public event EventHandler MapChanged; 

    public int MapId
    {
        get { return (ViewState[this.ID + "_MapId"] != null) ? (int)ViewState[this.ID + "_MapId"] : 0; }
        set { ViewState[this.ID + "_MapId"] = value; }
    }

    public void ChangeMode(DetailsViewMode mode)
    {
        DvMap.ChangeMode(mode);
    }

    public override void DataBind()
    {
        OdsMap.SelectParameters.Clear();
        OdsMap.SelectParameters.Add("MapId", MapId.ToString());
        if (MapId == 0)
        {
            DvMap.ChangeMode(DetailsViewMode.Insert);
        }
        else
        {
            DvMap.ChangeMode(DetailsViewMode.ReadOnly);
        }
        base.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.DataBind();
        }
    }
    protected void OdsMap_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
       // e.InputParameters["MapId"] = MapId;
    }
    protected void OdsMap_Deleting(object sender, ObjectDataSourceMethodEventArgs e)
    {
     //   OdsMap.DeleteParameters.Clear();
     //   OdsMap.DeleteParameters.Add("MapId", MapId.ToString());
    }
    protected void OdsMap_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.ReturnValue != null)
        {
            if (this.MapChanged != null)
            {
                MapChanged(this, new EventArgs());
            }
        }
    }
    protected void OdsMap_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (this.MapChanged != null)
        {
            MapChanged(this, new EventArgs());
        }
    }
    protected void OdsMap_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.ReturnValue != null)
        {
            if (this.MapChanged != null)
            {
                MapChanged(this, new EventArgs());
            }
        }
    }

    protected void BtnNextEpochOnClick(object sender, EventArgs e)
    {
        new Seppuku.Core.GameStateUpdater().Update(MapId);
    }

    
}
