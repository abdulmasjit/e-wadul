<template>
  <div>
    <c-breadcrumb separator="›" class="mb-5">
      <c-breadcrumb-item>
        <c-breadcrumb-link><nuxt-link :to="{ name: 'e-wadol-pengaduan'}">Pengaduan</nuxt-link></c-breadcrumb-link>
      </c-breadcrumb-item>

      <c-breadcrumb-item>
        <c-breadcrumb-link>Detail Pengaduan</c-breadcrumb-link>
      </c-breadcrumb-item>
    </c-breadcrumb>
    <div class="card-def px-5 py-5">
      <h6 class="mb-5 font-semibold">Detail Pengaduan</h6>
      <FormPengaduan />
    </div>
  </div>
</template>

<script>
import FormPengaduan from '~/views/pengaduan/FormPengaduan.vue'

export default {
  components: {
    FormPengaduan
  }
}
</script>

<style>

</style>
