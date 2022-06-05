<template>
  <CThemeProvider>
    <main class="layout-wrapper">
      <HeaderPanel />
      <LeftPanel class="index-left-panel" />
      <div class="layout-main active">
        <transition
          name="cust"
          enter-active-class="animate__animated animate__delay-1s animate__fast animate__fadeInRight"
          leave-active-class="animate__animated animate__fadeOutRight animate__faster">
          <Nuxt />
        </transition>
      </div>
    </main>
  </CThemeProvider>
</template>

<script>
import HeaderPanel from '~/components/panel/HeaderPanel.vue'
import LeftPanel from '~/components/panel/LeftPanel.vue'
export default {
  name: 'HomeLayout',
  middleware: ['auth-admin'],
  components: {
    HeaderPanel,
    LeftPanel
  }
}
</script>

<style src="@/assets/styles/scss/layout/layouting.scss" lang="scss">
