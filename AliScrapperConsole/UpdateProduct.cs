using ISAA.Suppliers.Ali.Automation.Common;

namespace ISAA.Suppliers.Ali.Automation
{
    internal static class UpdateProduct
    {
        internal static void Run(long processID, long productRefID, string productUrl, string outputDirectory)
        {
            var dirName = outputDirectory ?? JobConfiguration.GetNewProcessDirectory();
            var parameter = new UpdateProductParameter
            {
                FileOutputDirName = dirName,
                ProcessID = processID,
                ProductRefID = productRefID,
                ProductUrl = productUrl
            };

            ShopProduct.UpdateProduct(parameter);
        }
    }
}
