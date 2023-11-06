using System;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IMultichannelOrderManagerStockItem"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IMultichannelOrderManagerStockItemExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IMultichannelOrderManagerStockItem"/> object to a <see cref="MultichannelOrderManagerStockItem"/> object.
        /// </summary>
        /// <param name="momsi"><see cref="IMultichannelOrderManagerStockItem"/> object to convert.</param>
        /// <returns><see cref="MultichannelOrderManagerStockItem"/> object.</returns>
        public static MultichannelOrderManagerStockItem ToMultichannelOrderManagerStockItem(this IMultichannelOrderManagerStockItem momsi)
        {
            MultichannelOrderManagerStockItem item = null;

            if (momsi != null)
            {
                if (momsi is MultichannelOrderManagerStockItem)
                {
                    item = (MultichannelOrderManagerStockItem)(momsi);
                }
                else
                {
                    item = new MultichannelOrderManagerStockItem();

                    item.AdvancedSearch_1 = momsi.AdvancedSearch_1;
                    item.AdvancedSearch_2 = momsi.AdvancedSearch_2;
                    item.AdvancedSearch_3 = momsi.AdvancedSearch_3;
                    item.AdvancedSearch_4 = momsi.AdvancedSearch_4;
                    item.AheadBackOrder = momsi.AheadBackOrder;
                    item.AlternateWarehousesAllowed = momsi.AlternateWarehousesAllowed;
                    item.Auction = momsi.Auction;
                    item.AuctionUnits = momsi.AuctionUnits;
                    item.Bin = momsi.Bin;
                    item.BoxHeight = momsi.BoxHeight;
                    item.BoxLength = momsi.BoxLength;
                    item.BoxWidth = momsi.BoxWidth;
                    item.BreakoutItem = momsi.BreakoutItem;
                    item.CanBuyItem = momsi.CanBuyItem;
                    item.CannotOrder = momsi.CannotOrder;
                    item.CannotSell = momsi.CannotSell;
                    item.Carrier = momsi.Carrier;
                    item.CityNonTaxable = momsi.CityNonTaxable;
                    item.ClassificationCode = momsi.ClassificationCode;
                    item.ClubCode = momsi.ClubCode;
                    item.ClubProduct = momsi.ClubProduct;
                    item.Commodity = momsi.Commodity;
                    item.Condition = momsi.Condition;
                    item.ConstructItem = momsi.ConstructItem;
                    item.ContainsAlcohol = momsi.ContainsAlcohol;
                    item.ContainsLithiumBatteries = momsi.ContainsLithiumBatteries;
                    item.CostOfGoodsSoldDepartment = momsi.CostOfGoodsSoldDepartment;
                    item.CountyNonTaxable = momsi.CountyNonTaxable;
                    item.CurrentSupplier = momsi.CurrentSupplier;
                    item.CustomText = momsi.CustomText;
                    item.Delivered = momsi.Delivered;
                    item.DeliveredTotal = momsi.DeliveredTotal;
                    item.DeliveredUnits = momsi.DeliveredUnits;
                    item.DeliveryDate = momsi.DeliveryDate;
                    item.DescriptionLineOne = momsi.DescriptionLineOne;
                    item.DescriptionLineTwo = momsi.DescriptionLineTwo;
                    item.Discontinue = momsi.Discontinue;
                    item.Discontinued = momsi.Discontinued;
                    item.Distributer = momsi.Distributer;
                    item.DistributerStockNumber = momsi.DistributerStockNumber;
                    item.DownloadProductUrl = momsi.DownloadProductUrl;
                    item.DropMethod = momsi.DropMethod;
                    item.DropShippedUnitsOnBackOrder = momsi.DropShippedUnitsOnBackOrder;
                    item.DropShippedUnitsOnOrder = momsi.DropShippedUnitsOnOrder;
                    item.DryIceRequired = momsi.DryIceRequired;
                    item.DryIceWeight = momsi.DryIceWeight;
                    item.Extra = momsi.Extra;
                    item.FlatCommissionPerUnitBase = momsi.FlatCommissionPerUnitBase;
                    item.FractionalQuantities = momsi.FractionalQuantities;
                    item.FulfilledByAmazonUnits = momsi.FulfilledByAmazonUnits;
                    item.GiftCardType = momsi.GiftCardType;
                    item.GiftCertificate = momsi.GiftCertificate;
                    item.GrossCommissionBase = momsi.GrossCommissionBase;
                    item.Handling = momsi.Handling;
                    item.HasSerialNumbers = momsi.HasSerialNumbers;
                    item.Hazardous = momsi.Hazardous;
                    item.HideItem = momsi.HideItem;
                    item.ID = momsi.ID;
                    item.IgnorePrintStockIDLabel = momsi.IgnorePrintStockIDLabel;
                    item.InternalExternal = momsi.InternalExternal;
                    item.ISBN = momsi.ISBN;
                    item.IsDropshipped = momsi.IsDropshipped;
                    item.IsGiftCard = momsi.IsGiftCard;
                    item.IsService = momsi.IsService;
                    item.IsSubscription = momsi.IsSubscription;
                    item.Kit_Break = momsi.Kit_Break;
                    item.Kit_Make = momsi.Kit_Make;
                    item.LastPurchaseDate = momsi.LastPurchaseDate;
                    item.LastPurchaseQuantity = momsi.LastPurchaseQuantity;
                    item.LookupBy = momsi.LookupBy;
                    item.LookupOn = momsi.LookupOn;
                    item.Low = momsi.Low;
                    item.Manufacturer = momsi.Manufacturer;
                    item.MaximumDiscount = momsi.MaximumDiscount;
                    item.MetaTitle = momsi.MetaTitle;
                    item.MinimumMarkupAmount = momsi.MinimumMarkupAmount;
                    item.MinimumMarkupPercent = momsi.MinimumMarkupPercent;
                    item.MinimumPrice = momsi.MinimumPrice;
                    item.NationalTaxExempt = momsi.NationalTaxExempt;
                    item.NeedsCustomization = momsi.NeedsCustomization;
                    item.NetCommissionBase = momsi.NetCommissionBase;
                    item.NextSerialNumber = momsi.NextSerialNumber;
                    item.NoDiscounts = momsi.NoDiscounts;
                    item.NonTaxable = momsi.NonTaxable;
                    item.NoReturns = momsi.NoReturns;
                    item.Notation = momsi.Notation;
                    item.NoticeWhen = momsi.NoticeWhen;
                    item.Number = momsi.Number;
                    item.NumberOfBoxes = momsi.NumberOfBoxes;
                    item.Other_1 = momsi.Other_1;
                    item.Other_2 = momsi.Other_2;
                    item.Oversized = momsi.Oversized;
                    item.Oversized_Extended = momsi.Oversized_Extended;
                    item.Oversized_Extended2 = momsi.Oversized_Extended2;
                    item.PackingInvoiceText = momsi.PackingInvoiceText;
                    item.Picture = momsi.Picture;
                    item.PointsNeeded = momsi.PointsNeeded;
                    item.PointsReceived = momsi.PointsReceived;
                    item.PreManufacturingUnits = momsi.PreManufacturingUnits;
                    item.ProductAttributesEnabled = momsi.ProductAttributesEnabled;
                    item.ProductAvailability = momsi.ProductAvailability;
                    item.ProductDisassemblySetting = momsi.ProductDisassemblySetting;
                    item.ProductManufacturing = momsi.ProductManufacturing;
                    item.ProductManufacturingModuleRequired = momsi.ProductManufacturingModuleRequired;
                    item.ProductShipsInOwnBox = momsi.ProductShipsInOwnBox;
                    item.ProductUrl = momsi.ProductUrl;
                    item.PublicationCode = momsi.PublicationCode;
                    item.PurchaseOrderQuantity = momsi.PurchaseOrderQuantity;
                    item.Received = momsi.Received;
                    item.ReorderPrice = momsi.ReorderPrice;
                    item.ReorderQuantity = momsi.ReorderQuantity;
                    item.RequiresWeighing = momsi.RequiresWeighing;
                    item.RetailPrice = momsi.RetailPrice;
                    item.ReturnItemSku = momsi.ReturnItemSku;
                    item.ReturnsDepartment = momsi.ReturnsDepartment;
                    item.RoyaltiesSupplierCode = momsi.RoyaltiesSupplierCode;
                    item.Royalty = momsi.Royalty;
                    item.RoyaltyFlatBase = momsi.RoyaltyFlatBase;
                    item.RoyaltyGrossBase = momsi.RoyaltyGrossBase;
                    item.RoyaltyNetBase = momsi.RoyaltyNetBase;
                    item.SalesDepartment = momsi.SalesDepartment;
                    item.SendNotice = momsi.SendNotice;
                    item.SerialSku = momsi.SerialSku;
                    item.Server = momsi.Server.ToMultichannelOrderManagerServer();
                    item.ShippingCharge = momsi.ShippingCharge;
                    item.ShippingChargesExempt = momsi.ShippingChargesExempt;
                    item.ShippingPreference = momsi.ShippingPreference;
                    item.SingleBin = momsi.SingleBin;
                    item.SiteLINK_CPrice = momsi.SiteLINK_CPrice;
                    item.SiteLINK_CprMpt = momsi.SiteLINK_CprMpt;
                    item.SiteLINK_CprPayment = momsi.SiteLINK_CprPayment;
                    item.SiteLINK_CSMSG = momsi.SiteLINK_CSMSG;
                    item.SiteLINK_CsProduct = momsi.SiteLINK_CsProduct;
                    item.SiteLINK_Custom = momsi.SiteLINK_Custom;
                    item.SiteLINK_Department = momsi.SiteLINK_Department;
                    item.SiteLINK_Description = momsi.SiteLINK_Description;
                    item.SiteLINK_Image = momsi.SiteLINK_Image;
                    item.SiteLINK_Image1 = momsi.SiteLINK_Image1;
                    item.SiteLINK_Image2 = momsi.SiteLINK_Image2;
                    item.SiteLINK_Image3 = momsi.SiteLINK_Image3;
                    item.SiteLINK_Image4 = momsi.SiteLINK_Image4;
                    item.SiteLINK_Image5 = momsi.SiteLINK_Image5;
                    item.SiteLINK_Image6 = momsi.SiteLINK_Image6;
                    item.SiteLINK_Image7 = momsi.SiteLINK_Image7;
                    item.SiteLINK_Image8 = momsi.SiteLINK_Image8;
                    item.SiteLINK_Sell = momsi.SiteLINK_Sell;
                    item.SiteLINK_SubDepartment = momsi.SiteLINK_SubDepartment;
                    item.SiteLINK_Thumbnail = momsi.SiteLINK_Thumbnail;
                    item.SiteLINK_UsMessage = momsi.SiteLINK_UsMessage;
                    item.SiteLINK_UsProduct = momsi.SiteLINK_UsProduct;
                    item.Size_Color = momsi.Size_Color;
                    item.Sold = momsi.Sold;
                    item.StockID = momsi.StockID;
                    item.SubscriptionInvoiceExempt = momsi.SubscriptionInvoiceExempt;
                    item.SubscriptionIssueCount = momsi.SubscriptionIssueCount;
                    item.Substitute = momsi.Substitute;
                    item.TaxClass = momsi.TaxClass;
                    item.TaxClass_C = momsi.TaxClass_C;
                    item.TaxClass_I = momsi.TaxClass_I;
                    item.TaxClass_N = momsi.TaxClass_N;
                    item.TaxClass_S = momsi.TaxClass_S;
                    item.ThresholdType = momsi.ThresholdType;
                    item.UnitCost = momsi.UnitCost;
                    item.UnitOfMeasure = momsi.UnitOfMeasure;
                    item.Units = momsi.Units;
                    item.UnitsBackordered = momsi.UnitsBackordered;
                    item.UnitsCommitted = momsi.UnitsCommitted;
                    item.UnitsInBox = momsi.UnitsInBox;
                    item.UnitsOnOrder = momsi.UnitsOnOrder;
                    item.UnitsReturnedNotInvoiced = momsi.UnitsReturnedNotInvoiced;
                    item.UnitWeight = momsi.UnitWeight;
                    item.UPC = momsi.UPC;
                    item.WarehousePreference = momsi.WarehousePreference;
                }
            }

            return item;
        }
    }
}

