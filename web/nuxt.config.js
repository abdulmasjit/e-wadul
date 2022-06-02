import customTheme from './custom-theme'

export default {
  // Mode configuration : https://nuxtjs.org/docs/configuration-glossary/configuration-mode
  ssr: false,

  // https://nuxtjs.org/docs/configuration-glossary/configuration-env/
  env: {
    apiUrl: process.env.API_URL || 'http://localhost:5000/api/v1/'
  },

  // Global page headers: https://go.nuxtjs.dev/config-head
  head: {
    title: 'E - Wadul',
    meta: [
      { charset: 'utf-8' },
      { name: 'viewport', content: 'width=device-width, initial-scale=1' },
      { hid: 'description', name: 'description', content: '' },
      { name: 'format-detection', content: 'telephone=no' },
    ],
    src: [
      {
        src: `https://maps.googleapis.com/maps/api/js?key=AIzaSyA4AaXb62jV5KSJG3jVO9-6mexASBMXEVk&callback=initMap&v=weekly`,
        async: true,
        defer: true
      }
    ],
    link: [{ rel: 'icon', type: 'image/x-icon', href: '/favicon.ico' }],
  },

  // Global CSS: https://go.nuxtjs.dev/config-css
  css: [
    '~/assets/styles/css/tailwind/tailwind.css',
    '~/assets/styles/scss/main.scss',
    // '@fortawesome/fontawesome-svg-core/styles.css'
  ],

  // Plugins to run before rendering page: https://go.nuxtjs.dev/config-plugins
  plugins: [
    '~/plugins/vee-validate.ts',
    '~/plugins/chakra-ui.ts',
    '~/plugins/dev-extreme.ts',
    '~/plugins/vue-geolocation.ts'
    // '~/plugins/fontawesome.js',
  ],

  // Auto import components: https://go.nuxtjs.dev/config-components
  components: true,

  // Modules for dev and build (recommended): https://go.nuxtjs.dev/config-modules
  buildModules: [
    // https://go.nuxtjs.dev/typescript
    '@nuxt/typescript-build',
    '@nuxt/postcss8',
    '@nuxtjs/fontawesome'
  ],

  fontawesome: {
    // components: 'fa',
    icons: {
      solid: true,
      // brand: true,
    }
  },

  // Modules: https://go.nuxtjs.dev/config-modules
  modules: [
    // https://go.nuxtjs.dev/chakra
    '@chakra-ui/nuxt',
    // https://go.nuxtjs.dev/emotion
    '@nuxtjs/emotion',
    // https://go.nuxtjs.dev/axios
    '@nuxtjs/axios',
    // https://go.nuxtjs.dev/pwa
    '@nuxtjs/pwa',
    'vue-sweetalert2/nuxt',
  ],
  sweetalert: {
    confirmButtonColor: '#029141',
    cancelButtonColor: '#CB0000',
    confirmButtonText: 'Ok',
    cancelButtonText: 'Batal'
  },

  // chakra: {
  //   extendTheme: customTheme
  // },

  purgeCSS: {
    whitelistPatterns: [/svg.*/, /fa.*/]
  },

  // Axios module configuration: https://go.nuxtjs.dev/config-axios
  axios: {
    // Workaround to avoid enforcing hard-coded localhost:3000: https://github.com/nuxt-community/axios-module/issues/308
    baseURL: '/',
  },

  // PWA module configuration: https://go.nuxtjs.dev/pwa
  pwa: {
    manifest: {
      lang: 'en',
    },
  },

  // Base router configuration: https://nuxtjs.org/docs/configuration-glossary/configuration-router/
  router: {
    base: '/',
  },

  loading: {
    color: '#029141'
  },

  // Build Configuration: https://go.nuxtjs.dev/config-build
  build: {
    transpile: [
      'vee-validate/dist/rules',
    ],
    postcss: {
      plugins: {
        tailwindcss: {},
        autoprefixer: {},
      },
    },
  },
}
