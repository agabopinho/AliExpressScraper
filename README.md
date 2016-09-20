# AliExpressScrapper

Ali Express Product Web Scrapper

##Usage example

```
> alishop.exe -ProductId=32704963843 -StoreId=1195010 

OR

> alishop.exe -ProductUrl=https://pt.aliexpress.com/store/product/Original-Meizu-MEILAN-E-5-5-inch-2-5D-FHD-1080P-MTK-Helio-P10-Octa-Core/103919_32712980451.html?detailNewVersion=&categoryId=5090301&spm=a2g03.8047714.2169898.2.6F0m5X

Help

-OutputType               Output Type, default is Console [ Enum { Console | TextFile } ] [ OPTIONAL ].
-SuppressHeader           Suppress header, assembly information [ BOOL ] [ OPTIONAL ].
-H                        For help, with -MethodName for help for method [ BOOL ] [ OPTIONAL ].
```
##Output
```
{
  "PageConfig": {
    "aeUSserver": "//us.ae.aliexpress.com",
    "companyId": "230577000",
    "fbmsgParams": {
      "from": "13",
      "id1": "d43l0Ii0Q0aT4PAAJI6tWg%3D%3D",
      "id2": "1195010"
    },
    "feedbackServer": "//feedback.aliexpress.com",
    "feedbackTabUrl": "//www.aliexpress.com/store/feedback-score/1195010.html",
    "isProductGroupsync": "false",
    "ownerMemberId": "220562683",
    "productsAjax": "//www.aliexpress.com/store/productGroupsAjax.htm?storeId=1195010",
    "sessionId": "5c1e36686b824a3794967b071ffb8724",
    "shopcartServer": "//shoppingcart.aliexpress.com",
    "storeId": "1195010",
    "storeUrl": "//www.aliexpress.com/store/1195010",
    "wholesaleServer": "//www.aliexpress.com",
    "wishlistServer": "//my.aliexpress.com"
  },
  "Product": {
    "NoLongerAvailable": false,
    "DiscountTimeLeftMinutes": null,
    "Options": [],
    "OrderCount": null,
    "PackagingSpecs": [],
    "ProcessingTime": null,
    "ProductId": 32704963843,
    "ProductSku": [
      {
        "SkuAttr": "14:193",
        "SkuPropIds": "193",
        "SkuVal": {
          "ActSkuBulkCalPrice": null,
          "ActSkuBulkPrice": null,
          "ActSkuCalPrice": null,
          "ActSkuDisplayBulkPrice": null,
          "ActSkuMultiCurrencyBulkPrice": null,
          "ActSkuMultiCurrencyCalPrice": null,
          "ActSkuMultiCurrencyDisplayPrice": null,
          "ActSkuMultiCurrencyPrice": null,
          "ActSkuPrice": null,
          "AvailQuantity": 20,
          "BulkOrder": null,
          "Inventory": 20,
          "IsActivity": false,
          "SkuBulkCalPrice": null,
          "SkuBulkPrice": null,
          "SkuCalPrice": 41.88,
          "SkuDisplayBulkPrice": null,
          "SkuMultiCurrencyBulkPrice": null,
          "SkuMultiCurrencyCalPrice": 41.88,
          "SkuMultiCurrencyDisplayPrice": 41.88,
          "SkuMultiCurrencyPrice": "US $41.88",
          "SkuPrice": 41.88
        }
      }
    ],
    "ProductSpecs": [],
    "Rating": null,
    "SkuValues": [],
    "Title": "UIYI Brand Man Bag Black Hasp Mens Soft Back Backpacks Retro Fashion Men Laptop Backpack 2016 New Boy's Schoolbag",
    "Weight": null
  },
  "RunParams": {
    "abMzcVersion": "",
    "adminSeq": "220562683",
    "baseCurrencyCode": "USD",
    "baseCurrencySymbol": "US $",
    "baseSymbolFront": true,
    "boutique": "",
    "buyerServer": "//my.aliexpress.com",
    "captchaImageUrl": "https://captcha.alibaba.com/get_img?identity=alibaba.com&amp;sessionid=5c1e36686b824a3794967b071ffb8724&amp;type=b2b_default",
    "categoryId": "152401",
    "categoryName": "Home",
    "categoryUrl": "//www.aliexpress.com",
    "companyId": "230577000",
    "countryServer": "//www.aliexpress.com",
    "crosslinkUrl": "//www.aliexpress.com/seo/detailCrosslinkAjax.htm?productId=32704963843",
    "csrfToken": "fbk4wbcq0d8h",
    "currencyCode": "USD",
    "currencyRate": "1.0",
    "currencySymbol": "US $",
    "currencyTransaction": true,
    "descUrl": "//www.aliexpress.com/getDescModuleAjax.htm?productId=32704963843&t=1474333636520",
    "feedbackMessageServer": "//message.aliexpress.com",
    "feedbackServer": "//feedback.aliexpress.com",
    "freightServer": "//freight.aliexpress.com",
    "hasMobileDiscount": "",
    "imageBigViewURL": [
      "https://ae01.alicdn.com/kf/HTB1FqoaNXXXXXcrXpXXq6xXFXXXY/UIYI-Brand-Man-Bag-Black-Hasp-Mens-Soft-Back-Backpacks-Retro-Fashion-Men-Laptop-Backpack-2016.jpg",
      "https://ae01.alicdn.com/kf/HTB1pWXhLXXXXXb9XVXXq6xXFXXXw/UIYI-Brand-Man-Bag-Black-Hasp-Mens-Soft-Back-Backpacks-Retro-Fashion-Men-Laptop-Backpack-2016.jpg",
      "https://ae01.alicdn.com/kf/HTB1QubONXXXXXbWaXXXq6xXFXXX1/UIYI-Brand-Man-Bag-Black-Hasp-Mens-Soft-Back-Backpacks-Retro-Fashion-Men-Laptop-Backpack-2016.jpg",
      "https://ae01.alicdn.com/kf/HTB1_Gk9KVXXXXbPapXXq6xXFXXXl/UIYI-Brand-Man-Bag-Black-Hasp-Mens-Soft-Back-Backpacks-Retro-Fashion-Men-Laptop-Backpack-2016.jpg",
      "https://ae01.alicdn.com/kf/HTB1Yn8rLXXXXXa1XFXXq6xXFXXXV/UIYI-Brand-Man-Bag-Black-Hasp-Mens-Soft-Back-Backpacks-Retro-Fashion-Men-Laptop-Backpack-2016.jpg",
      "https://ae01.alicdn.com/kf/HTB1hOHZNXXXXXbtXVXXq6xXFXXXV/UIYI-Brand-Man-Bag-Black-Hasp-Mens-Soft-Back-Backpacks-Retro-Fashion-Men-Laptop-Backpack-2016.jpg"
    ],
    "imageDetailPageURL": "//www.aliexpress.com/item-img/UIYI-Brand-Man-Bag-Black-Hasp-Mens-Soft-Back-Sports-Backpacks-Retro-Fashion-Men-Laptop-Backpack/32704963843.html",
    "imageServer": "https://ae01.alicdn.com",
    "inBlackList": false,
    "interested": "1",
    "isGroupJoin": "false",
    "isLocalSeller": "false",
    "mainBigPic": "https://ae01.alicdn.com/kf/HTB1FqoaNXXXXXcrXpXXq6xXFXXXY/UIYI-Brand-Man-Bag-Black-Hasp-Mens-Soft-Back-Backpacks-Retro-Fashion-Men-Laptop-Backpack-2016.jpg",
    "maxPrice": "41.88",
    "minPrice": "41.88",
    "mobileDiscountPrice": "",
    "offline": false,
    "offlineText": "<div class=\"no-longer-available\"><h4>Sorry, this item is no longer available!</h4><div class=\"unavailable-text\">Click to view more <a href=\"//www.aliexpress.com\"><b>Home</b></a> products</div></div><dl class=\"p-property-item p-you-can-wishlist\"><dt class=\"p-item-title\">You can:</dt><dd class=\"p-item-main\"><span class=\"add-wishlist-action\"><a href=\"javascrpt:;\" id=\"j-add-wishlist-btn\">Add to Wish List<span class=\"wishlist-num\" id=\"j-wishlist-num\"></span></a></span></dd></dl>",
    "pageSizeID": "",
    "pageSizeTemplate": "",
    "pageSizeType": "",
    "productId": "32704963843",
    "productTradeCount": "1",
    "quantityLimit": {
      "availQuantityForCustomer": "20",
      "isPurchaseLimit": "",
      "quantityNum": "20 ",
      "unit": "pieces"
    },
    "recommendUrl": "//www.aliexpress.com/product/recommend.htm?productId=32704963843",
    "regionCountryName": "United States",
    "registerFrom": "product_detail",
    "relatedProductUrl": "//www.aliexpress.com/getRelatedProductAjax.htm?productId=32704963843&storeId=1195010",
    "serverTime": "1474333636536",
    "serverUrl": "//www.aliexpress.com",
    "sessionId": "5c1e36686b824a3794967b071ffb8724",
    "shopcartServer": "//shoppingcart.aliexpress.com",
    "startValidDate": "",
    "symbolFront": true,
    "totalAvailQuantity": 20,
    "transactionHistoryServer": "//www.aliexpress.com",
    "usaeServer": "//us.ae.aliexpress.com",
    "userCountry": "BR",
    "userCountryName": "Brazil",
    "userType": "",
    "vipLevelServerUrl": "//www.aliexpress.com/help/ajax/get_wsbuyer_level_for_ajax.htm"
  },
  "Store": {
    "Feedback": 98.1,
    "Rating": 1846,
    "StoreId": 1195010,
    "StoreName": "uiyi . Store",
    "Since": "2014-03-28T00:00:00"
  }
}
```
