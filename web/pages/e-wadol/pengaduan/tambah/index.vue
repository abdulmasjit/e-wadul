<template>
  <div>
    <c-breadcrumb separator="›" class="mb-5">
      <c-breadcrumb-item>
        <c-breadcrumb-link><nuxt-link :to="{ name: 'e-wadol-pengaduan'}">Pengaduan</nuxt-link></c-breadcrumb-link>
      </c-breadcrumb-item>

      <c-breadcrumb-item>
        <c-breadcrumb-link>Tambah Pengaduan Baru</c-breadcrumb-link>
      </c-breadcrumb-item>
    </c-breadcrumb>
    <div class="card-def px-5 py-5">
      <h6 class="mb-5 font-semibold">Tambah Pengaduan Baru</h6>
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
