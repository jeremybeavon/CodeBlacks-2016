
var myGeoJSONPath = './world_geo.json';
var geoJsonData;
var populationJSONPath = "./population.json"
var populationDensityJSONPath = "./pop_density.json"
var geojson;
var map;
var info;
var populationData = {};
var densityData = {};
var sidebar;
var amountInputHtml = '<div class="input-group input-group-lg amt">\
  <span class="input-group-addon"><span class="glyphicon glyphicon-usd" aria-hidden="true"></span></span>\
  <input type="number" class="form-control" aria-label="Amount (to the nearest dollar)" id="amountInput" step="0.1" min="1" placeholder="Enter Amount" >\
</div> <hr>';
var currentlySelectedCountry = '';
var currentlySelectedCountryIsoCode;
var selectedLayer = null;
var markers = [];

// initialize the map
$.getJSON(myGeoJSONPath, function (data) {

    L.Map = L.Map.extend({
        openPopup: function (popup) {
            //this.closePopup();  // just comment this
            this._popup = popup;

            return this.addLayer(popup).fire('popupopen', {
                popup: this._popup
            });
        }
    });

    map = L.map('map').setView([30.562879, 36.169704], 4);
    L.tileLayer('https://api.mapbox.com/styles/v1/jeremybeavon/cipc5e0p2005sahnfj342z1p1/tiles/256/{z}/{x}/{y}?access_token=pk.eyJ1IjoiamVyZW15YmVhdm9uIiwiYSI6ImNpcGMzeXU3aDAwNzB0MG03aXowMDRwY3AifQ.ZhppuLh9MZrax8YIjys7og', {
        minZoom: 3
    }).addTo(map);
    geojson = L.geoJson(data, {
        onEachFeature: onEachFeature,
        style: style,
    }).addTo(map);

    geoJsonData = data.features;

    $.getJSON(populationJSONPath, function (data) {

        for (var i = 0; i < data.length; i++) {
            populationData[data[i].country] = data[i].population;
        }
    });

    $.getJSON(populationDensityJSONPath, function (data) {
        for (var i = 0; i < data.length; i++) {
            densityData[data[i].code] = data[i].value;
        }
    });

    info = L.control();

    info.onAdd = function (map) {
        this._div = L.DomUtil.create('div', 'info');
        this.update();
        return this._div;
    };

    info.update = function (props) {

        var countryPopulation = 0;
        var countryPopDensity = 0;

        if (props) {
            if (populationData[props.name]) {
                countryPopulation = populationData[props.name].toLocaleString();
            }
            else if (populationData[props.long_name]) {
                countryPopulation = populationData[props.long_name].toLocaleString();
            }
            if (densityData[props.iso_a2])
                countryPopDensity = densityData[props.iso_a2];
        }

        this._div.innerHTML = '<h4>Country Information</h4>' + (props ?
				'<b>' + props.name + '</b><br />Population: ' + countryPopulation + '<br />Density: ' + countryPopDensity + ' per sq. km' : 'Hover over a Country<br />');
    };
    info.addTo(map);

    sidebar = L.control.sidebar('sidebar', {
        position: 'left'
    });
    sidebar.on('hide', hide_handler);
    map.addControl(sidebar);
});

function highlightFeature(e) {

    if (currentlySelectedCountry == '') {
        var layer = e.target;
        selectedLayer = layer;

        layer.setStyle({
            weight: 5,
            color: '#FFF',
            dashArray: '',
            fillOpacity: 0.5
        });

        if (!L.Browser.ie && !L.Browser.opera) {
            layer.bringToFront();
        }
        info.update(layer.feature.properties);
    }
}

function style(feature) {
    return {
        fillOpacity: 0,
        opacity: 0
    };
}


function resetHighlight(e) {

    if (currentlySelectedCountry == '') {
        geojson.resetStyle(e.target);
        info.update();
        selectedLayer = null;
    }
}

function zoomToFeature(e) {

    var selectedCountry = e.target.feature.properties.name;

    if (selectedCountry != currentlySelectedCountry) {
        RemoveMarkers();

        currentlySelectedCountry = '';

        if (selectedLayer != null)
            geojson.resetStyle(selectedLayer);

        highlightFeature(e);

        currentlySelectedCountry = selectedCountry;
        currentlySelectedCountryIsoCode = e.target.feature.properties.iso_a2;

        GetCharitesForCountry(currentlySelectedCountry);

        map.fitBounds(e.target.getBounds());
    }
}

function onEachFeature(feature, layer) {
    layer.on({
        mouseover: highlightFeature,
        mouseout: resetHighlight,
        click: zoomToFeature,
    });
}

function GetCharitesForCountry(country) {

    var serviceURL = '/api/charity/' + encodeURIComponent(country);

    $.ajax({
        type: "GET",
        url: serviceURL,
        data: param = "",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: successFunc,
        error: errorFunc
    });

    function successFunc(data, status) {
        SetSideBarContent(data);
    }

    function errorFunc() {
        SetSideBarContent(null);
    }
}

function SetSideBarContent(charityData) {

    var content = amountInputHtml;
    content += BuildCharityList(charityData);
    sidebar.setContent(content);
    sidebar.show();

    $('.list-group .list-group-item').click(function () {
        $('.list-group .list-group-item.active').removeClass("active");
        $(this).addClass("active");
        var amount = document.getElementById('amountInput').value;
        if (amount != '' && amount < 10000000)
            GetCharityDonationAmountInformation(currentlySelectedCountry, amount);
    });

    document.getElementById('amountInput').onkeypress = function (e) {
        if (!e) e = window.event;
        var keyCode = e.keyCode || e.which;
        if (keyCode == '13') {
            var amount = document.getElementById('amountInput').value;
            if (amount != '' && amount < 10000000)
                GetCharityDonationAmountInformation(currentlySelectedCountry, amount);
        }
    }
}

hide_handler = function (e) {
    currentlySelectedCountry = '';
    currentlySelectedCountryIsoCode = '';
    geojson.resetStyle(selectedLayer);

    RemoveMarkers();
}
function GetCharityDonationAmountInformation(country, amount) {

    var charity = $('.list-group .list-group-item.active').attr('data-charity');
    
    var serviceURL = '/api/charity/' + encodeURIComponent(country) + '?charity=' + encodeURIComponent(charity) + '&amount=' + amount;

    $.ajax({
        type: "GET",
        url: serviceURL,
        data: param = "",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: successFunc
    });

    RemoveMarkers();

    function successFunc(data, status) {
        AddCharityDonationInfoToMap(data);
    }
}

function AddCharityDonationInfoToMap(donationInfo) {

    for (var i = 0; i < donationInfo.length; i++) {
        var lat = donationInfo[i].latitude;
        var long = donationInfo[i].longitude;
        //var people = donationInfo[i].peopleEffected;
        var location = donationInfo[i].locationName;

        var totalPeople = 0;
        var popupContent = '<br>';

        for (var j = 0; j < donationInfo[i].subItems.length; j++)
        {
            totalPeople += donationInfo[i].subItems[j].peopleEffected;
            popupContent += '<br>' + donationInfo[i].subItems[j].amountOfItems + ' x ' + donationInfo[i].subItems[j].type +
                " Cost: " + donationInfo[i].subItems[j].donation.toLocaleString();
        }

        popupContent = '<b>' + location + '</b><br>' + 'Impact: ' + totalPeople + ' people' + popupContent;

        var countryPopDensity = 0;
        var radius = 1;

        //Calculate radius of circle on map
        if (densityData[currentlySelectedCountryIsoCode])
            countryPopDensity = densityData[currentlySelectedCountryIsoCode];

        if (countryPopDensity != 0) {
            var area = totalPeople * 1.0 / countryPopDensity;
            var radius = Math.sqrt(area / Math.PI) * 1000;
        }


        var marker = L.circle([lat, long], radius, 
            {
                color: 'blue',
                fillColor: 'blue',
                fillOpacity: 0.5
            }).addTo(map);
        marker.bindPopup(popupContent).openPopup();
        markers.push(marker);
    }
}

function RemoveMarkers() {

    markers.forEach(function (marker) {
        map.removeLayer(marker);
    })
    markers = [];
}

function BuildCharityList(charityData) {
    var listDiv = '<div class="list-group">';
    if (charityData.length != 0) {
        for (var i = 0 ; i < charityData.length; i++) {
            var name = charityData[i].charityName;
            var web = charityData[i].charityWebsite;
            var icon = charityData[i].iconUrl;
            var desc = charityData[i].description;

            listDiv += '<button type="button" data-charity="' + name + '" class="list-group-item" id= "listId"><div><div class="sideLeft" ><img src=' + icon + ' alt="' + i +
                'icon" height="50" width="auto" class="img-rounded"></div><div class="sideLeft"><a href=' +
                web + ' target="_blank">' + name + ' </a><p>' + desc + '</p></div></div></button>';
        }
        listDiv += '</div>';
    }
    else {
        listDiv += '<button type="button" class="list-group-item"><p>NO DATA</p></button></div>';
    }
    return listDiv;
}

