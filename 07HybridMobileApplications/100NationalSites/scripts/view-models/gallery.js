/**
 * Signup view model
 */
var app = app || {};

app.Gallery = (function () {
    'use strict';

    var galleryViewModel = (function () {
        'use strict';

        var imagesOptions = [{ id: 1, name: 'All' }, { id: 2, name: 'My sites' }];

        var imagesDataList = [];

        var imagesData = (function () {
            var images = app.everlive.Files;

            images.get()
                .then(function (data) {
                    for (var i = 0; i < data.result.length; i++) {
                        imagesDataList.push(data.result[i]);
                    }
                },
                function (error) {
                    console.log(JSON.stringify(error));
                });
        }());
        
        var init = function () {

        };

        var selectionImagesList = function (event) {
            var selectedValue = parseInt(event.target.value),
                template = kendo.template($("#imagesTemplate").html()),
                filteredData = [];

            switch(selectedValue) {
                case 1:
                    filteredData = imagesDataList.filter(function (element) {
                        return element;
                    });
                    break;
                case 2:
                    filteredData = imagesDataList.filter(function (element) {
                        return element.Owner === app.currentUser.data.Id;
                    });
                    break;
                default:
                    filteredData = imagesDataList.filter(function (element) {
                        return element;
                    });
                    break;

            }

            $("#imagesList").html(kendo.render(template, filteredData));
        }

        return {
            init: init,
            selectionImagesList: selectionImagesList,
            imagesOptions: imagesOptions,
            imagesDataList: imagesDataList
        };

    }());

    return galleryViewModel;

}());