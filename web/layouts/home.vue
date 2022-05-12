<template>
  <CThemeProvider>
    <main class="layout-wrapper">
      <HeaderPanel />
      <LeftPanel class="index-left-panel" />
      <div class="layout-main active">
        <Nuxt />
      </div>
    </main>
  </CThemeProvider>
</template>

<script>
import {
  CThemeProvider
} from '@chakra-ui/vue'
import HeaderPanel from '~/components/panel/HeaderPanel.vue'
import LeftPanel from '~/components/panel/LeftPanel.vue'
export default {
  name: 'HomeLayout',
  components: {
    HeaderPanel,
    CThemeProvider,
    LeftPanel
  }
}
</script>

<style src="@/assets/styles/scss/layout/layouting.scss" lang="scss">
