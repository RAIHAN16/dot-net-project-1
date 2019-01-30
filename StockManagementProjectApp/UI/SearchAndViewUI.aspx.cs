using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using StockManagementProjectApp.BLL;

namespace StockManagementProjectApp.UI
{
    public partial class SearchAndViewUI : System.Web.UI.Page
    {
        private ItemManager itemManager = new ItemManager();
        private CompanyManager companyManager = new CompanyManager();
        private CatagoryManager catagoryManager = new CatagoryManager();
        private SearchAndViewManager searchAndViewManager = new SearchAndViewManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                companyDropDownList.DataSource = companyManager.GetAllCompanies();
                companyDropDownList.DataValueField = "Id";
                companyDropDownList.DataTextField = "CompanyName";
                companyDropDownList.DataBind();
                companyDropDownList.Items.Insert(0, "Select Company");

                catagoryDropDownList.DataSource = catagoryManager.GetAllCatagories();
                catagoryDropDownList.DataValueField = "Id";
                catagoryDropDownList.DataTextField = "CatagoryName";
                catagoryDropDownList.DataBind();
                catagoryDropDownList.Items.Insert(0, "Select Catagory");
            }
            
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            outputLabel.Text = String.Empty;
            searchAndViewGridView.DataSource = null;
            searchAndViewGridView.DataBind();

            if (companyDropDownList.SelectedIndex !=0 && catagoryDropDownList.SelectedIndex !=0)
            {
                int companyId = Convert.ToInt32(companyDropDownList.SelectedValue);
                int catagoryId = Convert.ToInt32(catagoryDropDownList.SelectedValue);
                if (searchAndViewManager.GetItemsByCompanyIdAndCatagoryId(companyId, catagoryId) != null)
                {
                    searchAndViewGridView.DataSource = searchAndViewManager.GetItemsByCompanyIdAndCatagoryId(companyId, catagoryId);
                    searchAndViewGridView.DataBind();

                    companyDropDownList.SelectedIndex = 0;
                    catagoryDropDownList.SelectedIndex = 0;
                }
                else
                {
                    outputLabel.Text = "This Catagory Item not present in this Company";
                }
            }
            else if (companyDropDownList.SelectedIndex != 0)
            {
                int companyId = Convert.ToInt32(companyDropDownList.SelectedValue);
                if (itemManager.GetItemsByCompanyId(companyId)==null)
                {
                    outputLabel.Text = "No Items Exist form this Company";
                    return;
                }
                searchAndViewGridView.DataSource = itemManager.GetItemsByCompanyId(companyId);
                searchAndViewGridView.DataBind();

                companyDropDownList.SelectedIndex = 0;
                catagoryDropDownList.SelectedIndex = 0;
            }
            else if (catagoryDropDownList.SelectedIndex != 0)
            {
                int catagoryId = Convert.ToInt32(catagoryDropDownList.SelectedValue);
                if (searchAndViewManager.GetItemsByCatagoryId(catagoryId)==null)
                {
                    outputLabel.Text = "No Items Exist Form This Catagory";
                    return;
                }
                searchAndViewGridView.DataSource = searchAndViewManager.GetItemsByCatagoryId(catagoryId);
                searchAndViewGridView.DataBind();

                companyDropDownList.SelectedIndex = 0;
                catagoryDropDownList.SelectedIndex = 0;
            }
            else
            {
                searchAndViewGridView.DataSource = searchAndViewManager.GetAllItems();
                searchAndViewGridView.DataBind();
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the runtime error "  
            //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."  
        }  
        protected void exportToPdf_Click(object sender, EventArgs e)
        {
            if (searchAndViewGridView.Rows.Count>1)
            {
                ExportToPdf(searchAndViewGridView,"ItemSummery");
            }
            else
            {
                outputLabel.Text = "Nothing to download";
            }
        }

        public void ExportToPdf(GridView gridView,string fileName)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename="+fileName+".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gridView.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 30f, 30f, 30f, 30f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
            gridView.AllowPaging = true;
            gridView.DataBind();
        }

    }
}