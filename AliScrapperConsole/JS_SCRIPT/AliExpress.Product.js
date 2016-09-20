var fs = require('fs'),
    sys = require('system'),
    page = require('webpage').create();
page.resourceError = function (param) {
    console.log('error', param);
}

page.open(sys.args[1], {
    headers: {
        "Cookie": "aep_usuc_f=site=glo&region=US&b_locale=en_US&c_tp=USD;"
    },
}, function (status) {
    console.log('PAGE_URL', sys.args[1]);
    console.log('PAGE_OPEN_STATUS', status);

    if (status == "success") {
        page.includeJs("http://ajax.googleapis.com/ajax/libs/jquery/2.2.0/jquery.min.js", function () {
            var attemps = 40;

            checkLoad();

            function checkLoad() {
                attemps--;

                var loadRating = page.evaluate(function () {
                    return !!$('.positive-percent').text() || !!$('.positive-feedback').text();
                });

                if (loadRating) {
                    complete();

                    return;
                }

                if (attemps <= 0) {
                    console.log('EMPTY_RESULT', JSON.stringify({ Attemps: attemps }));
                    phantom.exit();

                    return;
                }

                setTimeout(checkLoad, 250);
            }

            function complete() {
                var returnedValue = page.evaluate(function () {
                    return {
                        Store: {
                            StoreId: /storeId=\d*/gi.exec(runParams.relatedProductUrl)[0].replace(/[^\d]/gi, ''),
                            StoreName: $('.shop-name a').text(),
                            Since: $('.store-time em').text(),
                            Rating: $('.rank-num').text(),
                            Feedback: $('.positive-percent').text().replace('%', '')
                        },
                        Product: {
                            NoLongerAvailable: !!$('#no-longer-available h4').text(),
                            ProductId: runParams.productId,
                            Title: $('h1.product-name')[0].innerText,
                            ProcessingTime: (/\d{1,}\sbusiness/gi.exec($('#product-info-shipping-sub').text()) || [''])[0].replace(/[^\d]/gi, ''),
                            Rating: $('.product-star b').text(),
                            Weight: (/[\d.]*kg/gi.exec($('.pnl-packaging-weight').text()) || [''])[0].replace('kg', ''),
                            OrderCount: $('.orders-count b').text(),
                            DiscountTimeLeftMinutes: (function () {
                                var timeLeft = $('.time-left').text();

                                if (!timeLeft) {
                                    return null;
                                }

                                var value = timeLeft.replace(/[^:\d]/gi, '');
                                var minutesOnDay = 1440;

                                if (value.indexOf(':') > 0) {
                                    var s = value.split(':');

                                    return parseInt(s[0]) * 60 + parseInt(s[1]);
                                }

                                return parseInt(value) * minutesOnDay;
                            })(),
                            ProductSku: skuProducts,
                            Options: $.map($('#product-info-sku dt'), function (v, i) {
                                var title = $(v).text().trim();

                                return title.substring(0, title.length - 1);
                            }),
                            SkuValues: $.map($('.sku-value'), function (v, i) {
                                var $v = $(v);

                                return {
                                    SkuId: $v.attr('data-sku-id'),
                                    Title: $v.attr('title'),
                                    ImageUrl: $v.find('img').attr('src'),
                                    Name: $v.find('span').text().trim()
                                };
                            }),
                            ProductSpecs: $.map($('.product-desc div.product-params dt'), function (v, i) {
                                return {
                                    Name: $(v).text().substring(0, $(v).text().length - 1),
                                    Value: $(v).next().text()
                                }
                            }),
                            PackagingSpecs: $.map($('.product-desc .pnl-packaging dt'), function (v, i) {
                                return {
                                    Name: $(v).text().substring(0, $(v).text().length - 1),
                                    Value: $(v).next().text()
                                }
                            })
                        },
                        RunParams: runParams,
                        PageConfig: pageConfig
                    }
                });

                console.log('JSON_RESULT', JSON.stringify(returnedValue));

                phantom.exit();
            }
        });
    }
    else {
        phantom.exit();
    }
});