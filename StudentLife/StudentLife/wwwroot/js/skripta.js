var roundLatLng = Formatters.roundLatLng;
var marker1Centar = [18.303172, 43.833783];
var marker2Centar = [18.397759, 43.855403];
var centar = [(marker1Centar[0] + marker2Centar[0]) / 2, (marker1Centar[1] + marker2Centar[1]) / 2];
var popup = new tt.Popup({
    offset: 35
});

var map = tt.map({
    key: 'Tx9B4cZ2IumFk28ymZwzp2B17tcHt6nZ',
    container: 'map',
    style: 'tomtom://vector/1/basic-main',
    dragPan: !window.isMobileOrTablet(),
    center: centar,
    zoom: 12
});

map.addControl(new tt.FullscreenControl());
map.addControl(new tt.NavigationControl());

marker1 = createMarker('https://img.icons8.com/ios-filled/50/000000/a.png', marker1Centar, '#0000CD', 'Početak', false);
marker2 = createMarker('https://img.icons8.com/ios-filled/50/000000/b.png', marker2Centar, '#0000CD', 'Kraj', false);
markerK = createMarker('https://img.icons8.com/ios-filled/50/000000/contacts.png', centar, '#0000CD', 'Vaša lokacija', true);

function onDragEnd1() {
    var lngLat = marker1.getLngLat();
    lngLat = new tt.LngLat(roundLatLng(lngLat.lng), roundLatLng(lngLat.lat));
    popup.setHTML(lngLat.toString());
    popup.setLngLat(lngLat);
    marker1.setPopup(popup);
    marker1.togglePopup();
}

function onDragEnd2() {
    var lngLat = marker2.getLngLat();
    lngLat = new tt.LngLat(roundLatLng(lngLat.lng), roundLatLng(lngLat.lat));
    popup.setHTML(lngLat.toString());
    popup.setLngLat(lngLat);
    marker2.setPopup(popup);
    marker2.togglePopup();
}

marker1.on('dragend', onDragEnd1);
marker2.on('dragend', onDragEnd2);

function findFirstBuildingLayerId() {
    var layers = map.getStyle().layers;
    for (var index in layers) {
        if (layers[index].type === 'fill-extrusion') {
            return layers[index].id;
        }
    }
    throw new Error('Map style does not contain any layer with fill-extrusion type.');
}

map.once('load', function() {
    tt.services.calculateRoute({
        key: 'Tx9B4cZ2IumFk28ymZwzp2B17tcHt6nZ',
        traffic: false,
        locations: marker1Centar + ":" + marker2Centar
    })
    .go()
    .then(function(response) {
        var geojson = response.toGeoJson();
        map.addLayer({
            'id': 'route',
            'type': 'line',
            'source': {
                'type': 'geojson',
                'data': geojson
            },
            'paint': {
                'line-color': '#f82249',
                'line-width': 8
            }
        }, findFirstBuildingLayerId());
        var bounds = new tt.LngLatBounds();
        geojson.features[0].geometry.coordinates.forEach(function(point) {
            bounds.extend(tt.LngLat.convert(point));
        });
        map.fitBounds(bounds, { duration: 0, padding: 50 });
    });
});

function createMarker(icon, position, color, popupText, drag) {
    var markerElement = document.createElement('div');
    markerElement.className = 'marker';
    var markerContentElement = document.createElement('div');
    markerContentElement.className = 'marker-content';
    markerContentElement.style.backgroundColor = color;
    markerElement.appendChild(markerContentElement);
    var iconElement = document.createElement('div');
    iconElement.className = 'marker-icon';
    iconElement.style.backgroundImage = 'url(' + icon + ')';
    markerContentElement.appendChild(iconElement);
    var popup = new tt.Popup({offset: 30}).setText(popupText);
    if (!drag)
    return new tt.Marker({element: markerElement, anchor: 'bottom'})
        		 .setLngLat(position)
        		 .setPopup(popup)
        		 .addTo(map);
    return new tt.Marker({element: markerElement, draggable: true})
        		 .setLngLat(position)
        		 .setPopup(popup)
        		 .addTo(map);
}

function promjeniCentar(pocetak, kraj) {
    marker1.remove();
    marker2.remove();
    markerK.remove();
    marker1Centar = pocetak;
    marker2Centar = kraj;
    marker1 = createMarker('https://img.icons8.com/ios-filled/50/000000/a.png', marker1Centar, '#0000CD', 'Početak', false);
    marker2 = createMarker('https://img.icons8.com/ios-filled/50/000000/b.png', marker2Centar, '#0000CD', 'Kraj', false);
    centar = [(marker1Centar[0] + marker2Centar[0]) / 2, (marker1Centar[1] + marker2Centar[1]) / 2];
    markerK = createMarker('https://img.icons8.com/ios-filled/50/000000/contacts.png', centar, '#0000CD', 'Vaša lokacija', true);
    map.setCenter(centar);
}