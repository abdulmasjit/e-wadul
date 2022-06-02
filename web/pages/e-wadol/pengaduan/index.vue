<template>
  <div>
    yeayyy
    <div id="mapDiv" style="height: 300px;"></div>
  </div>
</template>

<script>
import {
  Loader
} from '@googlemaps/js-api-loader'
import * as VueGoogleMaps from 'vue2-google-maps'

const loader = new Loader({
  apiKey: 'AIzaSyA4AaXb62jV5KSJG3jVO9-6mexASBMXEVk',
  version: 'weekly',
  // libraries: ['places']
});

let map

export default {
  // head() {
  //   return {
  //     script: [{
  //       src: `https://maps.googleapis.com/maps/api/js?key=AIzaSyBHsQPcuRrfglDvRqFtg57GsxCh1RfVTw8&callback=initMap&v=weekly`
  //     }]
  //   };
  // },
  data() {
    return {
      map: '',
      // options: LoaderOptions = {
      //   /* todo */
      // },
      // loader: new Loader('AIzaSyBHsQPcuRrfglDvRqFtg57GsxCh1RfVTw8', options),
      // google: ''
    }
  },
  // computed: {
  //   google: VueGoogleMaps.gmapApi
  // },
  create() {
    // this.createMap()
  },
  mounted() {
    // this.google = this.loader.load()
    // this.createMap()
    loader.load().then(() => {
      console.log('masuk then', google.maps)
      map = new google.maps.Map(document.getElementById("mapDiv"), {
        center: {
          lat: -34.397,
          lng: 150.644
        },
        zoom: 10,
      })
    })

    // new google.maps.Map(document.getElementById('mapDiv'), {
    //   center: {
    //     lat: -34.397,
    //     lng: 150.644
    //   },
    //   zoom: 8,
    // })
    //   console.log('set map', map)
    // });
    // var map = this.google.maps.Map(document.getElementById('mapDiv'))
    // VueGoogleMaps.loaded.then(() => {
    // })
  },

  methods: {}
};
</script>
