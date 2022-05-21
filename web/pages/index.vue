<template>
  <div></div>
</template>

<script>
export default {
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
