<template>
  <CThemeProvider>
    <nuxt-child />
  </CThemeProvider>
</template>

<script>
export default {
  layout: 'home',
  middleware({
    store,
    redirect,
    route
  }) {
    // console.log('ini route', route)
    if (route.name === 'index') {
      redirect({
        name: 'login'
      })
    }
  }
}
</script>
