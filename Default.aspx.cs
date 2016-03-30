//brandon vicinus - march 29,2016

using System;
using System.Linq;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblOutput.Text = ""; //erase the text already on the page 
    }

    protected void ddlCompanies_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCompanies.SelectedIndex == 0)
        {
            return; //if the user selects the dummy variable in the ddl, 
        }

        var supplier = ddlCompanies.SelectedItem.Text;
        //need an integer variable of the supplier name to compare in the LINQ comparison
        int supplierInt = Convert.ToInt32(ddlCompanies.SelectedValue);
        using (NorthwindEntities myEntities = new NorthwindEntities())
        {
            Decimal base_cost = 0.0M;
            Decimal discount_amt = 0.0M;
            Decimal total_value = 0.0M;
            int counter = 0;

            //LINQ Query 
            var products =
                from product in myEntities.Products
                from orderDetail in myEntities.Order_Details
                where product.SupplierID == supplierInt &&
                   product.ProductID == orderDetail.ProductID
                select orderDetail;

            foreach (Order_Detail orderDtl in products) //add up the total cost 
            {
                base_cost = Decimal.Round(orderDtl.UnitPrice * orderDtl.Quantity, 2);
                discount_amt = Decimal.Round(base_cost * (Decimal)orderDtl.Discount, 2);
                total_value += base_cost - discount_amt; 
                counter++; //and keep track of the number of items 
            }

            lblOutput.Text = string.Format //display the output 
                ("Supplier {0} has {1} order items worth {2}"
                , supplier, counter, total_value.ToString("C2"));

        }//end using 

    }//end ddl function 

}//end class