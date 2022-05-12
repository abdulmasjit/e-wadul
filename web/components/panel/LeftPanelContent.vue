<template>
  <div class="left-panel-content">
    <div v-for="(data, index) in menus" :key="index">
      <NuxtLink :to="{name: data.routeName}" :class="classContainerTitle(data)">
        <p class="title">{{data.title}}</p>
      </NuxtLink>
    </div>
  </div>
</template>

<script>
import menusLocal from '~/data/source/local/json/menus.json'

export default {
  name: 'LeftPanelContent',
  data() {
    return {
      menus: menusLocal
    }
  },
  mounted() {
    console.log('this route', this.$route)
  },
  methods: {
    classContainerTitle(val) {
      if (val.routeName === this.$route.name) {
        return 'container-title active'
      }
      return 'container-title'
    }
  }
}
</script>

<style>

</style>
