<template>
  <div>
    <div>
      {{selectedLocation}}
    </div>
    <div
      id="mapDiv"
      ref="mapDiv"
      style="width: 100%; height: 300px" />
    <div id="desckriptionEl" ref="desckriptionEl">
      {{selectedLocation}}
      <br>
      <div class=" mt-2 p-0.5 bg-yellow-500 rounded-2">Simpan</div>
    </div>
    <c-input
      type="text"
      id="pac-input"
      class="input-primary w-full"
      v-model="selectedLocation"
      placeholder="Cari Lokasi" />
  </div>
</template>

<script>
import {
  Loader
} from '@googlemaps/js-api-loader'

const loader = new Loader({
  apiKey: process.env.googleApiKey,
  version: 'weekly',
  libraries: ['places']
});

let map

export default {
  name: 'Maps',
  data() {
    return {
      map: '',
      currentLocation: null,
      infoWindow: null,
      icon: '',
      selectedLocation: '',
      markers: [],
      lat: '',
      lng: ''
    }
  },
  mounted() {
    this.$getLocation({
      enableHighAccuracy: true, //defaults to false
      timeout: Infinity, //defaults to Infinit
    }).then(coordinates => {
      this.currentLocation = coordinates
      this.initMap()
    })
  },

  methods: {
    clearMarker() {
      this.markers.forEach(marker => {
        marker.setMap(null);
      });
      this.markers = [];
    },

    infoWindowRestart(latLangData, marker) {
      this.infoWindow.close()
      this.infoWindow = new google.maps.InfoWindow({
        position: latLangData
      });
      this.infoWindow.setContent('Lokasi Anda ')
      this.infoWindow.open(map, marker)
    },
    infoWindowRestartNew(latLangData, marker, address) {
      this.infoWindow.close()
      this.infoWindow = new google.maps.InfoWindow({
        position: latLangData
      });
      this.selectedLocation = address
      this.lat = latLangData.lat()
      this.lng = latLangData.lng()
      this.infoWindow.setContent(`${address}, {lat: ${this.lat}, lng: ${this.lng}}`)
      this.infoWindow.open(map, marker)
    },

    createMarker(map, placeInfo) {
      const marker = new google.maps.Marker({
        map,
        icon: this.icon,
        title: placeInfo.name,
        position: placeInfo.location
      });
      this.markers.push(marker);
      return marker;
    },

    CenterControl(controlDiv, map) {
      const controlUI = document.getElementById("desckriptionEl");

      controlUI.style.backgroundColor = "#fff";
      controlUI.style.border = "2px solid #fff";
      controlUI.style.borderRadius = "3px";
      controlUI.style.boxShadow = "0 2px 6px rgba(0,0,0,.3)";
      controlUI.style.cursor = "pointer";
      controlUI.style.marginTop = "8px";
      controlUI.style.marginBottom = "22px";
      controlUI.style.textAlign = "center";
      controlUI.title = "Click to recenter the map";
      controlDiv.appendChild(controlUI);
      controlUI.addEventListener("click", () => {
        this.saveData()
      })
    },

    geocodeLatLngAndMarkPan(latlng, geocoder) {
      geocoder.geocode({
          location: latlng
        })
        .then((response) => {
          if (response.results[0]) {
            this.map.setZoom(15);
            const marker = createMarker(map, {
              name: "test potision",
              location: latlng
            })
            this.infoWindowRestartNew(latlng, marker, `${response.results[0].formatted_address}`)
          } else {
            window.alert("No results found");
          }
        })
        .catch((e) => window.alert("Geocoder failed due to: " + e));
    },
    initMap() {
      loader.load().then(() => {
        this.icon = {
          url: "https://maps.gstatic.com/mapfiles/place_api/icons/v1/png_71/geocode-71.png",
          size: new google.maps.Size(30, 30),
          origin: new google.maps.Point(0, 0),
          anchor: new google.maps.Point(17, 34),
          scaledSize: new google.maps.Size(25, 25)
        }
        this.map = new google.maps.Map(document.getElementById('mapDiv'), {
          center: {
            lat: this.currentLocation.lat,
            lng: this.currentLocation.lng
          },
          zoom: 10,
        })
        this.markers = new google.maps.Marker({
          position: {
            lat: this.currentLocation.lat,
            lng: this.currentLocation.lng
          },
          map: this.map
        })
        this.infoWindow = new google.maps.InfoWindow({
          content: "Lokasi Anda",
          position: {
            lat: this.currentLocation.lat,
            lng: this.currentLocation.lng
          }
        })
        const centerControlDiv = document.createElement("div");
        this.CenterControl(centerControlDiv, map);
        this.map.controls[google.maps.ControlPosition.BOTTOM_CENTER].push(centerControlDiv);

        this.map.addListener("click", (mapsMouseEvent) => {
          this.clearMarker();
          console.log("markers", markers)
          this.geocodeLatLngAndMarkPan(mapsMouseEvent.latLng, geocoder)
        })

        const input = document.getElementById("pac-input")
        const searchBox = new google.maps.places.SearchBox(input)

        this.map.controls[google.maps.ControlPosition.TOP_CENTER].push(input)

        // Bias the SearchBox results towards current map's viewport.
        this.map.addListener("bounds_changed", () => {
          searchBox.setBounds(this.map.getBounds())
        })

        // Listen for the event fired when the user selects a prediction and retrieve
        // more details for that place.
        searchBox.addListener("places_changed", () => {
          console.log("places_changed searchBox.getPlaces()", searchBox.getPlaces())
          const places = searchBox.getPlaces()

          if (places.length == 0) {
            return
          }

          this.clearMarker()

          // For each place, get the icon, name and location.
          const bounds = new google.maps.LatLngBounds()

          places.forEach((place) => {

            if (!place.geometry || !place.geometry.location) {
              console.log("Returned place contains no geometry")
              return
            }
            // let marker = createMarker(map, {title: place.name, position: place.geometry.location })
            geocodeLatLngAndMarkPan(place.geometry.location, geocoder)

            if (place.geometry.viewport) {
              bounds.union(place.geometry.viewport)
            } else {
              bounds.extend(place.geometry.location)
            }
          })

          this.map.fitBounds(bounds)
        })
      })
    },
    saveData() {
      // clearMarker()
      const res = {
        selectedLocation: selectedLocation.value,
        lat: lat.value,
        lng: lng.value
      }
      this.$emit('sendData', JSON.stringify(res))
    }
  }
};
</script>
