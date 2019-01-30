using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using StockManagementProjectApp.BLL;
using StockManagementProjectApp.DAL.Modals;
using StockManagementProjectApp.DAL.Modals.ViewModel;

namespace StockManagementProjectApp.UI
{
    public partial class ViewSalesBetweenTwoDatesUI : System.Web.UI.Page
    {
        ViewBetweenTwoDatesManager viewBetweenTwoDatesManager = new ViewBetweenTwoDatesManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            string fromDate = fromDateTextBox.Text;
            string toDate = toDateTextBox.Text;
            string actionType = "sell";

            if (fromDate.Trim()=="" || toDate.Trim()=="")
            {
                outputLabel.Text = "Enter valid date";
                return;
            }

            DateTime myfromDate = DateTime.ParseExact(fromDate,"yyyy/mm/dd",System.Globalization.CultureInfo.InvariantCulture);
            DateTime mytoDate = DateTime.ParseExact(toDate,"yyyy/mm/dd",System.Globalization.CultureInfo.InvariantCulture);
            if (myfromDate > mytoDate)
            {
                outputLabel.Text = "Invalid Date Selection";
                searchAndViewGridView.DataBind();
                return;
            }
            outputLabel.Text = String.Empty;

            List<StockOutViewModel> stockOutList = viewBetweenTwoDatesManager.GetSellBetweenTwoDate(fromDate,toDate,actionType);
            if (stockOutList.Count == 0)
            {
                outputLabel.Text = "No Item Exist In this Time Period";
                searchAndViewGridView.DataBind();
                return;
            }
            outputLabel.Text = String.Empty;
            
            List<TotalSale> totalSaleList = new List<TotalSale>();
            
            foreach (StockOutViewModel stockOutItem in stockOutList)
            {

                int pointer = 0;
                TotalSale totalSale = new TotalSale();
                if (totalSaleList.Count == 0)
                {
                    totalSale.ItemId = stockOutItem.ItemId;
                    totalSale.ItemName = stockOutItem.ItemName;
                    totalSale.CompanyName = stockOutItem.CompanyName;
                    totalSale.TotalSaleAmount = stockOutItem.Quantity;
                    totalSaleList.Add(totalSale);
                    continue;
                }
                foreach (TotalSale Sale in totalSaleList)
                {
                    if (Sale.ItemId == stockOutItem.ItemId)
                    {
                        Sale.TotalSaleAmount = Sale.TotalSaleAmount + stockOutItem.Quantity;
                        pointer++;
                    }
                    else
                    {                       
                        totalSale.ItemId = stockOutItem.ItemId;
                        totalSale.ItemName = stockOutItem.ItemName;
                        totalSale.CompanyName = stockOutItem.CompanyName;
                        totalSale.TotalSaleAmount = stockOutItem.Quantity;
                    }
                }

                if (pointer == 0)
                {
                    totalSaleList.Add(totalSale);
                }

            }

            searchAndViewGridView.DataSource = totalSaleList;
            searchAndViewGridView.DataBind();
        }

        protected void exportToPdf_Click_Click(object sender, EventArgs e)
        {
            string fromDate = fromDateTextBox.Text;
            string todate = toDateTextBox.Text;
            if (searchAndViewGridView.Rows.Count > 1)
            {
                ExportToPdf(searchAndViewGridView, "TotalSalesFrom" + fromDate + "To" + todate);
            }
            else
            {
                outputLabel.Text = "Nothing to download";
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the runtime error "  
            //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."  
        }
        

        public void ExportToPdf(GridView gridView, string fileName)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=" + fileName + ".pdf");
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