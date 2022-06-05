<template>
  <div>
    <div
      id="mapDiv"
      ref="mapDiv"
      class="mapDiv" />
    <div
      id="desckriptionEl"
      ref="desckriptionEl"
      v-show="lat && lng">
      {{selectedLocation}}
      <br>
      <div class=" mt-2 p-0.5 bg-yellow-500 rounded-2">Simpan</div>
    </div>
    <c-input
      type="text"
      id="pac-input"
      class="input-primary mt-1"
      style="width: 400px"
      v-model="selectedLocation"
      v-if="isSearch"
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
  props: {
    isSearch: {
      default: () => null
    },
    isSaveMarkers: {
      default: () => false
    },
    dataMaps: {
      default: () => []
    }
  },
  emits: ['sendData'],
  data() {
    return {
      map: '',
      currentLocation: null,
      infoWindow: null,
      icon: '',
      selectedLocation: '',
      markers: [],
      marker1: null,
      lat: '',
      lng: '',
      geocoder: null
    }
  },
  mounted() {
    console.log('gak rugi', this.isSearch)
    console.log('maps', this.dataMaps)
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
      console.log('clearmarker', this.markers)
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
      this.infoWindow.setContent(`${address}`)
      this.infoWindow.open(map, marker)
    },

    createMarker(map, placeInfo) {
      const marker = new google.maps.Marker({
        map,
        icon: this.icon,
        title: placeInfo.name,
        position: placeInfo.location
      })
      this.markers.push(marker);
      console.log('any markers', this.markers)
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
      console.log('geocoder', geocoder)
      console.log('data ltlng', latlng.lng())

      this.geocoder.geocode({
          location: latlng
        })
        .then((response) => {
          console.log('ok result', response)
          if (response.results[0]) {
            this.map.setZoom(15)
            this.marker1 = new google.maps.Marker({
              map: this.map,
              icon: this.icon,
              // title: placeInfo.name,
              position: latlng
            })
            this.lat = latlng.lat()
            this.lng = latlng.lng()
            // const marker = createMarker(map, {
            //   name: "test potision",
            //   location: latlng
            // })
            this.infoWindowRestartNew(latlng, this.marker1, `${response.results[0].formatted_address}`)
          } else {
            window.alert("No results found");
          }
        })
        .catch((e) => console.log("Geocoder failed due to: " + e));
    },
    initMap() {
      loader.load().then(() => {
        this.icon = {
          url: "https://maps.gstatic.com/mapfiles/place_api/icons/v1/png_71/geocode-71.png",
          // size: new google.maps.Size(30, 30),
          // origin: new google.maps.Point(0, 0),
          // anchor: new google.maps.Point(17, 34),
          scaledSize: new google.maps.Size(25, 25)
        }
        this.geocoder = new google.maps.Geocoder()
        this.map = new google.maps.Map(document.getElementById('mapDiv'), {
          center: {
            lat: this.currentLocation.lat,
            lng: this.currentLocation.lng
          },
          zoom: 15,
        })
        if (this.dataMaps.length > 0) {
          if (this.dataMaps.length > 1) {
            this.map.setZoom(8)
          }
          for (let i = 0; i < this.dataMaps.length; i++) {
            this.createMarker(this.map, {
              location: {
                lat: this.dataMaps[i].lat,
                lng: this.dataMaps[i].lng
              },
              name: this.dataMaps[i].name
            })
          }
        }

        this.infoWindow = new google.maps.InfoWindow({
          content: "Lokasi Anda",
          // position: {
          //   lat: this.currentLocation.lat,
          //   lng: this.currentLocation.lng
          // }
        })

        // this.map.addListener('click', (mapsMouseEvent) => {
        //   this.clearMarker()
        //   // console.log("map", this.map)
        //   // console.log('mapsssss', mapsMouseEvent)
        //   this.geocodeLatLngAndMarkPan(mapsMouseEvent.latLng, this.geocoder)
        // });
        if (this.isSearch == true) {
          this.marker1 = new google.maps.Marker({
            map: this.map,
            // draggable: true,
            position: {
              lat: this.currentLocation.lat,
              lng: this.currentLocation.lng
            },
          })
          const input = document.getElementById('pac-input')
          const searchBox = new google.maps.places.SearchBox(input)

          this.map.controls[google.maps.ControlPosition.TOP_CENTER].push(input)

          // Bias the SearchBox results towards current map's viewport.
          this.map.addListener('bounds_changed', () => {
            searchBox.setBounds(this.map.getBounds())
          })

          // Listen for the event fired when the user selects a prediction and retrieve
          // more details for that place.
          searchBox.addListener('places_changed', () => {
            console.log('places_changed searchBox.getPlaces()', searchBox.getPlaces())
            const places = searchBox.getPlaces()
            const centerControlDiv = document.createElement('div');
            this.CenterControl(centerControlDiv, map);
            this.map.controls[google.maps.ControlPosition.BOTTOM_CENTER].push(centerControlDiv)
            if (places.length == 0) {
              return
            }

            //   this.clearMarker()

            //   // For each place, get the icon, name and location.

            places.forEach((place) => {

              if (!place.geometry || !place.geometry.location) {
                console.log('Returned place contains no geometry')
                return
              }
              // let marker = createMarker(map, {title: place.name, position: place.geometry.location })
              this.geocodeLatLngAndMarkPan(place.geometry.location, this.geocoder)

              if (place.geometry.viewport) {
                bounds.union(place.geometry.viewport)
              } else {
                bounds.extend(place.geometry.location)
              }
            })

          })
          const bounds = new google.maps.LatLngBounds(
            this.marker1.getPosition()
          )
          this.map.fitBounds(bounds)

        } else {
          for (let i = 0; i < this.markers.length; i++) {
            this.markers[i].addListener('click', (res) => {
              console.log('respone click', res)
              this.map.setZoom(20);
              this.map.setCenter(res.latLng)
            })
          }
        }
        // google.maps.event.addListener(this.marker1, 'position_changed', this.update)
        // this.marker1.addListener('click', (res) => {
        //   console.log('ok response marker', res)
        //   // this.infoWindowRestartNew(res.latLng)
        //   this.infoWindow.open({
        //     anchor: this.marker1,
        //     map: this.map,
        //     shouldFocus: false,
        //   })
        // })
      })
    },
    update() {
      const path = [this.marker1.getPosition()];
      setTimeout(this.geocodeLatLngAndMarkPan(new google.maps.LatLng(this.marker1.getPosition()), this.geocoder), 5000)
    },
    saveData() {
      // clearMarker()
      const res = {
        location: this.selectedLocation,
        lat: this.lat,
        lng: this.lng
      }
      this.$emit('sendData', res)
    }
  }
};
</script>

<style lang="scss">
.mapDiv {
  min-width: 300px;
  width: 100%;
  min-height: 300px;
}
</style>
