$(document).ready(function () {
  var map;
  var colours = ['#FF0000', '#00FF00', '#0000FF', '#FFFF00', '#FF00FF'];
  var currentColourIndex = 0;

  console.log('doc ready');

  function initialize() {
    var mapOptions = {
      center: { lat: -36.8406, lng: 174.74},
      zoom: 13,
      //disableDefaultUI: true,
      streetViewControl: false
    };
    map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);
  }
  google.maps.event.addDomListener(window, 'load', initialize);


  $('#bus-form').on('submit', function (event) {
    var busStopNum = $("#stopNumField").val();
    var requestURL = "http://at1337testapi.azurewebsites.net/stop_code=" + busStopNum;
    
    console.log('submit', event);

    event.preventDefault();

    console.log('bus stop num', busStopNum);
  
    $.ajax({
      url: requestURL,
      success: function (data) {
        console.log('updating map', data);
        updateMap(data)
      },
      error: function () {
        console.log('error');
      }
    });
    
    console.log('end');
  });

  function updateMap(data) {
    var allRoutes = data.routes;
    var counter = 0;

    console.log('trying to update map');

    currentColourIndex = 0;

    for(var index = 0; index < allRoutes.length; index++) {
      var route = allRoutes[index];
      console.log('route', route);

      var routePath = [];
      var coordinates = route.coordinates;

      for(var cindex = 0; cindex < coordinates.length; cindex++) {
        routePath.push(new google.maps.LatLng(coordinates[cindex].latitude, coordinates[cindex].longitude));
      }

      var strokeColour = colours[currentColourIndex];
      console.log("stroke color" + strokeColour);
      var routePolygon = new google.maps.Polyline({
        paths: routePath,
        strokeColor: strokeColour,
        strokeOpacity: 0.8,
        strokeWeight: 2
      });
      currentColourIndex++;
      if (currentColourIndex >= colours.length) {
        currentColourIndex = 0; 
      }
    
      routePolygon.setMap(map);
    }
  }
});