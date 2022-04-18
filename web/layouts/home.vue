<template>
  <main class="layout-wrapper">
    <HeaderPanel />
    <div class="layout-main"></div>
  </main>
</template>

<script>
import HeaderPanel from '~/components/panel/HeaderPanel.vue'
export default {
  name: 'HomeLayout',
  components: {
    HeaderPanel
  }
}
</script>

<style src="@/assets/styles/scss/layout/layouting.scss" lang="scss">
