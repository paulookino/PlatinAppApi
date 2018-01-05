using Newtonsoft.Json;
using PlatinAppApi.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PlatinAppApi.Service
{
    public class DataService
    {
        HttpClient client = new HttpClient();

        public async Task<List<Product>> GetProdutosAsync()
        {
            try
            {
                string url = "http://platinwebapi.somee.com/api/product/RetornaTodosProdutos";
                var response = await client.GetStringAsync(url);
                var produtos = JsonConvert.DeserializeObject<List<Product>>(response);
                return produtos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddProdutoAsync(Product produto)
        {
            try
            {
                PopulaProduto(produto);

                string url = "http://platinwebapi.somee.com/api/product/inserir/{0}";

                var uri = new Uri(string.Format(url, produto.id));

                var data = JsonConvert.SerializeObject(produto);
                var content = new StringContent(data, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                response = await client.PostAsync(uri, content);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Erro ao incluir produto");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateProdutoAsync(Product produto)
        {
            string url = "http://platinwebapi.somee.com/api/product/editar/{0}";
            var uri = new Uri(string.Format(url, produto.id));

            var data = JsonConvert.SerializeObject(produto);
            var content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            response = await client.PutAsync(uri, content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Erro ao atualizar produto");
            }

        }

        public async Task DeletaProdutoPorIndiceAsync(int indice)
        {
            string url = "http://platinwebapi.somee.com/api/product/excluir/{0}";
            await client.DeleteAsync(string.Concat(url, indice));
        }

        public async Task DeletaProdutoAsync(Product produto)
        {
            string url = "http://platinwebapi.somee.com/api/product/excluir/{0}";
            var uri = new Uri(string.Format(url, produto.id));
            await client.DeleteAsync(uri);
        }

        public Product PopulaProduto(Product product)
        {

            product.productTypeId = 13;
            product.parentGroupedProductId = 13;
            product.visibleIndividually = true;
            product.shortDescription = "Teste";
            product.fullDescription = "Teste";
            product.productTemplateId = 13;
            product.vendorId = 13;
            product.showOnHomePage = true;
            product.allowCustomerReviews = true;
            product.approvedRatingSum = 13;
            product.notApprovedRatingSum = 13;
            product.approvedTotalReviews = 13;
            product.notApprovedTotalReviews = 13;
            product.subjectToAcl = false;
            product.limitedToStores = true;
            product.sku = "Teste";
            product.isGiftCard = true;
            product.giftCardTypeId = 13;
            product.requireOtherProducts = true;
            product.automaticallyAddRequiredProducts = true;
            product.isDownload = true;
            product.downloadId = 13;
            product.unlimitedDownloads = true;
            product.maxNumberOfDownloads = 13;
            product.downloadActivationTypeId = 13;
            product.hasSampleDownload = true;
            product.sampleDownloadId = 13;
            product.hasUserAgreement = true;
            product.isRecurring = true;
            product.recurringCycleLength = 13;
            product.recurringCyclePeriodId = 13;
            product.recurringTotalCycles = 13;
            product.isRental = true;
            product.rentalPriceLength = 13;
            product.rentalPricePeriodId = 13;
            product.isShipEnabled = true;
            product.isFreeShipping = true;
            product.shipSeparately = true;
            product.additionalShippingCharge = 13.0;
            product.deliveryDateId = 13;
            product.isTaxExempt = true;
            product.taxCategoryId = 13;
            product.isTelecommunicationsOrBroadcastingOrElectronicServices = true;
            product.manageInventoryMethodId = 13;
            product.productAvailabilityRangeId = 13;
            product.useMultipleWarehouses = true;
            product.warehouseId = 13;
            product.stockQuantity = 13;
            product.displayStockAvailability = true;
            product.displayStockQuantity = true;
            product.minStockQuantity = 13;
            product.lowStockActivityId = 13;
            product.notifyAdminForQuantityBelow = 13;
            product.backorderModeId = 13;
            product.allowBackInStockSubscriptions = true;
            product.orderMinimumQuantity = 13;
            product.orderMaximumQuantity = 13;
            product.allowAddingOnlyExistingAttributeCombinations = true;
            product.notReturnable = true;
            product.disableBuyButton = true;
            product.disableWishlistButton = true;
            product.availableForPreOrder = true;
            product.callForPrice = true;
            product.price = 13.0;
            product.oldPrice = 13.0;
            product.productCost = 13.0;
            product.customerEntersPrice = true;
            product.minimumCustomerEnteredPrice = 13.0;
            product.maximumCustomerEnteredPrice = 13.0;
            product.basepriceEnabled = true;
            product.basepriceAmount = 13.0;
            product.basepriceUnitId = 13;
            product.basepriceBaseAmount = 13.0;
            product.basepriceBaseUnitId = 13;
            product.markAsNew = true;
            product.hasTierPrices = true;
            product.hasDiscountsApplied = true;
            product.weight = 13.0;
            product.length = 13.0;
            product.width = 13.0;
            product.height = 13.0;
            product.displayOrder = 13;
            product.published = true;
            product.deleted = true;
            product.createdOnUtc = DateTime.Now;
            product.updatedOnUtc = DateTime.Now;

            return product;
        }

        public async Task AddInventarioAsync(Inventario inventario)
        {
            try
            {

                string url = "http://platinwebapi.somee.com/api/inventario/inserir/{0}";

                var uri = new Uri(string.Format(url, inventario.InvId));

                var data = JsonConvert.SerializeObject(inventario);
                var content = new StringContent(data, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                response = await client.PostAsync(uri, content);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Erro ao incluir inventário");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Inventario>> GetInventarioContagemAsync()
        {
            try
            {
                string url = "http://platinwebapi.somee.com/api/inventario/RetornaTodosCodigosComContagem";
                var response = await client.GetStringAsync(url);
                var inventario = JsonConvert.DeserializeObject<List<Inventario>>(response);
                return inventario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Inventario>> GetInventarioAsync()
        {
            try
            {
                //string url = "http://platinwebapi.somee.com/api/inventario/RetornaTodosCodigos";
                string url = "http://platinwebapi.somee.com/api/inventario/RetornaInventarioProduto";
                var response = await client.GetStringAsync(url);
                var inventario = JsonConvert.DeserializeObject<List<Inventario>>(response);
                return inventario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeletaInventarioAsync(Inventario inventario)
        {
            string url = "http://platinwebapi.somee.com/api/inventario/excluir/{0}";
            var uri = new Uri(string.Format(url, inventario.InvId));
            await client.DeleteAsync(uri);
        }
    }
}
