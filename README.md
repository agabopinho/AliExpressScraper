# AliExpressScraper

Ali Express Product Web Scraper

## Usage

```
> alishop.exe -ProductId=32704963843

OR

> alishop.exe -ProductUrl=https://pt.aliexpress.com/store/product/Original-Meizu-MEILAN-E-5-5-inch-2-5D-FHD-1080P-MTK-Helio-P10-Octa-Core/103919_32712980451.html?detailNewVersion=&categoryId=5090301&spm=a2g03.8047714.2169898.2.6F0m5X

Help

-OutputType               Output Type, default is Console [ Enum { Console | TextFile } ] [ OPTIONAL ].
-SuppressHeader           Suppress header, assembly information [ BOOL ] [ OPTIONAL ].
-H                        For help, with -MethodName for help for method [ BOOL ] [ OPTIONAL ].
```


## Example

```
> alishop.exe -ProductUrl=https://pt.aliexpress.com/item/4Pcs-set-Stainless-Steel-Omelette-Egg-Frying-Mold-Love-Flower-Round-Star-Molds/32591756332.html

 Assembly

  Title                    AliScraperConsole
  Company
  Copyright                Copyright c 2015
  Trademark
  Description              Ali Express Web Scraper
  Version                  1.0.0.0

 AliGetProduct

{
  "Product": {
    "NoLongerAvailable": false,
    "DiscountTimeLeftMinutes": null,
    "Options": [],
    "OrderCount": null,
    "PackagingSpecs": [],
    "ProcessingTime": null,
    "ProductId": 32591756332,
    "ProductSku": [
      {
        "SkuAttr": "14:193#4pcs",
        "SkuPropIds": "193",
        "SkuVal": {
          "ActSkuBulkCalPrice": null,
          "ActSkuBulkPrice": null,
          "ActSkuCalPrice": 4.99,
          "ActSkuDisplayBulkPrice": null,
          "ActSkuMultiCurrencyBulkPrice": null,
          "ActSkuMultiCurrencyCalPrice": 4.99,
          "ActSkuMultiCurrencyDisplayPrice": 4.99,
          "ActSkuMultiCurrencyPrice": null,
          "ActSkuPrice": null,
          "AvailQuantity": 442,
          "BulkOrder": null,
          "Inventory": 500,
          "IsActivity": true,
          "SkuBulkCalPrice": null,
          "SkuBulkPrice": null,
          "SkuCalPrice": 9.60,
          "SkuDisplayBulkPrice": null,
          "SkuMultiCurrencyBulkPrice": null,
          "SkuMultiCurrencyCalPrice": 9.6,
          "SkuMultiCurrencyDisplayPrice": 9.60,
          "SkuMultiCurrencyPrice": null,
          "SkuPrice": null
        }
      }
    ],
    "ProductSpecs": [],
    "Rating": null,
    "SkuValues": [],
    "Title": "FHEAL 4 Pçs/set Aço Inoxidável Omelete Fritar Ovo Molde Amor Flor Rodada Estrela Moldes",
    "Weight": null
  },
  "RunParams": {
    "abMzcVersion": "",
    "actMaxPrice": "4.99",
    "actMinPrice": "4.99",
    "adminSeq": "224202262",
    "applyScene": "",
    "atLeastCoinEnough": "true",
    "baseCurrencyCode": "USD",
    "baseCurrencySymbol": "US $",
    "baseSymbolFront": true,
    "bigSaleIconUrl": "",
    "boutique": "false",
    "buyerServer": "//my.aliexpress.com",
    "captchaImageUrl": "https://captcha.alibaba.com/get_img?identity=alibaba.com&amp;sessionid=9a3feb8004604e68a6da927658e1e18f&amp;type=b2b_default",
    "cardCoupon": "false",
    "categoryId": "100003248",
    "companyId": "233956190",
    "countryServer": "//pt.aliexpress.com",
    "crosslinkUrl": "//pt.aliexpress.com/seo/detailCrosslinkAjax.htm?productId=32591756332",
    "csrfToken": "e6icwkoi2fti",
    "currencyCode": "USD",
    "currencyRate": "1.0",
    "currencySymbol": "US $",
    "currencyTransaction": true,
    "descUrl": "//pt.aliexpress.com/getDescModuleAjax.htm?productId=32591756332&t=1520704446301&transAbTest=&adminSeq=224202262",
    "detailDesc": "https://aeproductsourcesite.alicdn.com/product/description/pc/v2/pt_BR/desc.htm?productId=32591756332&key=HTB1tnG4nx6I8KJjSszfM7OZVXXaE.zip&token=a069ab3079e0134f4f575745f26414bb",
    "discount": "48",
    "discountAmountList": [
      {
        "discountAmount": "US $1.00",
        "fixedAmount": "US $15.00"
      },
      {
        "discountAmount": "",
        "fixedAmount": ""
      }
    ],
    "discountDisplayIcon": true,
    "discountTime": {
      "d": "3",
      "h": "0",
      "s": "0"
    },
    "falseHair": "false",
    "feedbackMessageServer": "//message.aliexpress.com",
    "feedbackServer": "//feedback.aliexpress.com",
    "fixedFreeShippingTip": "",
    "forcePromiseWarrantyJson": {},
    "freightServer": "//freight.aliexpress.com",
    "giftCard": "false",
    "hasMobileDiscount": "true",
    "hasOverseaWarehouse": "false",
    "hasSizeInfo": false,
    "imageBigViewURL": [
      "https://ae01.alicdn.com/kf/HTB1pmxINpXXXXaCaXXXq6xXFXXXn/FHEAL-4-P-s-set-A-o-Inoxid-vel-Omelete-Fritar-Ovo-Molde-Amor-Flor-Rodada.jpg",
      "https://ae01.alicdn.com/kf/HTB1ekXLSXXXXXbTXXXXq6xXFXXXt/FHEAL-4-P-s-set-A-o-Inoxid-vel-Omelete-Fritar-Ovo-Molde-Amor-Flor-Rodada.jpg",
      "https://ae01.alicdn.com/kf/HTB14.XQSXXXXXXRXXXXq6xXFXXXY/FHEAL-4-P-s-set-A-o-Inoxid-vel-Omelete-Fritar-Ovo-Molde-Amor-Flor-Rodada.jpg",
      "https://ae01.alicdn.com/kf/HTB14Go1RVXXXXckaXXXq6xXFXXXM/FHEAL-4-P-s-set-A-o-Inoxid-vel-Omelete-Fritar-Ovo-Molde-Amor-Flor-Rodada.jpg",
      "https://ae01.alicdn.com/kf/HTB1BsI6d_TI8KJjSsphq6AFppXa4/FHEAL-4-P-s-set-A-o-Inoxid-vel-Omelete-Fritar-Ovo-Molde-Amor-Flor-Rodada.jpg",
      "https://ae01.alicdn.com/kf/HTB1UhpySXXXXXXXXpXXq6xXFXXX7/FHEAL-4-P-s-set-A-o-Inoxid-vel-Omelete-Fritar-Ovo-Molde-Amor-Flor-Rodada.jpg"
    ],
    "imageDetailPageURL": "//www.aliexpress.com/item-img/4Pcs-set-Stainless-Steel-Omelette-Egg-Frying-Mold-Love-Flower-Round-Star-Molds/32591756332.html",
    "imageServer": "https://ae01.alicdn.com",
    "inBlackList": "",
    "installment": "false",
    "isCoinPreSale": "false",
    "isFixedFreeShipping": false,
    "isGroupJoin": "",
    "isLocalSeller": "false",
    "isNewSizeInfo": false,
    "isOpenBanner": "",
    "isRuSelfOperation": "false",
    "isShowStockPrompt": false,
    "isStoreEventAllProduct": "true",
    "isTopItem": "false",
    "localSellerTag": "",
    "mainBigPic": "https://ae01.alicdn.com/kf/HTB1pmxINpXXXXaCaXXXq6xXFXXXn/FHEAL-4-P-s-set-A-o-Inoxid-vel-Omelete-Fritar-Ovo-Molde-Amor-Flor-Rodada.jpg",
    "maxPrice": "9.6",
    "memberPrice": "",
    "memberPriceActivity": "false",
    "minPrice": "9.6",
    "miniCoinNeed": "",
    "mobileDiscountPrice": "US $4.90",
    "offline": false,
    "offlineText": "<div class=\"no-longer-available\"><h4>Infelizmente esse produto n&atilde;o est&aacute; mais dispon&iacute;vel!</h4><div class=\"unavailable-text\">Click to view more <a href=\"//pt.aliexpress.com/category/201004732/egg-pancake-rings.html\"><b>Egg &amp; Pancake Rings</b></a> products</div></div><dl class=\"p-property-item p-you-can-wishlist\"><dt class=\"p-item-title\">You can:</dt><dd class=\"p-item-main\"><span class=\"add-wishlist-action\"><a href=\"javascrpt:;\" id=\"j-add-wishlist-btn\">Adicione a lista de desejos<span class=\"wishlist-num\" id=\"j-wishlist-num\"></span></a></span></dd></dl>",
    "openPayPal": "true",
    "pageSizeBuyerData": "",
    "pageSizeID": "",
    "pageSizeSellerData": {},
    "pageSizeTemplate": "",
    "pageSizeType": "",
    "productId": "32591756332",
    "productTradeCount": "3,735",
    "quantityLimit": {
      "availQuantityForCustomer": "442",
      "isPurchaseLimit": "",
      "quantityNum": "442 ",
      "unit": "lotes"
    },
    "recommendUrl": "//pt.aliexpress.com/product/recommend.htm?productId=32591756332",
    "regionCityName": "",
    "regionCountryName": "United States",
    "regionProvinceName": "",
    "registerFrom": "product_detail",
    "rmStoreLevelAB": "true",
    "secondLevelCategoryId": "200000920",
    "serverTime": "1520704446354",
    "serverUrl": "//pt.aliexpress.com",
    "sessionId": "dbcac0c540394ba1b858528c0eec54da",
    "shopcartServer": "//shoppingcart.aliexpress.com",
    "startValidDate": "",
    "storeSaleItemURL": "",
    "symbolFront": true,
    "title": {},
    "topCategoryId": "15",
    "totalAvailQuantity": 442,
    "transAbTest": "",
    "transactionHistoryServer": "//pt.aliexpress.com",
    "usaeServer": "//my.aliexpress.com",
    "userCountry": "BR",
    "userCountryName": "Brazil",
    "vipLevelServerUrl": "//pt.aliexpress.com/help/ajax/get_wsbuyer_level_for_ajax.htm",
    "warrantyServiceJson": []
  },
  "Store": {
    "Feedback": null,
    "Rating": null,
    "StoreId": 1992030,
    "StoreName": "FHEAL Official Store",
    "Since": "2016-01-05T00:00:00"
  }
}
```
