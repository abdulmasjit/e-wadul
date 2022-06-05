<template>
  <header class="layout-topbar">
    <div class="flex items-center con-layout-topbar">
      <div class="flex items-center">
        <img src="~/assets/images/logo/icon-text-ewadul.png" class="logo-header" />
      </div>
      <c-popover placement="bottom">
        <c-popover-trigger>
          <c-avatar
            :name="this.$store.state.appActiveUser.nama"
            class="cursor-pointer"
            v-if="this.$store.state.appActiveUser" />
        </c-popover-trigger>
        <c-popover-content z-index="4">
          <c-popover-body>
            <div>
              <div class="flex gap-2 items-center cursor-pointer" @click="logout">
                <font-awesome-icon class="cursor-pointer" :icon="['fas', 'arrow-right-from-bracket']" />
                <p class="text-sm">Logout</p>
              </div>
            </div>
          </c-popover-body>
        </c-popover-content>
      </c-popover>
    </div>
  </header>
</template>

<script>
export default {
  methods: {
    logout() {
      this.$router.push({
        name: 'login'
      })
      this.$store.dispatch('logoutAccount')
    }
  }
}
</script>

<style>

</style>
