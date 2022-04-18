<template>

</template>

<script>
export default {
  middleware({
    store,
    redirect
  }) {
    // If the user is not authenticated
    return redirect('/login')
  }
}
</script>
