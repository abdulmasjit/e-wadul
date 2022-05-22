<template>
  <c-modal
    :is-open="isShow"
    :on-close="onClose"
    :closeOnOverlayClick="false"
    is-centered
    size="xl">
    <c-modal-content ref="content">
      <c-modal-header>{{title}}</c-modal-header>
      <c-modal-close-button />
      <c-modal-body>
        <div>
          <ValidationObserver ref="form">
            <form @submit.prevent="submit">
              <div class="mb-5">
                <ValidationProvider
                  name="Nama"
                  rules="required"
                  v-slot="{ errors }">
                  <label class="text-body2">Nama</label>
                  <c-input
                    placeholder="Jenis Pengaduan"
                    class="mt-1"
                    focus-border-color="primary"
                    v-model="name" />
                  <span class="text-error">{{ errors[0] }}</span>
                </ValidationProvider>
              </div>
            </form>
          </ValidationObserver>
        </div>
      </c-modal-body>
      <c-modal-footer>
        <div class="flex gap-2">
          <c-button
            variant-color="green"
            class="rounded-lg flex gap-4 items-center"
            variant="solid"
            @click="submit">Submit</c-button>
          <c-button @click="onClose">Cancel</c-button>
        </div>
      </c-modal-footer>
    </c-modal-content>
    <c-modal-overlay />
  </c-modal>
</template>

<script>
export default {
  name: 'FormJenisPengaduan',
  props: {
    isShow: {
      default: () => false
    },
    data: {
      default: () => null
    }
  },
  emits: ['closeModal', 'submitData'],
  data() {
    return {
      name: null,
      title: null
    }
  },
  mounted() {
    this.title = 'Tambah Jenis Pengaduan'
    if (this.data) {
      this.title = 'Edit Jenis Pengaduan'
      this.name = this.data.nama
    }
  },
  methods: {
    onClose() {
      this.$emit('closeModal')
    },
    submit() {
      this.$refs.form.validate().then((success) => {
        console.log('isSuccess', success)
        if (success) {
          this.$emit('submitData', {
            id: this.data ? this.data.id : null,
            nama: this.name
          })
        }
      })
    }
  }
}
</script>

<style>

</style>
