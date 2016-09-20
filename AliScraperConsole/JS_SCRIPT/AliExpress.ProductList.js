var fs = require('fs'),
    sys = require('system'),
    page = require('webpage').create();

page.resourceError = function (param) {
    console.log('error', param);
}

page.open(sys.args[1], function (status) {
    console.log('PAGE_URL', sys.args[1]);
    console.log('PAGE_OPEN_STATUS', status);

    if (status == "success") {
        page.includeJs("http://ajax.googleapis.com/ajax/libs/jquery/2.2.0/jquery.min.js", function () {
            var returnedValue = page.evaluate(function () {
                var items = $('.list-item');

                return $.map(items, function (v, i) {
                    var $v = $(v),
                        cover = $v.find('img.picCore');

                    return {
                        CoverUrl: cover.attr('image-src') || cover.attr('src'),
                        Title: $v.find('a.product').attr('title'),
                        ProductUrl: $v.find('a.product').attr('href'),
                        OriginalPrice: $v.find('.original-price').text().trim(),
                        Price: $v.find('.price span.value').text().trim(),
                        ShippingTax: $v.find('.free-s').text().toLowerCase().trim() == 'free shipping' ? 0 : stringToFloat($v.find('.pnl-shipping span.value').text()),
                        UnitType: $v.find('.pnl-shipping span.unit').text().trim(),
                        StoreName: $v.find('.store-name a').attr('title'),
                        ScoreUrl: $v.find('a.score-dot').attr('href'),
                        FeedbackScore: stringToFloat($v.find('a.score-dot').find('span').attr('feedbackscore')),
                        SellerPositiveFeedbackPercentage: stringToFloat($v.find('a.score-dot').find('span').attr('sellerpositivefeedbackpercentage'))
                    }
                });

                function stringToInt(value) {
                    return parseInt(value.replace(/[^0-9,]/g, '').replace(',', '.'));
                }

                function stringToFloat(value) {
                    return parseFloat(value.replace(/[^0-9,]/g, '').replace(',', '.'));
                }
            });

            console.log('JSON_RESULT', JSON.stringify(returnedValue));

            phantom.exit();
        });
    }
    else {
        phantom.exit();
    }
});