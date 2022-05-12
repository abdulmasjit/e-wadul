<template>
  <CThemeProvider>
    <Nuxt />
  </CThemeProvider>
</template>

<script>
import {
  CThemeProvider
} from '@chakra-ui/vue'
export default {
  name: 'DefaultLayout',
  components: {
    CThemeProvider
  }
}
</script>

<style>

</style>
