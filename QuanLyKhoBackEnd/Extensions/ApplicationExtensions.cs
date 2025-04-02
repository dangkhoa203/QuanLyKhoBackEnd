
using QuanLyKhoBackEnd.Feature.Accounts;
using QuanLyKhoBackEnd.Feature.Accounts.ChangeEmail;
using QuanLyKhoBackEnd.Feature.Accounts.ChangeFullName;
using QuanLyKhoBackEnd.Feature.Accounts.ChangePassword;
using QuanLyKhoBackEnd.Feature.Accounts.Email;
using QuanLyKhoBackEnd.Feature.Accounts.ResetPassword;
using QuanLyKhoBackEnd.Feature.CustomerBuyReceipts;
using QuanLyKhoBackEnd.Feature.CustomerGroups;
using QuanLyKhoBackEnd.Feature.Customers;
using QuanLyKhoBackEnd.Feature.ExportForms;
using QuanLyKhoBackEnd.Feature.ImportForm;
using QuanLyKhoBackEnd.Feature.Products;
using QuanLyKhoBackEnd.Feature.ProductTypes;
using QuanLyKhoBackEnd.Feature.Stocks;
using QuanLyKhoBackEnd.Feature.VendorGroups;
using QuanLyKhoBackEnd.Feature.VendorReplenishReceipts;
using QuanLyKhoBackEnd.Feature.Vendors;


namespace QuanLyKhoBackEnd.Extensions {
    public static class ApplicationExtensions {

        private static void AddAccountService(this WebApplication app) {
            Login.MapEndpoint(app);
            Register.MapEndpoint(app);
            GetAccount.MapEndpoint(app);
            LogOut.MapEndpoint(app);
            ConfirmAccount.MapEndpoint(app);
            SendResetPasswordRequest.MapEndpoint(app);
            CheckAccountForReset.MapEndpoint(app);
            ResetPassword.MapEndpoint(app);
            SendChangePasswordRequest.MapEndpoint(app);
            ChangePassword.MapEndpoint(app);
            SendChangeEmailRequest.MapEndpoint(app);
            ChangeEmail.MapEndpoint(app);
            ChangeFullname.MapEndpoint(app);
        }
        private static void AddCustomerService(this WebApplication app) {
            AddCustomer.MapEndpoint(app);
            RemoveCustomer.MapEndpoint(app);
            UpdateCustomer.MapEndpoint(app);
            GetCustomer.MapEndpoint(app);
            GetCustomers.MapEndpoint(app);

            AddCustomerGroup.MapEndpoint(app);
            RemoveCustomerGroup.MapEndpoint(app);
            UpdateCustomerGroup.MapEndpoint(app);
            GetCustomerGroups.MapEndpoint(app);
            GetCustomerGroup.MapEndpoint(app);
        }
        private static void AddVendorService(this WebApplication app) {
            AddVendorGroup.MapEndpoint(app);
            RemoveVendorGroup.MapEndpoint(app);
            UpdateVendorGroup.MapEndpoint(app);
            GetVendorGroups.MapEndpoint(app);
            GetVendorGroup.MapEndpoint(app);

            AddVendor.MapEndpoint(app);
            RemoveVendor.MapEndpoint(app);
            UpdateVendor.MapEndpoint(app);
            GetVendors.MapEndpoint(app);
            GetVendor.MapEndpoint(app);
        }
        private static void AddProductService(this WebApplication app) {
            AddProductType.MapEndpoint(app);
            RemoveProductType.MapEndpoint(app);
            UpdateProductType.MapEndpoint(app);
            GetProductTypes.MapEndpoint(app);
            GetProductType.MapEndpoint(app);

            AddProduct.MapEndpoint(app);
            RemoveProduct.MapEndpoint(app);
            UpdateProduct.MapEndpoint(app);
            GetProducts.MapEndpoint(app);
            GetProduct.MapEndpoint(app);
        }
      
        private static void AddCustomerReceiptService(this WebApplication app) {
            AddCustomerReceipt.MapEndpoint(app);
            RemoveCustomerReceipt.MapEndpoint(app);
            GetCustomerReceipts.MapEndpoint(app);
            GetCustomerReceipt.MapEndpoint(app);
            GetCustomerReceiptForExport.MapEndpoint(app);
        }
        private static void AddVendorReceiptSevice(this WebApplication app) {
            AddVendorReceipt.MapEndpoint(app);
            RemoveVendorReceipt.MapEndpoint(app);
            GetVendorReceipts.MapEndpoint(app);
            GetVendorReceipt.MapEndpoint(app);
            GetVendorReceiptsForImport.MapEndpoint(app);
        }
        
        private static void AddStockService(this WebApplication app) {
            AddStocks.MapEndpoint(app);
            RemoveStock.MapEndpoint(app);
            UpdateStock.MapEndpoint(app);
            GetStocks.MapEndpoint(app);
        }
        private static void AddImportFormService(this WebApplication app) {
            AddImportForm.MapEndpoint(app);
            RemoveImportForm.MapEndpoint(app);
            GetImportForms.MapEndpoint(app);
            GetImportForm.MapEndpoint(app);
        }
        private static void AddExportFormService(this WebApplication app) {
            AddExportForm.MapEndpoint(app);
            RemoveExportForm.MapEndpoint(app);
            GetExportForms.MapEndpoint(app);
            GetExportForm.MapEndpoint(app);
        }

        public static void AddAllEndPoint(this WebApplication app) {
            AddAccountService(app);
            AddCustomerService(app);
            AddVendorService(app);
            AddProductService(app);
            AddCustomerReceiptService(app);
            AddVendorReceiptSevice(app);
            AddStockService(app);
            AddImportFormService(app);
            AddExportFormService(app);
        }
    }
}
