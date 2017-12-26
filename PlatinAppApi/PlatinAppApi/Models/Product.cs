using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace PlatinAppApi.Models
{
    [DataContract]
    public class Products
    {
        [DataMember]
        public List<Product> products { get; set; }
    }

    [DataContract]
    public class Product
    {
        [DataMember(Name = "id")]
        public int id { get; set; }
        [DataMember]
        public int productTypeId { get; set; }
        [DataMember]
        public int parentGroupedProductId { get; set; }
        [DataMember]
        public bool visibleIndividually { get; set; }
        [DataMember(Name = "name")]
        public string name { get; set; }
        [DataMember]
        public string shortDescription { get; set; }
        [DataMember]
        public string fullDescription { get; set; }
        [DataMember]
        public int productTemplateId { get; set; }
        [DataMember]
        public int vendorId { get; set; }
        [DataMember]
        public bool showOnHomePage { get; set; }
        [DataMember]
        public bool allowCustomerReviews { get; set; }
        [DataMember]
        public int approvedRatingSum { get; set; }
        [DataMember]
        public int notApprovedRatingSum { get; set; }
        [DataMember]
        public int approvedTotalReviews { get; set; }
        [DataMember]
        public int notApprovedTotalReviews { get; set; }
        [DataMember]
        public bool subjectToAcl { get; set; }
        [DataMember]
        public bool limitedToStores { get; set; }
        [DataMember]
        public string sku { get; set; }
        [DataMember]
        public bool isGiftCard { get; set; }
        [DataMember]
        public int giftCardTypeId { get; set; }
        [DataMember]
        public bool requireOtherProducts { get; set; }
        [DataMember]
        public bool automaticallyAddRequiredProducts { get; set; }
        [DataMember]
        public bool isDownload { get; set; }
        [DataMember]
        public int downloadId { get; set; }
        [DataMember]
        public bool unlimitedDownloads { get; set; }
        [DataMember]
        public int maxNumberOfDownloads { get; set; }
        [DataMember]
        public int downloadActivationTypeId { get; set; }
        [DataMember]
        public bool hasSampleDownload { get; set; }
        [DataMember]
        public int sampleDownloadId { get; set; }
        [DataMember]
        public bool hasUserAgreement { get; set; }
        [DataMember]
        public bool isRecurring { get; set; }
        [DataMember]
        public int recurringCycleLength { get; set; }
        [DataMember]
        public int recurringCyclePeriodId { get; set; }
        [DataMember]
        public int recurringTotalCycles { get; set; }
        [DataMember]
        public bool isRental { get; set; }
        [DataMember]
        public int rentalPriceLength { get; set; }
        [DataMember]
        public int rentalPricePeriodId { get; set; }
        [DataMember]
        public bool isShipEnabled { get; set; }
        [DataMember]
        public bool isFreeShipping { get; set; }
        [DataMember]
        public bool shipSeparately { get; set; }
        [DataMember]
        public double additionalShippingCharge { get; set; }
        [DataMember]
        public int deliveryDateId { get; set; }
        [DataMember]
        public bool isTaxExempt { get; set; }
        [DataMember]
        public int taxCategoryId { get; set; }
        [DataMember]
        public bool isTelecommunicationsOrBroadcastingOrElectronicServices { get; set; }
        [DataMember]
        public int manageInventoryMethodId { get; set; }
        [DataMember]
        public int productAvailabilityRangeId { get; set; }
        [DataMember]
        public bool useMultipleWarehouses { get; set; }
        [DataMember]
        public int warehouseId { get; set; }
        [DataMember]
        public int stockQuantity { get; set; }
        [DataMember]
        public bool displayStockAvailability { get; set; }
        [DataMember]
        public bool displayStockQuantity { get; set; }
        [DataMember]
        public int minStockQuantity { get; set; }
        [DataMember]
        public int lowStockActivityId { get; set; }
        [DataMember]
        public int notifyAdminForQuantityBelow { get; set; }
        [DataMember]
        public int backorderModeId { get; set; }
        [DataMember]
        public bool allowBackInStockSubscriptions { get; set; }
        [DataMember]
        public int orderMinimumQuantity { get; set; }
        [DataMember]
        public int orderMaximumQuantity { get; set; }
        [DataMember]
        public bool allowAddingOnlyExistingAttributeCombinations { get; set; }
        [DataMember]
        public bool notReturnable { get; set; }
        [DataMember]
        public bool disableBuyButton { get; set; }
        [DataMember]
        public bool disableWishlistButton { get; set; }
        [DataMember]
        public bool availableForPreOrder { get; set; }
        [DataMember]
        public bool callForPrice { get; set; }
        [DataMember]
        public double price { get; set; }
        [DataMember]
        public double oldPrice { get; set; }
        [DataMember]
        public double productCost { get; set; }
        [DataMember]
        public bool customerEntersPrice { get; set; }
        [DataMember]
        public double minimumCustomerEnteredPrice { get; set; }
        [DataMember]
        public double maximumCustomerEnteredPrice { get; set; }
        [DataMember]
        public bool basepriceEnabled { get; set; }
        [DataMember]
        public double basepriceAmount { get; set; }
        [DataMember]
        public int basepriceUnitId { get; set; }
        [DataMember]
        public double basepriceBaseAmount { get; set; }
        [DataMember]
        public int basepriceBaseUnitId { get; set; }
        [DataMember]
        public bool markAsNew { get; set; }
        [DataMember]
        public bool hasTierPrices { get; set; }
        [DataMember]
        public bool hasDiscountsApplied { get; set; }
        [DataMember]
        public double weight { get; set; }
        [DataMember]
        public double length { get; set; }
        [DataMember]
        public double width { get; set; }
        [DataMember]
        public double height { get; set; }
        [DataMember]
        public int displayOrder { get; set; }
        [DataMember]
        public bool published { get; set; }
        [DataMember]
        public bool deleted { get; set; }
        [DataMember]
        public DateTime createdOnUtc { get; set; }
        [DataMember]
        public DateTime updatedOnUtc { get; set; }

    }


    


    


}
